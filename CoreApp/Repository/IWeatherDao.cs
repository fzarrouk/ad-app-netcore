using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Repository
{
    public interface IWeatherDao
    {
        public string GetDbConnexionName();

        public IList<string> GetSummaries();
            

    }
}
