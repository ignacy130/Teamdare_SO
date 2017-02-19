using System;
using Autofac;

namespace Teamdare.Core.Queries
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes()
                .Where(t => t.IsAssignableTo<IQuery>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, IQuery>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof (IQuery<>).MakeGenericType(t);
                    return (IQuery) ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<QueryBus>()
                .AsImplementedInterfaces();
        }
    }
}