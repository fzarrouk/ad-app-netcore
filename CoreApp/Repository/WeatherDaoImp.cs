using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Repository
{
    public class WeatherDaoImp : IWeatherDao
    {
        private static readonly IList<string> Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public string GetDbConnexionName()
        {
            return "SQL Connexion";
        }

        public IList<string> GetSummaries()
        {
            return Summaries;
        }


    }
}
