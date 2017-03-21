using Autofac;
using Teamdare.Connector.Authentication;

namespace Teamdare.Connector
{
    public class ConnectorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<BotCredentials>().As<BotCredentials>();
            builder.RegisterType<BotConnector>().As<BotConnector>();
        }
    }
}