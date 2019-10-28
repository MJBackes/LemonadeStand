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
        public int Temperature;
        public string Conditions;
        private Random rng;
        //Contr
        public Day(Random rng)
        {
            Customers = new List<Customer>();
            this.rng = rng;
            Conditions = InitializeConditions();
            Temperature = this.rng.Next(55, 105);
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
                Customers.Add(new Customer(i + 1, baseInterest,Temperature,Conditions,rng.Next(1,100)));
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
