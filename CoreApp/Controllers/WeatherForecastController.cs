using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherServiceAsync _weatherServiceAsync;
        private readonly IWeatherService _weatherService;
        private readonly IWeatherBusiness _weatherBusines;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherServiceAsync weatherServiceAsync, IWeatherService weatherService, IWeatherBusiness  weatherBusiness)
        {
            _logger = logger;
            _weatherServiceAsync = weatherServiceAsync;
            _weatherService = weatherService;
            _weatherBusines = weatherBusiness;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var items = _weatherService.GetWeatherForcast();
            _logger.LogInformation($"_weatherService {_weatherService.GetHashCode()}", new object[] { new object() });
            _weatherBusines.GetWeatherForcast();

            //return items.Take(3);

            return items;
        }

        [HttpGet("/{id}")]
        //[HttpGet("{id:int}", Name = "GetById")]
        public async Task<IEnumerable<WeatherForecast>> Get(int id = 0)
        {
            _logger.LogWarning("Test Log", new object[] { new object() });
            return await _weatherServiceAsync.GetWeatherForcast();
        }

        [HttpPost("/{id}")]
        public async Task<IEnumerable<WeatherForecast>> Update([FromBody] Object data)
        {
            _logger.LogWarning("Test Log", new object[] { new object() });
            return await _weatherServiceAsync.GetWeatherForcast();
        }

        [HttpPut]
        [Route("/Put", Name ="")]
        public async Task<IEnumerable<WeatherForecast>> Create([FromBody] Object data)
        {
            _logger.LogWarning("Test Log", new object[] { new object() });
            return await _weatherServiceAsync.GetWeatherForcast();
        }

        [HttpDelete("/{id}")]
        public async Task<IEnumerable<WeatherForecast>> DeleteById([FromBody] Object data)
        {
            _logger.LogWarning("Test Log", new object[] { new object() });
            return await _weatherServiceAsync.GetWeatherForcast();
        }

        [HttpGet("/{id}/Adresse")]
        public async Task<IEnumerable<WeatherForecast>> GetAdresseByUserId([FromBody] Object data)
        {
            _logger.LogWarning("Test Log", new object[] { new object() });
            return await _weatherServiceAsync.GetWeatherForcast();
        }
    }
}
