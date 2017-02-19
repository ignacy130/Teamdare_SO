using Autofac;
using Teamdare.Core.Commands;
using Teamdare.Core.Events;
using Teamdare.Core.Queries;
using Module = Autofac.Module;

namespace Teamdare.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsAssignableTo<ICommand>())
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsAssignableTo<IEvent>())
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.IsAssignableTo<IQuery>())
                .AsImplementedInterfaces();
        }
    }
}