﻿using System.Threading;
using System.Threading.Tasks;
using Autofac;
using AutoStep.Execution.Contexts;
using AutoStep.Execution.Dependency;

namespace AutoStep.Execution.Strategy
{
    /// <summary>
    /// Defines the interface for a step execution strategy, that controls the behaviour of executing a single step.
    /// </summary>
    public interface IStepExecutionStrategy
    {
        /// <summary>
        /// Execute the strategy.
        /// </summary>
        /// <param name="stepScope">The step scope.</param>
        /// <param name="context">The step context.</param>
        /// <param name="variables">The set of variables currently in-scope.</param>
        /// <param name="cancelToken">Cancellation token for the step.</param>
        /// <returns>A task that should complete when the step has finished executing.</returns>
        ValueTask ExecuteStepAsync(
            ILifetimeScope stepScope,
            StepContext context,
            VariableSet variables,
            CancellationToken cancelToken);
    }
}
