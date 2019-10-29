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
        private Random rng;
        //Contr
        public Weather(Random rng)
        {
            this.rng = rng;
            Conditions = InitializeConditions();
            Temperature = this.rng.Next(55, 105);
        }
        //MembMeth
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
