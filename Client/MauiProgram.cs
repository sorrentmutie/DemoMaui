using Microsoft.Extensions.Logging;
using DemoMaui.ViewModels;
using DemoMaui.RazorClassLibrary.Models;
using DemoMaui.RazorClassLibrary.Data;
using Microsoft.Extensions.Configuration;

namespace DemoMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		//var configurationBuilder = new ConfigurationBuilder()
		//	.AddJsonFile("appsettings.json", optional:false, reloadOnChange: true);
		//var configuration = configurationBuilder.Build();


		//builder.Configuration.AddConfiguration(configuration);
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<SharedState>();
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
