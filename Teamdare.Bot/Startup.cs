using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Teamdare.Core;
using Teamdare.Database;
using Teamdare.Domain;
using Hangfire;
using Teamdare.Worker.WorkerFunctions.Hourly;
using Hangfire.MemoryStorage;
using Teamdare.Connector;
using Teamdare.Worker;

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


            var connectionString = Configuration["DbContextSettings:ConnectionString"];

            services.AddDbContext<TeamdareContext>(opts => opts.UseNpgsql(connectionString), ServiceLifetime.Transient);
            services.AddHangfire(x => x.UseMemoryStorage());



            return ConfigureIoC(services);
        }

        private IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<WebModule>();
            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<DatabaseModule>();
            builder.RegisterModule<WorkerModule>();
            builder.RegisterModule<ConnectorModule>();

            builder.Populate(services);

            var container = builder.Build();

            IoC.Initialize(container);

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            var taskReminder = IoC.Resolve<TaskReminder>();

            RecurringJob.AddOrUpdate(
                () => taskReminder.Execute(), Cron.MinuteInterval(1));
                
            app.UseMvc();
        }
    }
}