using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Week
    {

        //MembVars
        public Day[] DaysOfTheWeek;
        protected List<Customer> PotentialCustomers;
        public int WeekNum;
        public Random rng;
        //Contr
        public Week(int number,Random rng,List<Customer> potCustomers)
        {
            PotentialCustomers = potCustomers;
            WeekNum = number;
            this.rng = rng;
            DaysOfTheWeek = new Day[7];
        }
        //MembMeth
        public virtual void FillDayArray(List<CityWeatherData> weatherList = null)
        {
            for(int i = 0; i < DaysOfTheWeek.Length; i++)
            {
                DaysOfTheWeek[i] = new Day(rng,PotentialCustomers);
            }
        }
    }
}
