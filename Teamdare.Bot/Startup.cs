using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;
using Teamdare.Bot.Communications;
using Teamdare.Bot.Communications.Channels;
using Teamdare.Core;
using Teamdare.Database;

namespace Teamdare.Bot
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Adding options so we can inject configurations.
            services.AddOptions();

            services.AddMvc();

            return ConfigureIoC(services);
        }

        private IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.TheCallingAssembly();
                    _.AddAllTypesOf<IChannel>();
                    _.WithDefaultConventions();
                });

                config.For<TeamdareContext>()
                    .Use<TeamdareContext>()
                    .Ctor<string>()
                    .Is(Configuration["DbContextSettings:ConnectionString"]);

                config.For<Responses>().Use<Responses>();
                config.For<CommunicationChannel>().Use<CommunicationChannel>();
                config.For<CommunicationChannelMap>().Use<CommunicationChannelMap>();
                config.For<IDateTimeGetter>().Use<DateTimeGetter>();
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}