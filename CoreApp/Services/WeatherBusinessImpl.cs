using CoreApp.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class WeatherBusinessImpl: IWeatherBusiness
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherBusinessImpl> _logger;

        public WeatherBusinessImpl(ILogger<WeatherBusinessImpl> logger, IWeatherService weatherService)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        public IEnumerable<WeatherForecast> GetWeatherForcast()
        {
            var items = _weatherService.GetWeatherForcast();
            _logger.LogInformation($"_weatherService {_weatherService.GetHashCode()}", new object[] { new object() });
            return items;
        }
    }
}
