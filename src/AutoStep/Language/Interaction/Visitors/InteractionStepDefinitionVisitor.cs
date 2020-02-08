﻿using System.Diagnostics;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AutoStep.Elements.Interaction;
using AutoStep.Elements.Parts;

namespace AutoStep.Language.Interaction.Visitors
{
    using static AutoStep.Language.Interaction.Parser.AutoStepInteractionsParser;

    /// <summary>
    /// Handles generating interaction step definitions from the Antlr parse context.
    /// </summary>
    internal class InteractionStepDefinitionVisitor : InteractionMethodHoldingVisitor<InteractionStepDefinitionElement>
    {
        private readonly InteractionConstantSet constants;

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionStepDefinitionVisitor"/> class.
        /// </summary>
        /// <param name="sourceName">The name of the source.</param>
        /// <param name="tokenStream">The token stream.</param>
        /// <param name="rewriter">A shared escape rewriter.</param>
        public InteractionStepDefinitionVisitor(string? sourceName, ITokenStream tokenStream, TokenStreamRewriter rewriter, InteractionConstantSet constants)
            : base(sourceName, tokenStream, rewriter)
        {
            this.constants = constants;
        }

        protected override void ValidateConstant(ParserRuleContext constantToken, string constantName)
        {
            if (!constants.ContainsConstant(constantName))
            {
                MessageSet.Add(constantToken, CompilerMessageLevel.Error, CompilerMessageCode.InteractionConstantNotDefined, constantName);
            }
        }

        protected override void ValidateArgumentVariable(ParserRuleContext nameRefToken, string variableName, bool isArrayRef)
        {
            // We need a variable state this tracked down the call chain.
            throw new System.NotImplementedException();
        }

        protected override InteractionMethodChainVariables GetInitialMethodChainVariables()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Builds a step, taking the Step Type, and the Antlr context for the declaration body.
        /// </summary>
        /// <param name="type">The step type.</param>
        /// <param name="definitionContext">The step declaration context.</param>
        /// <returns>A generated step reference.</returns>
        public InteractionStepDefinitionElement BuildStepDefinition(StepDefinitionBodyContext definitionContext)
        {
            Result = new InteractionStepDefinitionElement();

            Result.AddLineInfo(definitionContext);

            VisitChildren(definitionContext);

            return Result;
        }

        public override InteractionStepDefinitionElement VisitDeclareGiven([NotNull] DeclareGivenContext context)
        {
            Result!.Type = StepType.Given;

            VisitChildren(context);

            return Result;
        }

        public override InteractionStepDefinitionElement VisitDeclareWhen([NotNull] DeclareWhenContext context)
        {
            Result!.Type = StepType.When;

            VisitChildren(context);

            return Result;
        }

        public override InteractionStepDefinitionElement VisitDeclareThen([NotNull] DeclareThenContext context)
        {
            Result!.Type = StepType.Then;

            VisitChildren(context);

            return Result;
        }

        public override InteractionStepDefinitionElement VisitStepDeclarationBody([NotNull] StepDeclarationBodyContext context)
        {
            Result!.Declaration = context.GetText();

            VisitChildren(context);

            return Result;
        }

        /// <summary>
        /// Visits a declaration argument.
        /// </summary>
        /// <param name="context">The parser context.</param>
        /// <returns>The step definition element.</returns>
        public override InteractionStepDefinitionElement VisitDeclarationArgument([NotNull] DeclarationArgumentContext context)
        {
            Debug.Assert(Result is object);

            var content = context.stepDeclarationArgument();

            var name = content.stepDeclarationArgumentName().GetText();
            var hint = DetermineTypeHint(name, content.stepDeclarationTypeHint()?.GetText());

            var part = new ArgumentPart(context.GetText(), name, hint).AddPositionalLineInfo(context);

            AddPart(part);

            return Result;
        }

        private ArgumentType? DetermineTypeHint(string name, string? typeHint)
        {
            if (typeHint == null)
            {
                // No explicit type hint, but we might be able to take it from the name.
                typeHint = name;
            }

            return typeHint switch
            {
                "int" => ArgumentType.NumericInteger,
                "long" => ArgumentType.NumericInteger,
                "float" => ArgumentType.NumericDecimal,
                "double" => ArgumentType.NumericDecimal,
                "decimal" => ArgumentType.NumericDecimal,
                "word" => ArgumentType.Text,
                _ => null
            };
        }

        /// <summary>
        /// Visits a word declaration part.
        /// </summary>
        /// <param name="context">The partser context.</param>
        /// <returns>The step definition.</returns>
        public override InteractionStepDefinitionElement VisitDeclarationWord([NotNull] DeclarationWordContext context)
        {
            AddPart(new WordDefinitionPart(context.GetText()).AddPositionalLineInfo(context));

            return Result!;
        }

        /// <summary>
        /// Visits an escaped character part.
        /// </summary>
        /// <param name="context">The partser context.</param>
        /// <returns>The step definition.</returns>
        public override InteractionStepDefinitionElement VisitDeclarationEscaped(DeclarationEscapedContext context)
        {
            var part = new WordDefinitionPart(context.GetText()).AddPositionalLineInfo(context);

            // TODO
            // part.EscapedText = EscapeText(context, escapeReplacements);
            AddPart(part);

            return Result!;
        }

        /// <summary>
        /// Visits a colon part.
        /// </summary>
        /// <param name="context">The parser context.</param>
        /// <returns>The step definition.</returns>
        public override InteractionStepDefinitionElement VisitDeclarationColon(DeclarationColonContext context)
        {
            AddPart(new WordDefinitionPart(context.GetText()).AddPositionalLineInfo(context));

            return Result!;
        }

        private void AddPart(DefinitionPart part)
        {
            Result!.AddPart(part);
        }
    }
}