using FoodieCommunityCase.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogWeb.Classic.Enrichers;
using System;

namespace FoodieCommunityCase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var applicationName = "Carwash";
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown";

                Log.Logger = new LoggerConfiguration()
#if DEBUG
                    .MinimumLevel.Debug()
#else
                    .MinimumLevel.Information()
#endif
                    .Enrich.WithMachineName()
                    .Enrich.With<HttpRequestIdEnricher>()
                    .Enrich.With<HttpRequestRawUrlEnricher>()
                    .Enrich.With<HttpRequestTypeEnricher>()
                    .Enrich.With<HttpRequestUrlReferrerEnricher>()
                    .Enrich.With<HttpRequestUrlEnricher>()
                    .Enrich.With<HttpRequestUserAgentEnricher>()
                    .Enrich.With<UserNameEnricher>()
                    .Enrich.WithProperty("ApplicationName", applicationName)
                    .Enrich.WithProperty("EnvironmentName", environmentName)
                    .WriteTo.Console()
                    .CreateLogger();

                IHost host = CreateHostBuilder(args).Build();

                CreateDbIfNotExists(host);

                host.Run();
            }
            catch (Exception ex)
            {
                if (Log.Logger == null || Log.Logger.GetType().Name == "SilentLogger")
                {
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console()
                        .CreateLogger();
                }

                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            IServiceProvider services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<FoodEntities>();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .CaptureStartupErrors(true);
                })
                .UseSerilog();
        }
    }
}
