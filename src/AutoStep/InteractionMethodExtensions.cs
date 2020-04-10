//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoStep
{
    using System;
    using System.Threading.Tasks;
    using AutoStep.Definitions.Interaction;
    using AutoStep.Execution.Interaction;
    using AutoStep.Language.Interaction;
    
    
    /// <summary>
    /// Defines extension methods for registering interaction methods.
    /// This class is automatically generated - do not modify directly.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("ExtensionMethodGenerator", "1.0")]
    public static class InteractionMethodExtensions
    {
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// </summary>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod(this IInteractionsConfiguration interactionsConfig, string methodName, Action callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// </summary>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod(this IInteractionsConfiguration interactionsConfig, string methodName, Func<ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2, T3> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, T3, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2, T3, T4> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, T3, T4, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2, T3, T4, T5> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, T3, T4, T5, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2, T3, T4, T5, T6> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, T3, T4, T5, T6, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <typeparam name="T7">Method argument type 7.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6, T7>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2, T3, T4, T5, T6, T7> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <typeparam name="T7">Method argument type 7.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6, T7>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, T3, T4, T5, T6, T7, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <typeparam name="T7">Method argument type 7.</typeparam>
        /// <typeparam name="T8">Method argument type 8.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6, T7, T8>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2, T3, T4, T5, T6, T7, T8> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <typeparam name="T7">Method argument type 7.</typeparam>
        /// <typeparam name="T8">Method argument type 8.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6, T7, T8>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, T3, T4, T5, T6, T7, T8, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <typeparam name="T7">Method argument type 7.</typeparam>
        /// <typeparam name="T8">Method argument type 8.</typeparam>
        /// <typeparam name="T9">Method argument type 9.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <typeparam name="T7">Method argument type 7.</typeparam>
        /// <typeparam name="T8">Method argument type 8.</typeparam>
        /// <typeparam name="T9">Method argument type 9.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <typeparam name="T7">Method argument type 7.</typeparam>
        /// <typeparam name="T8">Method argument type 8.</typeparam>
        /// <typeparam name="T9">Method argument type 9.</typeparam>
        /// <typeparam name="T10">Method argument type 10.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IInteractionsConfiguration interactionsConfig, string methodName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
        
        /// <summary>
        /// Register an interaction method, with a callback to be invoked when
        /// that method is used in a test.
        /// Type parameters for the callback are the type of values to bind interaction arguments to.
        /// A type argument of <see cref="IServiceProvider" /> will cause the current scope to be injected into the method; a type argument of <see cref="MethodContext" /> will receive the current interaction method context.
        /// </summary>
        /// <typeparam name="T1">Method argument type 1.</typeparam>
        /// <typeparam name="T2">Method argument type 2.</typeparam>
        /// <typeparam name="T3">Method argument type 3.</typeparam>
        /// <typeparam name="T4">Method argument type 4.</typeparam>
        /// <typeparam name="T5">Method argument type 5.</typeparam>
        /// <typeparam name="T6">Method argument type 6.</typeparam>
        /// <typeparam name="T7">Method argument type 7.</typeparam>
        /// <typeparam name="T8">Method argument type 8.</typeparam>
        /// <typeparam name="T9">Method argument type 9.</typeparam>
        /// <typeparam name="T10">Method argument type 10.</typeparam>
        /// <param name="interactionsConfig">The interactions configuration to add a method to.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to invoke when the step executes.</param>
        public static void AddOrReplaceMethod<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IInteractionsConfiguration interactionsConfig, string methodName, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, ValueTask> callback)
        {
            callback = callback.ThrowIfNull(nameof(callback));
            interactionsConfig = interactionsConfig.ThrowIfNull(nameof(interactionsConfig));
            interactionsConfig.AddOrReplaceMethod(new DelegateInteractionMethod(methodName, callback));
        }
    }
}
