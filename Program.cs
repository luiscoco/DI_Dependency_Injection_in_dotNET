using Microsoft.Extensions.DependencyInjection;
using System;
using DI_Dependency_Injection_in_dotNET;

public class Program
{
    public static void Main(string[] args)
    {
        // Step 1: Create a service collection
        var services = new ServiceCollection();

        // Step 2: Register services
        services.AddTransient<IWeatherService, WeatherService>();
        services.AddSingleton<IOutputService, ConsoleOutputService>();
        services.AddScoped<WeatherReporter>();

        // Step 3: Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        // Step 4: Resolve and use services
        var weatherReporter = serviceProvider.GetRequiredService<WeatherReporter>();
        weatherReporter.ReportWeather();

        // Dispose of the service provider when done
        serviceProvider.Dispose();
    }
}