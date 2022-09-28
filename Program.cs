using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Result11Bot.Controllers;
using VoiceTexterBot;

namespace Result11Bot
{
    internal class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Сервис запущен");

            await host.RunAsync();

            Console.WriteLine("Сервис остановлен");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<TextMessageController>();


            services.AddTransient<InlineKeyboardController>();

            services.AddSingleton<ITelegramBotClient>(provider =>
                new TelegramBotClient("5545468283:AAE0mcsakYZq0scMFSbSYZWKWr68Bkdnh5M"));

            services.AddHostedService<Bot>();
        }
    }
}