using System;
using System.ServiceModel;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace WindowsyProjekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, config) =>
                {
                    string applicationInsightsKey =
                        hostingContext.Configuration["ApplicationInsights:InstrumentationKey"];
                    config.AddApplicationInsights(applicationInsightsKey);
                    // Logger will log LogLevel Information or above to be sent to Application Insights for all categories.
                    config.AddFilter<ApplicationInsightsLoggerProvider>(string.Empty, LogLevel.Information);
                });
    }
}
