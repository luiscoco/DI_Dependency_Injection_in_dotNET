using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Dependency_Injection_in_dotNET
{
    // Services

    public interface IWeatherService
    {
        string GetWeather();
    }

    public class WeatherService : IWeatherService
    {
        public string GetWeather()
        {
            return "It's sunny today!";
        }
    }

    public interface IOutputService
    {
        void Write(string message);
    }

    public class ConsoleOutputService : IOutputService
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Application

    public class WeatherReporter
    {
        private readonly IWeatherService _weatherService;
        private readonly IOutputService _outputService;

        public WeatherReporter(IWeatherService weatherService, IOutputService outputService)
        {
            _weatherService = weatherService;
            _outputService = outputService;
        }

        public void ReportWeather()
        {
            var weather = _weatherService.GetWeather();
            _outputService.Write(weather);
        }
    }
}
