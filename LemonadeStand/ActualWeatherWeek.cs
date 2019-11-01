using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class ActualWeatherWeek : Week
    {
        public ActualWeatherWeek(int number, Random rng, List<Customer> potCustomers) : base(number,rng,potCustomers)
        {
        }
        public override void FillDayArray(List<CityWeatherData> weatherList)
        {
            for (int i = 0; i < 7; i++) {
                DaysOfTheWeek[i] = new Day(rng,PotentialCustomers,weatherList[i]);
                    }
        }
    }
}
