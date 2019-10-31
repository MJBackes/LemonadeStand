using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {

        //MembVars
        public List<Customer> Customers;
        public List<Customer> PotentialCustomers;
        public Weather weather;
        private Random rng;
        //Contr
        public Day(Random rng, List<Customer> potCustomers)
        {
            Customers = new List<Customer>();
            PotentialCustomers = potCustomers;
            this.rng = rng;
            weather = new Weather(this.rng);
            FillCustomers();
        }
        //MembMeths
        private void FillCustomers()
        {
            int NumberOfPeopleOutToday = GetNumberOfPeopleOutToday();
            List<int> indices = GetListOfCustomerIndices(NumberOfPeopleOutToday);
            foreach (int index in indices) {
                Customers.Add(PotentialCustomers[index]);
                    }
        }
        private List<int> GetListOfCustomerIndices(int length)
        {
            List<int> output = new List<int>();
            int index;
            while(output.Count < length)
            {
                index = rng.Next(PotentialCustomers.Count);
                if (!output.Contains(index)){
                    output.Add(index);
                }
            }
            return output;
        }
        private int GetNumberOfPeopleOutToday()
        {
            int baseNumber = 100;
            if(weather.Conditions == "Rainy")
            {
                baseNumber = Convert.ToInt32(baseNumber * .8);
            }
            if (weather.Conditions == "Cloudy")
            {
                baseNumber = Convert.ToInt32(baseNumber * .95);
            }
            if (weather.Conditions == "Windy")
            {
                baseNumber = Convert.ToInt32(baseNumber * .9);
            }
            if (weather.Conditions == "Sunny and Clear")
            {
                baseNumber = Convert.ToInt32(baseNumber * 1.1);
            }
            if(weather.Temperature < 60 || weather.Temperature > 90)
            {
                baseNumber = Convert.ToInt32(baseNumber * .9);
            }
            return baseNumber;
        }
    }
}
