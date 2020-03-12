﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoStep.Language {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CompilerMessageCodeText {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CompilerMessageCodeText() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AutoStep.Language.CompilerMessageCodeText", typeof(CompilerMessageCodeText).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An &apos;And&apos; statement must be preceded by a &apos;Given&apos;, &apos;When&apos; or &apos;Then&apos;..
        /// </summary>
        internal static string AndMustFollowNormalStep {
            get {
                return ResourceManager.GetString("AndMustFollowNormalStep", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quoted argument has not been closed..
        /// </summary>
        internal static string ArgumentHasNotBeenClosed {
            get {
                return ResourceManager.GetString("ArgumentHasNotBeenClosed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot use a value of type {0} for an argument declared as a {1}..
        /// </summary>
        internal static string ArgumentTypeNotCompatible {
            get {
                return ResourceManager.GetString("ArgumentTypeNotCompatible", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bad option format. Option must the format &apos;$optionName&apos;, optionally with a value separated by &apos;:&apos;, e.g. &apos;$optionName:value&apos;..
        /// </summary>
        internal static string BadOptionFormat {
            get {
                return ResourceManager.GetString("BadOptionFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bad tag format. Tag must have the format &apos;@tagName&apos;..
        /// </summary>
        internal static string BadTagFormat {
            get {
                return ResourceManager.GetString("BadTagFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You cannot use &apos;{0}&apos; as a Step Parameter. Step Parameter variables must be literal names, e.g. &apos;variable1&apos; or &apos;total&apos;. You cannot specify dynamic values..
        /// </summary>
        internal static string CannotSpecifyDynamicValueInStepDefinition {
            get {
                return ResourceManager.GetString("CannotSpecifyDynamicValueInStepDefinition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This scenario name, &apos;{0}&apos;, has already been used in this feature. Scenario names must be unique within a feature..
        /// </summary>
        internal static string DuplicateScenarioNames {
            get {
                return ResourceManager.GetString("DuplicateScenarioNames", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Examples blocks must contain a table..
        /// </summary>
        internal static string ExamplesBlockRequiresTable {
            get {
                return ResourceManager.GetString("ExamplesBlockRequiresTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have specified an Example variable to insert, &apos;{0}&apos;, but the step is in a Scenario; did you mean to use a Scenario Outline instead?.
        /// </summary>
        internal static string ExampleVariableInScenario {
            get {
                return ResourceManager.GetString("ExampleVariableInScenario", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have specified an Example variable to insert, &apos;{0}&apos;, but you have not declared the variable in any of your Examples. This value will always be blank when the test runs..
        /// </summary>
        internal static string ExampleVariableNotDeclared {
            get {
                return ResourceManager.GetString("ExampleVariableNotDeclared", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Detected a circular component inheritance loop; loop path is {0}..
        /// </summary>
        internal static string InteractionComponentInheritanceLoop {
            get {
                return ResourceManager.GetString("InteractionComponentInheritanceLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified component to inherit from, {0}, cannot be found. Does this component exist?.
        /// </summary>
        internal static string InteractionComponentInheritedComponentNotFound {
            get {
                return ResourceManager.GetString("InteractionComponentInheritedComponentNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Interaction Step Definitions inside components cannot have $component$ markers; these are reserved for Trait steps..
        /// </summary>
        internal static string InteractionComponentStepDefinitionCannotHaveComponentMarker {
            get {
                return ResourceManager.GetString("InteractionComponentStepDefinitionCannotHaveComponentMarker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} constant is not defined..
        /// </summary>
        internal static string InteractionConstantNotDefined {
            get {
                return ResourceManager.GetString("InteractionConstantNotDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Duplicate trait specified..
        /// </summary>
        internal static string InteractionDuplicateTrait {
            get {
                return ResourceManager.GetString("InteractionDuplicateTrait", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid character(s)..
        /// </summary>
        internal static string InteractionInvalidContent {
            get {
                return ResourceManager.GetString("InteractionInvalidContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The method being called requires {0} argument(s), but you are only providing {1}..
        /// </summary>
        internal static string InteractionMethodArgumentMismatch {
            get {
                return ResourceManager.GetString("InteractionMethodArgumentMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method call appears to be missing a parameter separator, are you missing a comma?.
        /// </summary>
        internal static string InteractionMethodCallMissingParameterSeparator {
            get {
                return ResourceManager.GetString("InteractionMethodCallMissingParameterSeparator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing call separator &apos;-&gt;&apos;..
        /// </summary>
        internal static string InteractionMethodCallMissingSeparator {
            get {
                return ResourceManager.GetString("InteractionMethodCallMissingSeparator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method call has not been closed, expecting &apos;)&apos;..
        /// </summary>
        internal static string InteractionMethodCallUnterminated {
            get {
                return ResourceManager.GetString("InteractionMethodCallUnterminated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An interaction method cannot call itself..
        /// </summary>
        internal static string InteractionMethodCircularReference {
            get {
                return ResourceManager.GetString("InteractionMethodCircularReference", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method declaration expects another parameter; do you have an unintended extra comma in your declaration list?.
        /// </summary>
        internal static string InteractionMethodDeclMissingParameter {
            get {
                return ResourceManager.GetString("InteractionMethodDeclMissingParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method declaration appears to be missing a parameter separator, are you missing a comma?.
        /// </summary>
        internal static string InteractionMethodDeclMissingParameterSeparator {
            get {
                return ResourceManager.GetString("InteractionMethodDeclMissingParameterSeparator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method declaration contains unexpected content. Method declarations should consist of zero or more parameter names only, e.g. method(), method(param1), method(param1, param2)..
        /// </summary>
        internal static string InteractionMethodDeclUnexpectedContent {
            get {
                return ResourceManager.GetString("InteractionMethodDeclUnexpectedContent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method declaration has not been closed, expecting &apos;)&apos;..
        /// </summary>
        internal static string InteractionMethodDeclUnterminated {
            get {
                return ResourceManager.GetString("InteractionMethodDeclUnterminated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Component is missing definition for required method &apos;{0}&apos;, declared in {1}:{2}..
        /// </summary>
        internal static string InteractionMethodFromTraitRequiredButNotDefined {
            get {
                return ResourceManager.GetString("InteractionMethodFromTraitRequiredButNotDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Interaction methods require parentheses; e.g. myMethod(), or myMethod(arg1, arg2)..
        /// </summary>
        internal static string InteractionMethodNeedsParentheses {
            get {
                return ResourceManager.GetString("InteractionMethodNeedsParentheses", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified interaction method &apos;{0}&apos; is not available. It must be declared with an associated expression, e.g. &apos;{0}: method()&apos;..
        /// </summary>
        internal static string InteractionMethodNotAvailable {
            get {
                return ResourceManager.GetString("InteractionMethodNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified interaction method &apos;{0}&apos; is not available. It should be either be declared with an associated expression, or with &apos;needs-defining&apos;. E.g. &apos;{0}: method()&apos; or &apos;{0}: needs-defining&apos;..
        /// </summary>
        internal static string InteractionMethodNotAvailablePermitUndefined {
            get {
                return ResourceManager.GetString("InteractionMethodNotAvailablePermitUndefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method needs to be defined; declared at {0}:L{1}..
        /// </summary>
        internal static string InteractionMethodRequiredButNotDefined {
            get {
                return ResourceManager.GetString("InteractionMethodRequiredButNotDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A name is required..
        /// </summary>
        internal static string InteractionMissingExpectedName {
            get {
                return ResourceManager.GetString("InteractionMissingExpectedName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Interaction Step Declaration is missing the declaration text..
        /// </summary>
        internal static string InteractionMissingStepDeclaration {
            get {
                return ResourceManager.GetString("InteractionMissingStepDeclaration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A name has already been provided for this entity..
        /// </summary>
        internal static string InteractionNameAlreadySet {
            get {
                return ResourceManager.GetString("InteractionNameAlreadySet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Interaction Step Definitions inside traits must contain at least one $component$ marker, so that the component can be identified..
        /// </summary>
        internal static string InteractionTraitStepDefinitionMustHaveComponent {
            get {
                return ResourceManager.GetString("InteractionTraitStepDefinitionMustHaveComponent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unterminated string..
        /// </summary>
        internal static string InteractionUnterminatedString {
            get {
                return ResourceManager.GetString("InteractionUnterminatedString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} variable is not a collection, so you cannot access it as one..
        /// </summary>
        internal static string InteractionVariableNotAnArray {
            get {
                return ResourceManager.GetString("InteractionVariableNotAnArray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} variable is not defined..
        /// </summary>
        internal static string InteractionVariableNotDefined {
            get {
                return ResourceManager.GetString("InteractionVariableNotDefined", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Examples&apos; keyword is case-sensitive, so &apos;{0}&apos; should be &apos;Examples:&apos;.
        /// </summary>
        internal static string InvalidExamplesKeyword {
            get {
                return ResourceManager.GetString("InvalidExamplesKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Feature&apos; keyword is case-sensitive, so &apos;{0}&apos; should be &apos;Feature:&apos;.
        /// </summary>
        internal static string InvalidFeatureKeyword {
            get {
                return ResourceManager.GetString("InvalidFeatureKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Scenario&apos; keyword is case-sensitive, so &apos;{0}&apos; should be &apos;Scenario:&apos;.
        /// </summary>
        internal static string InvalidScenarioKeyword {
            get {
                return ResourceManager.GetString("InvalidScenarioKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The &apos;Scenario Outline&apos; phrase is case-sensitive, so &apos;{0}&apos; should be &apos;Scenario Outline:&apos;.
        /// </summary>
        internal static string InvalidScenarioOutlineKeyword {
            get {
                return ResourceManager.GetString("InvalidScenarioOutlineKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A custom step cannot be defined using &apos;{0}&apos;. You must use Given, When or Then..
        /// </summary>
        internal static string InvalidStepDefineKeyword {
            get {
                return ResourceManager.GetString("InvalidStepDefineKeyword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File access error: {0}.
        /// </summary>
        internal static string IOException {
            get {
                return ResourceManager.GetString("IOException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are multiple matching step definitions that match this step..
        /// </summary>
        internal static string LinkerMultipleMatchingDefinitions {
            get {
                return ResourceManager.GetString("LinkerMultipleMatchingDefinitions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No step definitions could be found that match this step..
        /// </summary>
        internal static string LinkerNoMatchingStepDefinition {
            get {
                return ResourceManager.GetString("LinkerNoMatchingStepDefinition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Features must have a title..
        /// </summary>
        internal static string NoFeatureTitleProvided {
            get {
                return ResourceManager.GetString("NoFeatureTitleProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scenario Outlines must have a title..
        /// </summary>
        internal static string NoScenarioOutlineTitleProvided {
            get {
                return ResourceManager.GetString("NoScenarioOutlineTitleProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your Feature &apos;{0}&apos; has no Scenarios, so will not run any tests..
        /// </summary>
        internal static string NoScenarios {
            get {
                return ResourceManager.GetString("NoScenarios", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scenarios must have a title..
        /// </summary>
        internal static string NoScenarioTitleProvided {
            get {
                return ResourceManager.GetString("NoScenarioTitleProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not expecting an Examples block here; did you mean to define &apos;{0}&apos; as a Scenario Outline rather than a Scenario?.
        /// </summary>
        internal static string NotExpectingExample {
            get {
                return ResourceManager.GetString("NotExpectingExample", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can only have one Feature per file. Create a new file for this Feature..
        /// </summary>
        internal static string OnlyOneFeatureAllowed {
            get {
                return ResourceManager.GetString("OnlyOneFeatureAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provided Option &apos;{0}&apos; has a setting value marker &apos;:&apos;, but no value has been provided..
        /// </summary>
        internal static string OptionWithNoSetting {
            get {
                return ResourceManager.GetString("OptionWithNoSetting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Step is not expected here..
        /// </summary>
        internal static string StepNotExpected {
            get {
                return ResourceManager.GetString("StepNotExpected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Extraneous whitespace detected in Step Parameter variable name. You cannot have extra whitespace at the start or end of a Step Parameter variable name..
        /// </summary>
        internal static string StepVariableInvalidWhitespace {
            get {
                return ResourceManager.GetString("StepVariableInvalidWhitespace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You cannot specify an Empty Parameter as a Step Parameter. Step Parameter variables must be literal names, e.g. {variable1} or {total}..
        /// </summary>
        internal static string StepVariableNameRequired {
            get {
                return ResourceManager.GetString("StepVariableNameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have specified a Step parameter variable to insert, &apos;{0}&apos;, but you have not declared the variable in the step declaration. This value will always be blank when the test runs..
        /// </summary>
        internal static string StepVariableNotDeclared {
            get {
                return ResourceManager.GetString("StepVariableNotDeclared", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Syntax Error: {0}.
        /// </summary>
        internal static string SyntaxError {
            get {
                return ResourceManager.GetString("SyntaxError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The row contains {0} cell(s), but we are expecting {1}, because of the number of headers..
        /// </summary>
        internal static string TableColumnsMismatch {
            get {
                return ResourceManager.GetString("TableColumnsMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Table cell has not been terminated. Expecting a table delimiter character &apos;|&apos;..
        /// </summary>
        internal static string TableRowHasNotBeenTerminated {
            get {
                return ResourceManager.GetString("TableRowHasNotBeenTerminated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The step definition requires a type of {0} for this argument, but no value has been provided..
        /// </summary>
        internal static string TypeRequiresValueForArgument {
            get {
                return ResourceManager.GetString("TypeRequiresValueForArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Internal Error: {0}.
        /// </summary>
        internal static string UncategorisedException {
            get {
                return ResourceManager.GetString("UncategorisedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not expecting an annotation at this position..
        /// </summary>
        internal static string UnexpectedAnnotation {
            get {
                return ResourceManager.GetString("UnexpectedAnnotation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected end of file..
        /// </summary>
        internal static string UnexpectedEndOfFile {
            get {
                return ResourceManager.GetString("UnexpectedEndOfFile", resourceCulture);
            }
        }
    }
}
