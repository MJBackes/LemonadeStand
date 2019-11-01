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
            string url = $"http://dataservice.accuweather.com/currentconditions/v1/topcities/50?apikey={APIKeys.WeatherApi}";
            /// I couldn't find a free Weather API that gave more than a two week forecast, so to allow for games longer than
            /// two weeks I used an API call that returned the weather for the top 50 cities.
            /// So everyday will be in a different city instead of having different weather in the same city.
            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(url))
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
