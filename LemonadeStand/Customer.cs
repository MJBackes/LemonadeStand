using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        //MembVars
        public double Interest;
        public int CustomerNumber;
        //Contr
        public Customer(int CustNum,double baseInterest,int temp,string conditions)
        {
            Interest = getInterest(baseInterest, temp, conditions);
            CustomerNumber = CustNum;
        }
        //MembMeth
        private double getInterest(double baseInterest,int temp,string conditions)
        {
            double interest = baseInterest;
            interest *= Math.Pow((temp / 60),3);
            switch (conditions)
            {
                case "Rainy":
                    return interest * .5;
                case "Cloudy":
                    return interest * .8;
                case "Hazey":
                    return interest * 1.5;
                case "Windy":
                    return interest * .65;
                case "Sunny and Clear":
                    return interest * 1.25;
                default:
                    return interest;
            }
        }
    }
}
