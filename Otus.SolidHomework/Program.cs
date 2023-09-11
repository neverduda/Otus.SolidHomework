using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Otus.SolidHomework.Implementations;
using Otus.SolidHomework.Interfaces;

namespace Otus.SolidHomework
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }


        static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder();
            hostBuilder.ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: true);
            })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<Settings>(options => hostContext.Configuration.Bind(options));
                    services.AddTransient<IGame, GuessNumberGame>();
                    services.AddTransient<IHiddenNumberService, RandomNumberService>();
                    services.AddTransient<IComparator<int>, NumberComparator>();

                    services.AddHostedService<GameHostedService>();

                });
            return hostBuilder;
        }
    }
}