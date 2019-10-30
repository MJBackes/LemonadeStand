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
        private double Interest;
        private double preferedNumberOfIceCubes;
        private double preferedNumberOfLemons;
        private double preferedNumberOfCupsOfSugar;
        private double preferedPrice;
        private double variance;
        private Random rng;
        //Contr
        public Customer(double temp,string conditions,Random rng)
        {
            this.rng = rng;
            Interest = getInterest(temp, conditions);
            preferedNumberOfIceCubes = getNumberOfCubes(temp);
            preferedNumberOfLemons = getNumberOfLemons();
            preferedNumberOfCupsOfSugar = getNumberOfSugars();
            preferedPrice = getPreferedPrice();
            variance = rng.NextDouble() ;
        }
        //MembMeth
        private double getBaseInterest()
        {
            double output = rng.Next(25, 50);
            output /= 100;
            return output;
        }
        private double getNumberOfCubes(double temp)
        {
            double cubes = (temp - 50) / 5;
            return cubes;
        }
        private double getNumberOfLemons()
        {
           return rng.Next(4, 7);
        }
        private double getNumberOfSugars()
        {
            return rng.Next(5, 8);
        }
        private double getPreferedPrice()
        {
            double desiredPrice = rng.Next(9, 14);
            desiredPrice /= 100;
            return desiredPrice;
        }
        private double getInterest(double temp,string conditions)
        {
            double baseInterest = getBaseInterest();
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
            double adjustment = (numLemons / preferedNumberOfLemons);
            Interest *= adjustment;
        }
        private void adjustInterestBasedOnSugar(int cupsOfSugar)
        {
            double adjustment = (cupsOfSugar / preferedNumberOfCupsOfSugar);
            Interest *= adjustment;
        }
        private void adjustInterestBasedOnIce(int actualNumberOfIceCubes)
        {
            double adjustment = (actualNumberOfIceCubes  / preferedNumberOfIceCubes);
            Interest *= adjustment;
        }
        private void adjustInterestBasedOnPrice(double price)
        {
            double adjustment = (preferedPrice / price);
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
