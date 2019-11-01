using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class AccuweatherProcessor
    {
        public static async Task<List<CityWeatherData>> GetWeather()
        {
            string url = "http://dataservice.accuweather.com/currentconditions/v1/topcities/50?apikey=";
            using(HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
            {
                
                if (response.IsSuccessStatusCode)
                {
                    List<CityWeatherData> weatherList = await response.Content.ReadAsAsync<List<CityWeatherData>>();
                    return weatherList;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }    
    }
}
