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
        public int WeekNum;
        //Contr
        public Week(int number)
        {
            WeekNum = number;
            DaysOfTheWeek = new Day[7];
            FillDayArray();
        }
        //MembMeth
        private void FillDayArray()
        {
            for(int i = 0; i < DaysOfTheWeek.Length; i++)
            {
                DaysOfTheWeek[i] = new Day();
            }
        }
    }
}
