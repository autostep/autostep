﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoStep.Definitions;
using AutoStep.Definitions.Interaction;
using AutoStep.Elements.Test;
using AutoStep.Language;
using AutoStep.Language.Interaction;
using AutoStep.Language.Test;
using AutoStep.Language.Test.LineTokeniser;
using AutoStep.Language.Test.Matching;
using Microsoft.Extensions.Logging;

namespace AutoStep.Projects
{
    /// <summary>
    /// Provides the functionality to compile and link an entire project.
    /// </summary>
    public class ProjectBuilder : IProjectBuilder
    {
        private static readonly InteractionsFileSetBuildResult EmptySuccess = new InteractionsFileSetBuildResult(true, Enumerable.Empty<LanguageOperationMessage>());

        private readonly Project project;
        private readonly ITestCompiler compiler;
        private readonly ILinker linker;
        private readonly TestLineTokeniser testLineTokeniser;

        private readonly IInteractionCompiler interactionCompiler;
        private readonly Func<IInteractionSetBuilder> setBuilderFactory;
        private readonly InteractionLineTokeniser interactionLineTokeniser;
        private readonly bool buildExtendedMethodTableReferences;
        private InteractionStepDefinitionSource? interactionSteps;
        private IInteractionSet? currentInteractionSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectBuilder"/> class.
        /// </summary>
        /// <param name="project">The project to work on.</param>
        /// <param name="compiler">The compiler implementation to use.</param>
        /// <param name="linker">The linker implementation to use.</param>
        /// <param name="interactionCompiler">The interaction compiler.</param>
        /// <param name="setBuilderFactory">A factory for creating instances of <see cref="IInteractionSetBuilder" />.</param>
        /// <param name="buildExtendedMethodTableReferences">If true, then when building the interaction set, the extended reference data will be included.</param>
        public ProjectBuilder(
            Project project,
            ITestCompiler compiler,
            ILinker linker,
            IInteractionCompiler interactionCompiler,
            Func<IInteractionSetBuilder> setBuilderFactory,
            bool buildExtendedMethodTableReferences)
        {
            this.project = project ?? throw new ArgumentNullException(nameof(project));
            this.compiler = compiler ?? throw new ArgumentNullException(nameof(compiler));
            this.linker = linker ?? throw new ArgumentNullException(nameof(linker));
            this.interactionCompiler = interactionCompiler ?? throw new ArgumentNullException(nameof(interactionCompiler));
            this.setBuilderFactory = setBuilderFactory;
            this.buildExtendedMethodTableReferences = buildExtendedMethodTableReferences;

            this.testLineTokeniser = new TestLineTokeniser(linker);
            this.interactionLineTokeniser = new InteractionLineTokeniser();
        }

        /// <summary>
        /// Gets the global interactions configuration, that allows the global root method table to be manipulated.
        /// </summary>
        public IInteractionsConfiguration Interactions { get; } = new InteractionsConfiguration();

        /// <summary>
        /// Creates a default project builder with the normal compiler and linker settings.
        /// </summary>
        /// <param name="project">The project to work against.</param>
        /// <returns>A project compiler.</returns>
        public static ProjectBuilder CreateDefault(Project project)
        {
            return CreateWithOptions(project, TestCompilerOptions.Default, InteractionsCompilerOptions.Default, false);
        }

        /// <summary>
        /// Creates a project builder configured for code editing.
        /// </summary>
        /// <param name="project">The project to work against.</param>
        /// <returns>A project builder.</returns>
        public static ProjectBuilder CreateForEditing(Project project)
        {
            return CreateWithOptions(project, TestCompilerOptions.CreatePositionIndex, InteractionsCompilerOptions.CreatePositionIndex, true);
        }

        /// <summary>
        /// Creates a project builder with the provided compiler options.
        /// </summary>
        /// <param name="project">The project to work against.</param>
        /// <param name="testOptions">Options for the test compiler.</param>
        /// <param name="interactionOptions">Options for the interaction compiler.</param>
        /// <param name="buildExtendedMethodTableReferences">Generate extended method table reference set.</param>
        /// <returns>A project builder.</returns>
        public static ProjectBuilder CreateWithOptions(Project project, TestCompilerOptions testOptions, InteractionsCompilerOptions interactionOptions, bool buildExtendedMethodTableReferences)
        {
            var compiler = new TestCompiler(testOptions);

            var defaultCallChainValidator = new DefaultCallChainValidator();

            return new ProjectBuilder(
                project,
                compiler,
                new Linker(compiler),
                new InteractionCompiler(interactionOptions),
                () => new InteractionSetBuilder(defaultCallChainValidator),
                buildExtendedMethodTableReferences);
        }

        /// <summary>
        /// Compile the project. Goes through all the project files and compiles those that need compilation.
        /// </summary>
        /// <param name="cancelToken">A cancellation token that halts compilation partway through.</param>
        /// <returns>The overall project compilation result.</returns>
        public async Task<ProjectBuilderResult> CompileAsync(CancellationToken cancelToken = default)
        {
            using var logFactory = new LoggerFactory();

            return await CompileAsync(logFactory, cancelToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Compile the project. Goes through all the project files and compiles those that need compilation.
        /// </summary>
        /// <param name="loggerFactory">A logger factory.</param>
        /// <param name="cancelToken">A cancellation token that halts compilation partway through.</param>
        /// <returns>The overall project compilation result.</returns>
        public async Task<ProjectBuilderResult> CompileAsync(ILoggerFactory loggerFactory, CancellationToken cancelToken = default)
        {
            var allMessages = new List<LanguageOperationMessage>();

            var fixedFileSet = new List<ProjectFile>(project.AllFiles.Values);

            // Compile the interaction files.
            await CompileInteractionFilesAsync(loggerFactory, fixedFileSet, allMessages, cancelToken).ConfigureAwait(false);

            // Compile the test files.
            await CompileTestFilesAsync(loggerFactory, fixedFileSet, allMessages, cancelToken).ConfigureAwait(false);

            // Project compilation always succeeds, but possibly with individual file errors. We will aggregate all the file
            // messages and report them at once.
            return new ProjectBuilderResult(true, allMessages, project);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Need to convert exceptions into compiler messsages.")]
        private async Task CompileTestFilesAsync(ILoggerFactory loggerFactory, IReadOnlyList<ProjectFile> files, List<LanguageOperationMessage> allMessages, CancellationToken cancelToken = default)
        {
            // This method will go through all the autostep files in the project that match the filter and:
            //  - Verify that the built files are later than the source file last-modify time.
            //  - Update the project files with the built content.
            //  - Report any errors in that compilation.
            //  - Each file in the project will have its 'last' FileCompilerResult stored against it.
            foreach (var projectFile in files.OfType<ProjectTestFile>())
            {
                cancelToken.ThrowIfCancellationRequested();

                try
                {
                    // For each file.
                    // Compile.
                    // Add the result of the compilation to the ProjectFile.
                    // Add as a new step definition source to the linker if the file defines any step definitions.
                    if (projectFile.LastCompileTime < projectFile.ContentSource.GetLastContentModifyTime())
                    {
                        var fileResult = await DoProjectTestFileCompile(projectFile, loggerFactory, cancelToken).ConfigureAwait(false);

                        allMessages.AddRange(fileResult.Messages);
                    }
                }
                catch (IOException ex)
                {
                    allMessages.Add(LanguageMessageFactory.Create(projectFile.Path, CompilerMessageLevel.Error, CompilerMessageCode.IOException, 0, 0, ex.Message));
                }
                catch (Exception ex)
                {
                    // Severe enough error occurred inside the compilation process that we couldn't convert into
                    // a compiler message internally, and wasn't a more specific Exception we can catch.
                    // Add a catch all compilation error.
                    allMessages.Add(LanguageMessageFactory.Create(projectFile.Path, CompilerMessageLevel.Error, CompilerMessageCode.UncategorisedException, 0, 0, ex.Message));
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Need to convert exceptions into compiler messsages.")]
        private async Task CompileInteractionFilesAsync(ILoggerFactory loggerFactory, IReadOnlyList<ProjectFile> files, List<LanguageOperationMessage> allMessages, CancellationToken cancelToken = default)
        {
            if (interactionCompiler is null && project.AllFiles.Values.OfType<ProjectInteractionFile>().Any())
            {
                throw new InvalidOperationException(ProjectBuilderMessages.MissingInteractionCompiler);
            }

            var fileWasCompiled = false;

            // This method will go through all the interaction files (filters not considered).
            // If any of them need re-compiling, we will do so, and then regenerate the interaction set and update the
            // step definition source.
            foreach (var projectFile in files.OfType<ProjectInteractionFile>().OrderBy(f => f.Order))
            {
                cancelToken.ThrowIfCancellationRequested();

                try
                {
                    // For each file.
                    // Compile.
                    // Add the result of the compilation to the ProjectFile.
                    // Add as a new step definition source to the linker if the file defines any step definitions.
                    if (projectFile.LastCompileTime < projectFile.ContentSource.GetLastContentModifyTime())
                    {
                        var compileResult = await interactionCompiler!.CompileInteractionsAsync(projectFile.ContentSource, loggerFactory, cancelToken).ConfigureAwait(false);

                        fileWasCompiled = true;

                        projectFile.UpdateLastCompileResult(compileResult);

                        allMessages.AddRange(compileResult.Messages);
                    }
                }
                catch (IOException ex)
                {
                    allMessages.Add(LanguageMessageFactory.Create(projectFile.Path, CompilerMessageLevel.Error, CompilerMessageCode.IOException, 0, 0, ex.Message));
                }
                catch (Exception ex)
                {
                    // Severe enough error occurred inside the compilation process that we couldn't convert into
                    // a compiler message internally, and wasn't a more specific Exception we can catch.
                    // Add a catch all compilation error.
                    allMessages.Add(LanguageMessageFactory.Create(projectFile.Path, CompilerMessageLevel.Error, CompilerMessageCode.UncategorisedException, 0, 0, ex.Message));
                }
            }

            if (fileWasCompiled)
            {
                // Create an interaction set builder.
                var interactionSetBuilder = setBuilderFactory();

                // Add our compiled files to it.
                foreach (var projectFile in files.OfType<ProjectInteractionFile>())
                {
                    if (projectFile.LastCompileResult?.Output is object)
                    {
                        interactionSetBuilder.AddInteractionFile(projectFile.LastCompileResult.Output);
                    }
                }

                var setBuild = interactionSetBuilder.Build(Interactions, buildExtendedMethodTableReferences);

                // Now we need to go through the messages and add them to the appropriate interaction files.
                var fileMessages = setBuild.Messages.Where(x => x.SourceName != null).GroupBy(x => x.SourceName).ToDictionary(x => x.Key, y => y.AsEnumerable());

                foreach (var projectFile in files.OfType<ProjectInteractionFile>())
                {
                    if (fileMessages.TryGetValue(projectFile.Path, out var messages))
                    {
                        projectFile.UpdateLastSetBuildResult(new InteractionsFileSetBuildResult(!messages.Any(x => x.Level == CompilerMessageLevel.Error), messages));
                    }
                    else
                    {
                        projectFile.UpdateLastSetBuildResult(EmptySuccess);
                    }
                }

                allMessages.AddRange(setBuild.Messages);

                if (setBuild.Output is object)
                {
                    if (interactionSteps is null)
                    {
                        interactionSteps = new InteractionStepDefinitionSource();
                    }

                    currentInteractionSet = setBuild.Output;

                    interactionSteps.UpdateInteractionSet(currentInteractionSet);

                    linker.AddOrUpdateStepDefinitionSource(interactionSteps);
                }
            }
        }

        private async Task<FileCompilerResult> DoProjectTestFileCompile(ProjectTestFile file, ILoggerFactory loggerFactory, CancellationToken cancelToken)
        {
            var compileResult = await compiler.CompileAsync(file.ContentSource, loggerFactory, cancelToken).ConfigureAwait(false);

            file.UpdateLastCompileResult(compileResult);

            if (file.StepDefinitionSource is object)
            {
                // Update the linker with the modified step definitions (if there are any).
                linker.AddOrUpdateStepDefinitionSource(file.StepDefinitionSource);
            }

            return compileResult;
        }

        /// <summary>
        /// Add a static step definition source (i.e. one that cannot change after it is registered).
        /// </summary>
        /// <param name="source">The step definition source.</param>
        public void AddStepDefinitionSource(IStepDefinitionSource source)
        {
            linker.AddStepDefinitionSource(source.ThrowIfNull(nameof(source)));
        }

        /// <summary>
        /// Add an updateable step definition source (i.e. one that can change dynamically).
        /// </summary>
        /// <param name="source">The step definition source.</param>
        public void AddUpdatableStepDefinitionSource(IUpdatableStepDefinitionSource source)
        {
            linker.AddOrUpdateStepDefinitionSource(source.ThrowIfNull(nameof(source)));
        }

        /// <summary>
        /// Retrieve the set of all step definition sources.
        /// </summary>
        /// <returns>The set of registered step definition sources.</returns>
        public IEnumerable<IStepDefinitionSource> EnumerateStepDefinitionSources()
        {
            return linker.AllStepDefinitionSources;
        }

        /// <summary>
        /// Retrieves the set of possible matches for the step definition.
        /// </summary>
        /// <param name="element">The step reference.</param>
        /// <returns>The set of results.</returns>
        public IEnumerable<IMatchResult> GetPossibleStepDefinitions(StepReferenceElement element)
        {
            return linker.GetPossibleMatches(element);
        }

        /// <summary>
        /// Retrieves the last built interaction set (or null if there is no active interaction set).
        /// </summary>
        /// <returns>The active interaction set.</returns>
        public IInteractionSet? GetCurrentInteractionSet()
        {
            return currentInteractionSet;
        }

        /// <summary>
        /// Links the entire project. Files that need to be re-linked will be.
        /// </summary>
        /// <param name="cancelToken">A cancellation token for the linker process.</param>
        /// <returns>The overall project link result.</returns>
        public ProjectBuilderResult Link(CancellationToken cancelToken = default)
        {
            var allMessages = new List<LanguageOperationMessage>();
            var fixedFiles = new List<ProjectTestFile>(project.AllFiles.Values.OfType<ProjectTestFile>());

            // This method will go through all the autostep files in the project and:
            //  - Link if needed.
            //  - Report any errors in the link.
            //  - Each file in the project will have its 'last' LinkResult stored against it.
            foreach (var projectFile in fixedFiles)
            {
                cancelToken.ThrowIfCancellationRequested();

                if (projectFile.LastCompileResult?.Output is null)
                {
                    // Without a compilation result, we can't link.
                    continue;
                }

                // For each file, if any of the following are true, then we link:
                //  - Have we linked before?
                //  - Did the previous linking have any problems?
                //  - Has the file been re-compiled since the last link?
                //  - Have any of the dependencies detected at the previous link been changed?
                if (projectFile.LastLinkResult is null ||
                    projectFile.LastLinkResult.AnyIssues ||
                    projectFile.LastLinkTime < projectFile.LastCompileTime ||
                    AnyLinkerDependenciesUpdated(projectFile))
                {
                    var linkResult = linker.Link(projectFile.LastCompileResult.Output);

                    projectFile.UpdateLastLinkResult(linkResult);

                    allMessages.AddRange(linkResult.Messages);
                }
            }

            return new ProjectBuilderResult(true, allMessages, project);
        }

        private static bool AnyLinkerDependenciesUpdated(ProjectTestFile file)
        {
            if (file.LinkerDependencies is null)
            {
                return false;
            }

            foreach (var dep in file.LinkerDependencies)
            {
                if (dep.GetLastModifyTime() > file.LastLinkTime)
                {
                    // The dependency has been changed
                    // more recently than this file was last linked, so we need to re-link.
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public LineTokeniseResult<LineTokeniserState> TokeniseTestLine(string line, LineTokeniserState lastTokeniserState = LineTokeniserState.Default)
        {
            return testLineTokeniser.Tokenise(line, lastTokeniserState);
        }

        /// <inheritdoc/>
        public LineTokeniseResult<int> TokeniseInteractionLine(string line, int lastTokeniserState = 0)
        {
            return interactionLineTokeniser.Tokenise(line, lastTokeniserState);
        }

        private class InteractionsConfiguration : IInteractionsConfiguration
        {
            public RootMethodTable RootMethodTable { get; } = new RootMethodTable();

            public InteractionConstantSet Constants { get; } = new InteractionConstantSet();
        }
    }
}
