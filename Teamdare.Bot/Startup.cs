using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Teamdare.Bot.Communications;
using Teamdare.Bot.Communications.Channels;
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
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Adding options so we can inject configurations.
            services.AddOptions();

            services.AddMvc();

            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddDbContext<TeamdareContext>(opts => opts.UseNpgsql(connectionString));

            //services - refactoring
            services.AddTransient<Responses>();
            services.AddTransient<CommunicationChannel>();
            services.AddTransient<CommunicationChannelMap>();
            services.AddTransient<ConversationUpdatesChannel>();
            services.AddTransient<MessagesChannel>();
            services.AddTransient<SystemMessagesChannel>();
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