using System;
using System.Collections.Generic;
using Autofac;

namespace Teamdare.Core.Events
{
    public class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /*builder.RegisterAssemblyTypes()
                .Where(t => t.IsAssignableTo<IEvent>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, IEnumerable<IEvent>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(IEvent<>).MakeGenericType(t);
                    var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                    return (IEnumerable<IEvent>)ctx.Resolve(handlersCollectionType);
                };
            });

            builder.RegisterType<EventBus>()
                .AsImplementedInterfaces();*/
        }

    }
}