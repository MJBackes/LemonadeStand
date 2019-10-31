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
        private List<Customer> PotentialCustomers;
        public int WeekNum;
        Random rng;
        //Contr
        public Week(int number,Random rng,List<Customer> potCustomers)
        {
            PotentialCustomers = potCustomers;
            WeekNum = number;
            this.rng = rng;
            DaysOfTheWeek = new Day[7];
            FillDayArray();
        }
        //MembMeth
        private void FillDayArray()
        {
            for(int i = 0; i < DaysOfTheWeek.Length; i++)
            {
                DaysOfTheWeek[i] = new Day(rng,PotentialCustomers);
            }
        }
    }
}
