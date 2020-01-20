﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AutoStep.Execution;
using AutoStep.Execution.Dependency;
using AutoStep.Tracing;
using Microsoft.Extensions.Logging;

namespace AutoStep.Definitions
{
    /// <summary>
    /// The assembly step definition source loads steps from .NET assemblies.
    /// </summary>
    public class AssemblyStepDefinitionSource : IStepDefinitionSource
    {
        private readonly Assembly assembly;
        private readonly ILogger logger;
        private readonly List<StepDefinition> definitions = new List<StepDefinition>();
        private readonly List<Type> definitionOwningTypes = new List<Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyStepDefinitionSource"/> class.
        /// </summary>
        /// <param name="assembly">The assembly to load steps from.</param>
        /// <param name="tracer">The tracer.</param>
        public AssemblyStepDefinitionSource(Assembly assembly, ILoggerFactory logFactory)
        {
            this.assembly = assembly;
            this.logger = logFactory.CreateLogger($"AssemblySteps-{assembly.GetName().Name}");
        }

        /// <summary>
        /// Gets a unique, non-human-readable identifier for the source. Two sources with the same UID cannot share steps. For assembly sources
        /// this is the assembly location.
        /// </summary>
        public string Uid => assembly.Location;

        /// <summary>
        /// Gets the name of the source.
        /// </summary>
        public string Name => assembly.Location;

        public void ConfigureServices(IServicesBuilder servicesBuilder, RunConfiguration configuration)
        {
            if (servicesBuilder is null)
            {
                throw new ArgumentNullException(nameof(servicesBuilder));
            }

            // All types providing steps should be registered.
            // We'll see about reloading DLLs later (TODO).
            foreach (var definitionType in definitionOwningTypes)
            {
                servicesBuilder.RegisterConsumer(definitionType);
            }
        }

        /// <summary>
        /// Gets the last modification time of the assembly.
        /// </summary>
        /// <returns>The timestamp.</returns>
        public DateTime GetLastModifyTime()
        {
            // Last modify will be the last write time of the step definitions.
            return new FileInfo(assembly.Location).LastWriteTimeUtc;
        }

        /// <summary>
        /// Get the step definitions.
        /// </summary>
        /// <returns>The step definitions.</returns>
        public IEnumerable<StepDefinition> GetStepDefinitions()
        {
            // If we've already loaded them, just return the existing set.
            if (definitions.Count == 0)
            {
                // Search for public types that are decorated with a Steps attribute.
                var allPublicTypes = assembly.GetExportedTypes();

                foreach (var type in allPublicTypes)
                {
                    if (type.GetCustomAttribute<StepsAttribute>(true) is object && !type.IsAbstract)
                    {
                        var anyDefinitions = false;

                        logger.LogInformation("Looking in type '{0}' for steps.", type.FullName);

                        // This type may contain steps.
                        foreach (var method in type.GetMethods())
                        {
                            var definition = method.GetCustomAttribute<StepDefinitionAttribute>(true);

                            if (definition is object)
                            {
                                anyDefinitions = true;

                                logger.LogInformation("Found step method, declared as '{0} {1}' on '{2}'", definition.Type, definition.Declaration, method.Name);

                                definitions.Add(new ClassStepDefinition(this, type, method, definition));
                            }
                        }
                    }
                }
            }

            return definitions;
        }
    }
}
