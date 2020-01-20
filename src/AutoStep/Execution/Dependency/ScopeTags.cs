﻿using System;
using Autofac;
using AutoStep.Execution.Dependency;

namespace AutoStep.Execution
{
    internal class ScopeTags
    {
        public const string Root = "__asRoot";
        public const string RunTag = "__asRun";
        public const string ThreadTag = "__asThread";
        public const string FeatureTag = "__asFeature";
        public const string ScenarioTag = "__asScenario";
        public const string StepTag = "__asStep";
    }
}