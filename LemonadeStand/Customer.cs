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
        private double preferedNumberOfIceCubes;
        private double variance;
        private Random rng;
        //Contr
        public Customer(int CustNum,double baseInterest,double temp,string conditions,double varry,Random rng)
        {
            Interest = getInterest(baseInterest, temp, conditions);
            preferedNumberOfIceCubes = getNumberOfCubes(temp);
            CustomerNumber = CustNum;
            variance = varry;
            this.rng = rng;
        }
        //MembMeth
        private double getNumberOfCubes(double temp)
        {
            double cubes = (temp - 50) / 5;
            return cubes;
        }
        private double getInterest(double baseInterest,double temp,string conditions)
        {
            double rainyMultiplier = .5;
            double cloudyMultiplier = .8;
            double hazeyMultiplier = 1.5;
            double windyMultiplier = .9;
            double sunnyMultiplier = 1.25;
            double interest = baseInterest;
            double tempMultiplier = temp / 60;
            tempMultiplier = Math.Pow(tempMultiplier, 3);
            interest *= tempMultiplier;
            switch (conditions)
            {
                case "Rainy":
                    interest *= rainyMultiplier;
                    return interest;
                case "Cloudy":
                    interest *= cloudyMultiplier;
                    return interest;
                case "Hazey":
                    interest *= hazeyMultiplier;
                    return interest;
                case "Windy":
                    interest *= windyMultiplier;
                    return interest;
                case "Sunny and Clear":
                    interest *= sunnyMultiplier;
                    return interest;
                default:
                    return interest;
            }
        }
        private void adjustInterestBasedOnLemons(int numLemons)
        {
            double desiredLemons = rng.Next(4, 7);
            double adjustment = (numLemons / desiredLemons);
            Interest *= adjustment;
        }
        private void adjustInterestBasedOnSugar(int cupsOfSugar)
        {
            double desiredSugar = rng.Next(5, 7);
            double adjustment = (cupsOfSugar / desiredSugar);
            Interest *= adjustment;
        }
        private void adjustInterestBasedOnIce(int cubesOfIce)
        {
            double actualNumberOfIceCubes = cubesOfIce;
            double adjustment = (actualNumberOfIceCubes  / preferedNumberOfIceCubes);
            Interest *= adjustment;
        }
        private void adjustInterestBasedOnPrice(double price)
        {
            double desiredPrice = rng.Next(9, 14);
            desiredPrice /= 100;
            double adjustment = (desiredPrice / price);
            adjustment = Math.Pow(adjustment, 2);
            Interest *= adjustment;
        }
        private void getInterestInRecipe(Recipe recipe)
        {
            adjustInterestBasedOnIce(recipe.NumIceCubes);
            adjustInterestBasedOnLemons(recipe.NumLemons);
            adjustInterestBasedOnSugar(recipe.CupsSugar);
            adjustInterestBasedOnPrice(recipe.PricePerCup);
        }
        public bool WillIPurchase(Recipe recipe)
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
