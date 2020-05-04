using CoreApp.Configuration;
using CoreApp.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class WeatherServiceImp : IWeatherService
    {
        private readonly IWeatherDao _weatherDao;
        private readonly ApplicationConfig _applicationConfig;
        private readonly ILogger<WeatherServiceImp> _logger;
        private readonly IConfiguration _config;
        private object p;
        private IWeatherDao object1;
        private IOptionsMonitor<ApplicationConfig> object2;

        public WeatherServiceImp(ILogger<WeatherServiceImp> logger, IWeatherDao weatherDao, IOptionsMonitor<ApplicationConfig> applicationConfig, IConfiguration config)
        {
            _logger = logger;
            _weatherDao = weatherDao;
            _applicationConfig = applicationConfig.CurrentValue;
            _config = config;
        }

        public string this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public string GetDbConnexionName()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WeatherForecast> GetWeatherForcast()
        {
            _logger.LogInformation("Log From Service", new object[] { new object() });

            // throw new ArgumentException(
            //$"We don't offer a weather forecast for");//xsssss
            var switchs = _config.GetSection("FeatureSwitches");
            var report = switchs.GetChildren().Select(x => $"{x.Key} : {x.Value}");

            var appName = _applicationConfig.Name;
            var ver = _applicationConfig.Version;
            var author = _applicationConfig.AppAuthor;

            var summaries = _weatherDao.GetSummaries();
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Count)]
            });
        }
    }
}
