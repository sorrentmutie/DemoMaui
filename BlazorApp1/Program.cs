
using DemoMaui.RazorClassLibrary;
using DemoMaui.RazorClassLibrary.Data;
using DemoMaui.RazorClassLibrary.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<SharedState>();
builder.Services.AddSingleton<WeatherForecastService>();

await builder.Build().RunAsync();
