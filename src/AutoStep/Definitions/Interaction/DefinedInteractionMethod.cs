﻿using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using AutoStep.Execution.Binding;
using AutoStep.Execution.Contexts;
using AutoStep.Execution.Dependency;
using Microsoft.Extensions.DependencyInjection;

namespace AutoStep.Definitions.Interaction
{
    /// <summary>
    /// Represents an interaction method backed by a method in code.
    /// </summary>
    public abstract class DefinedInteractionMethod : InteractionMethod
    {
        private readonly MethodInfo method;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedInteractionMethod"/> class.
        /// </summary>
        /// <param name="name">The name of the method.</param>
        /// <param name="method">The method info for the method to invoke.</param>
        public DefinedInteractionMethod(string name, MethodInfo method)
            : base(name)
        {
            this.method = method;
        }

        /// <summary>
        /// Gets the number of arguments the method accepts.
        /// </summary>
        /// <remarks>All parameters accept the 'special' ones.</remarks>
        public override int ArgumentCount => method.GetParameters()
                                                   .Count(arg => !typeof(MethodContext).IsAssignableFrom(arg.ParameterType) &&
                                                                 !typeof(ILifetimeScope).IsAssignableFrom(arg.ParameterType) &&
                                                                 !typeof(CancellationToken).IsAssignableFrom(arg.ParameterType));

        /// <inheritdoc/>
        public override ValueTask InvokeAsync(ILifetimeScope scope, MethodContext context, CancellationToken cancelToken)
        {
            if (scope is null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // Bind the arguments.
            var boundArguments = BindArguments(scope, context, cancelToken);

            using var methodScope = scope.BeginContextScope(ScopeTags.MethodTag, context);

            // Get the target.
            var target = GetMethodTarget(methodScope);

            try
            {
                // Invoke.
                return InvokeInstanceMethod(target, boundArguments);
            }
            catch (TargetInvocationException invokeEx)
            {
                // Unwrap this exception.
                if (invokeEx.InnerException is object)
                {
                    ExceptionDispatchInfo.Capture(invokeEx.InnerException).Throw();
                }

                throw;
            }
        }

        /// <summary>
        /// Determines the target of the method.
        /// </summary>
        /// <param name="scope">The current scope to resolve from.</param>
        /// <returns>An instance of the method target.</returns>
        protected abstract object? GetMethodTarget(ILifetimeScope scope);

        /// <summary>
        /// Invoke an instance method, generating a task wrapper if needed.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="args">The method arguments.</param>
        /// <returns>A task that will completed when the method exits.</returns>
        private ValueTask InvokeInstanceMethod(object? target, object?[] args)
        {
            if (typeof(ValueTask).IsAssignableFrom(method.ReturnType))
            {
                return (ValueTask)method.Invoke(target, args);
            }

            if (typeof(Task).IsAssignableFrom(method.ReturnType))
            {
                // This is an async method.
                var taskResult = (Task)method.Invoke(target, args);

                // Returning task directly, we don't need to do anything else with it here.
                return new ValueTask(taskResult);
            }

            method.Invoke(target, args);
            return default;
        }

        private object?[] BindArguments(ILifetimeScope scope, MethodContext methodContext, CancellationToken cancelToken)
        {
            var methodArgs = method.GetParameters();
            var providedArgs = methodContext.Arguments;

            if (methodArgs.Length == 0)
            {
                return Array.Empty<object>();
            }

            // Get the argument bind registry.
            var binderRegistry = scope.Resolve<ArgumentBinderRegistry>();
            var bindResult = new object?[methodArgs.Length];
            var sourceArgPosition = 0;

            for (var argIdx = 0; argIdx < methodArgs.Length; argIdx++)
            {
                var arg = methodArgs[argIdx];

                if (arg.ParameterType.IsAssignableFrom(typeof(ILifetimeScope)))
                {
                    bindResult[argIdx] = scope;
                }
                else if (arg.ParameterType.IsAssignableFrom(typeof(MethodContext)))
                {
                    bindResult[argIdx] = methodContext;
                }
                else if (arg.ParameterType.IsAssignableFrom(typeof(CancellationToken)))
                {
                    bindResult[argIdx] = cancelToken;
                }
                else if (sourceArgPosition < providedArgs.Count)
                {
                    // Get the corresponding argument from the bound set.
                    var bindingArg = providedArgs[sourceArgPosition];
                    sourceArgPosition++;

                    bindResult[argIdx] = BindArgument(bindingArg, arg.ParameterType, scope, binderRegistry);
                }
            }

            return bindResult;
        }

        private object? BindArgument(object? argumentValue, Type parameterType, ILifetimeScope scope, ArgumentBinderRegistry registry)
        {
            object? result;

            if (argumentValue is null)
            {
                if (parameterType.IsValueType)
                {
                    result = Activator.CreateInstance(parameterType);
                }
                else
                {
                    result = null;
                }
            }
            else if (parameterType.IsAssignableFrom(argumentValue.GetType()))
            {
                // If assignable, just directly use the value.
                result = argumentValue;
            }
            else if (argumentValue is string strValue)
            {
                // String values should go through the argument binder.
                var binder = registry.GetBinderForType(scope, parameterType);

                try
                {
                    result = binder.Bind(strValue, parameterType);
                }
                catch (Exception ex)
                {
                    throw new ArgumentBindingException(strValue, parameterType, ex);
                }
            }
            else if (parameterType.IsValueType)
            {
                try
                {
                    // Try converting.
                    result = Convert.ChangeType(argumentValue, parameterType, CultureInfo.CurrentCulture);
                }
                catch (Exception ex)
                {
                    // Cannot use the value.
                    throw new InvalidCastException(DefinitionsMessages.DefinedInteractionMethod_CannotConvertArgument.FormatWith(argumentValue.ToString(), Name, parameterType.Name), ex);
                }
            }
            else
            {
                // Cannot directly use this value. Throw.
                throw new InvalidCastException(DefinitionsMessages.DefinedInteractionMethod_CannotCastArgument.FormatWith(argumentValue.ToString(), Name, parameterType.Name));
            }

            return result;
        }
    }
}
