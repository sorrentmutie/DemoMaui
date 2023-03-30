using DemoMaui.RazorClassLibrary.Data;
using DemoMaui.RazorClassLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var sharedState = App.AppHost?.Services.GetRequiredService<SharedState>();
            var weatherService = App.AppHost?.Services.GetRequiredService<WeatherForecastService>();

            //var configurationBuilder = new ConfigurationBuilder()
            //  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            //var configuration = configurationBuilder.Build();


            InitializeComponent();
            var serviceCollection = new ServiceCollection();
            if(sharedState != null && weatherService != null )
            {
                serviceCollection.AddSingleton(sharedState);
                serviceCollection.AddSingleton(weatherService);
            }
            serviceCollection.AddWpfBlazorWebView();
            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
