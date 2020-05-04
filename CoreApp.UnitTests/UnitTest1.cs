using CoreApp.Configuration;
using CoreApp.Controllers;
using CoreApp.Repository;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CoreApp.UnitTests
{

    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            //ILogger<WeatherForecastController> logger, IWeatherServiceAsync weatherServiceAsync, IWeatherService weatherService
            // IWeatherDao weatherDao, IOptionsMonitor<ApplicationConfig> applicationConfig
            Mock<IWeatherServiceAsync> _weatherServiceAsyncMoq = new Mock<IWeatherServiceAsync>();
            Mock<IWeatherDao> _weatherDaoMoq = new Mock<IWeatherDao>();
            Mock<IOptionsMonitor<ApplicationConfig>> _appConfigMoq = new Mock<IOptionsMonitor<ApplicationConfig>>();
            Mock<IConfiguration> _config = new Mock<IConfiguration>();
            Mock<IWeatherBusiness> _weatherBusines = new Mock<IWeatherBusiness>();

            _weatherDaoMoq.Setup(x => x.GetSummaries()).Returns(new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        });

            

            IWeatherService _weatherService = new WeatherServiceImp(null, _weatherDaoMoq.Object, _appConfigMoq.Object, _config.Object);
            Mock<ILogger<WeatherForecastController>> _loggerMoq = new Mock<ILogger<WeatherForecastController>>();



            var controller = new WeatherForecastController(_loggerMoq.Object, _weatherServiceAsyncMoq.Object, _weatherService, _weatherBusines.Object);

            var response = controller.Get() as IEnumerable<WeatherForecast>;

            var currentValue = ((IEnumerator<WeatherForecast>)response).Current;

            while (currentValue != null)
            {
                currentValue = ((IEnumerator<WeatherForecast>)response).Current;
            }


            Assert.NotNull(response);
        }
    }
}
