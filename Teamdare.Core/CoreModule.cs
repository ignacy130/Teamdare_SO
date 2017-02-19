using Autofac;

namespace Teamdare.Core
{
    public class CoreModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeGetter>().As<IDateTimeGetter>();
            builder.RegisterType<Assistant>().As<IAssistant>();
        }
    }
}