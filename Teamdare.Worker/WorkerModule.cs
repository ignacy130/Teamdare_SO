using Autofac;
using Teamdare.Worker.WorkerFunctions.Hourly;

namespace Teamdare.Worker
{
    public class WorkerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<TaskReminder>().As<TaskReminder>();
        }
    }
}