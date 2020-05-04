using CoreApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class WeatherServiceImpAsync : IWeatherServiceAsync
    {
        private readonly IWeatherDao _weatherDao;

        public WeatherServiceImpAsync(IWeatherDao weatherDao)
        {
            _weatherDao = weatherDao;
        }

        

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForcast()
        {
            var client = new HttpClient();

            var getStringTask = await client.GetStringAsync("https://docs.microsoft.com/dotnet");

            var weatherForecasts = new List<WeatherForecast>();

            weatherForecasts.Add(new WeatherForecast()
            {
                Summary = "Ete",
                Date = DateTime.Now,
                TemperatureC = 23
            }) ;

            return weatherForecasts;

        }
    }
}
