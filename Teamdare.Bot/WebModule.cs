using System.Reflection;
using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Teamdare.Bot.Authentication;
using Teamdare.Bot.Communications;
using Teamdare.Bot.Communications.Channels;
using Module = Autofac.Module;

namespace Teamdare.Bot
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Responses>().As<Responses>();
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().SingleInstance();
            builder.RegisterType<CommunicationChannel>().As<CommunicationChannel>();
            builder.RegisterType<CommunicationChannelMap>().As<CommunicationChannelMap>();
            builder.RegisterType<BotCredentials>().As<BotCredentials>();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .Where(t => t.IsAssignableTo<IChannel>())
                .AsSelf();
        }
    }
}