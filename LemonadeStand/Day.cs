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
        public Weather weather;
        private Random rng;
        //Contr
        public Day(Random rng)
        {
            Customers = new List<Customer>();
            this.rng = rng;
            weather = new Weather(this.rng);
            CreateCustomers();
        }
        //MembMeths
        private double getBaseInterest()
        {
            double output = rng.Next(25, 50);
            output /= 100;
            return output;
        }
        private void CreateCustomers()
        {
            int NumberOfCustomers = rng.Next(50, 110);
            for(int i = 0; i < NumberOfCustomers; i++)
            {
                double baseInterest = getBaseInterest();
                Customers.Add(new Customer(i + 1, baseInterest,weather.Temperature,weather.Conditions,rng.NextDouble(),rng));
            }
        }
        
    }
}
