﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoStep.Execution.Dependency;

namespace AutoStep.Execution.Binding
{
    internal class DefaultArgumentBinder : IArgumentBinder
    {

    }

    public class ArgumentBinderRegistry
    {
        private Dictionary<Type, Type> binders = new Dictionary<Type, Type>();

        private IArgumentBinder defaultBinder = new DefaultArgumentBinder();

        public void RegisterArgumentBinder<TBinder>(Type argumentType)
        {

        }

        public IArgumentBinder GetBinderForType(IServiceScope scope, Type parameterType)
        {
            if (scope is null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (binders.TryGetValue(parameterType, out var binder))
            {
                return scope.Resolve<IArgumentBinder>(binder);
            }

            return defaultBinder;
        }
    }
}
