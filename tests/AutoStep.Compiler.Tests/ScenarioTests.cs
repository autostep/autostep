﻿using AutoStep.Compiler.Tests.Utils;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AutoStep.Compiler.Tests
{
    public class ScenarioTests : CompilerTestBase
    {
        public ScenarioTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task ScenarioCanHaveNoSteps()
        {
            const string TestFile = 
            @"                
              Feature: My Feature
                
                Scenario: My Scenario

            ";

            await CompileAndAssertSuccess(TestFile, file => file
                .Feature("My Feature", 2, 15, feat => feat
                    .Scenario("My Scenario", 4, 17)
                )
            );
        }

        [Fact]
        public async Task BadScenarioTokenSyntaxError()
        {
            const string TestFile =
            @"                
              Feature: My Feature
                Description words

                ScenariO: My Scenario

            ";

            await CompileAndAssertErrors(TestFile,
                new CompilerMessage(
                    null,
                    CompilerMessageLevel.Error,
                    CompilerMessageCode.InvalidScenarioKeyword,
                    "The 'Scenario' keyword is case-sensitive, so 'ScenariO:' should be 'Scenario:'",
                    startLineNo: 5,
                    startColumn: 17,
                    endLineNo: 5,
                    endColumn: 25
                ),
                new CompilerMessage(
                    null,
                    CompilerMessageLevel.Warning,
                    CompilerMessageCode.NoScenarios,
                    "Your Feature 'My Feature' has no Scenarios, so will not run any tests.",
                    startLineNo: 2,
                    startColumn: 15,
                    endLineNo: 2,
                    endColumn: 33
                )
            );
        }
    }
}
