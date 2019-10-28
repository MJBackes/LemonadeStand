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
        private int preferedNumberOfIceCubes;
        private double variance;
        //Contr
        public Customer(int CustNum,double baseInterest,int temp,string conditions,double varry)
        {
            Interest = getInterest(baseInterest, temp, conditions);
            preferedNumberOfIceCubes = getNumberOfCubes(temp);
            CustomerNumber = CustNum;
            variance = varry / 100;
        }
        //MembMeth
        private int getNumberOfCubes(int temp)
        {
            double cubes = (temp - 50) / 5;
            return Convert.ToInt32(cubes);
        }
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
        private void adjustInterestBasedOnLemons(int numLemons)
        {
            Interest *= numLemons / 7;
        }
        private void adjustInterestBasedOnSugar(int cupsOfSugar)
        {
            Interest *= cupsOfSugar / 8;
        }
        private void adjustInterestBasedOnIce(int cubesOfIce)
        {
            Interest *= cubesOfIce / preferedNumberOfIceCubes;
        }
        private void adjustInterestBasedOnPrice(double price)
        {
            Interest /= price / .15;
        }
        private void getInterestInRecipe(Recipe recipe)
        {
            adjustInterestBasedOnIce(recipe.NumIceCubes);
            adjustInterestBasedOnLemons(recipe.NumLemons);
            adjustInterestBasedOnSugar(recipe.CupsSugar);
            adjustInterestBasedOnPrice(recipe.PricePerCup);
        }
        public bool willIPurchase(Recipe recipe)
        {
            getInterestInRecipe(recipe);
            if (variance <= Interest)
            {
                return true;
            }
            return false;
        }

    }
}
