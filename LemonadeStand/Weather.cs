using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        //MembVars
        public double Temperature;
        public string Conditions;
        public string Location;
        private double probabilityOfAccurateForecast;
        private Random rng;
        public double ProbablilityOfAccurateForecast
        {
            get => probabilityOfAccurateForecast;
            set => probabilityOfAccurateForecast = Math.Floor(value * 100);
        }
        //Contr
        public Weather(Random rng,string location = "")
        {
            this.rng = rng;
            Conditions = InitializeConditions();
            Temperature = this.rng.Next(55, 105);
            Location = location;
        }
        public Weather(CityWeatherData weatherData)
        {
            Conditions = ParseWeatherText(weatherData.WeatherText);
            Temperature = weatherData.Temperature.Imperial.Value;
            Location = weatherData.EnglishName;
        }
        //MembMeth
        private string ParseWeatherText(string weatherText)
        {
            weatherText = weatherText.ToLower();
            if ((weatherText.Contains("sun") || weatherText.Contains("clear")) && !weatherText.Contains("cloud"))
            {
                return "Sunny and Clear";
            }
            else if (weatherText.Contains("cloud") || weatherText.Contains("overcast") || weatherText.Contains("fog"))
            {
                return "Cloudy";
            }
            else
            {
                return "Rainy";
            }
        }
        private string InitializeConditions()
        {
            int randomNumber = rng.Next(1, 6);
            switch (randomNumber)
            {
                case 1:
                    return "Rainy";
                case 2:
                    return "Cloudy";
                case 3:
                    return "Hazey";
                case 4:
                    return "Windy";
                case 5:
                    return "Sunny and Clear";
                default:
                    return "Rainy";
            }
        }
    }
}
