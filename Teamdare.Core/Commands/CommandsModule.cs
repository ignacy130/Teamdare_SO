using System;
using Autofac;

namespace Teamdare.Core.Commands
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes()
                .Where(t => t.IsAssignableTo<ICommand>())
                .AsImplementedInterfaces();


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
        }
    }
}