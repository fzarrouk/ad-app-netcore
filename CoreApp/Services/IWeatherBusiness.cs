using CoreApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface IWeatherBusiness
    {
        public IEnumerable<WeatherForecast> GetWeatherForcast();
    }
}
