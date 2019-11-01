using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class CityWeatherData
    {
        public string EnglishName { get; set; }
        public string WeatherText { get; set; }
        public TemperatureModel Temperature { get; set; }
    }
}
