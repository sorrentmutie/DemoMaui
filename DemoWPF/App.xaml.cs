using DemoMaui.RazorClassLibrary.Data;
using DemoMaui.RazorClassLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = configurationBuilder.Build();




            AppHost = Host.CreateDefaultBuilder()
               
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<SharedState>();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<WeatherForecastService>();

                }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if(AppHost != null)
            {
                var startupWindow = AppHost.Services.GetRequiredService<MainWindow>();
                startupWindow.Show();
            }
        }
    }
}
