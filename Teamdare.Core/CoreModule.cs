using System;
using System.Collections.Generic;
using Autofac;
using Teamdare.Core.Commands;
using Teamdare.Core.Events;
using Teamdare.Core.Queries;

namespace Teamdare.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DateTimeGetter>().As<IDateTimeGetter>();
            builder.RegisterType<Assistant>().As<IAssistant>();

            builder.Register<Func<Type, ICommand>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof (ICommand<>).MakeGenericType(t);
                    return (ICommand) ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<CommandBus>()
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