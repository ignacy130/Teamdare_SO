using System;
using Autofac;

namespace Teamdare.Core
{
    public static class IoC
    {
        private static IContainer _container;

        public static void Initialize(IContainer _autofacContainer)
        {
            _container = _autofacContainer;
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public static object Resolve(Type service)
        {
            return _container.Resolve(service);
        }
    }
}