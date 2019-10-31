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
        private double preferredNumberOfIceCubes;
        private double preferredNumberOfLemons;
        private double preferredNumberOfCupsOfSugar;
        private double preferredPrice;
        private double variance;
        private Random rng;
        public List<double> LoyaltyList;
        //Contr
        public Customer(Random rng)
        {
            this.rng = rng;
            LoyaltyList = new List<double>();
        }
        //MembMeth
        public void PrepareForNewDay(Weather weather)
        {
            double temp = weather.Temperature;
            string conditions = weather.Conditions;
            Interest = getInterest(temp, conditions);
            preferredNumberOfIceCubes = getNumberOfCubes(temp);
            preferredNumberOfLemons = getNumberOfLemons();
            preferredNumberOfCupsOfSugar = getNumberOfSugars();
            preferredPrice = getPreferedPrice();
            variance = rng.Next(25, 50);
            variance /= 100;
        }
        private double getBaseInterest()
        {
            double output = rng.Next(25, 35);
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
            double desiredPrice = rng.Next(20, 25);
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
        public void SetUpCustomerLoyaltyList(int numberOfPlayers)
        {
            for(int i = 0; i < numberOfPlayers; i++)
            {
                LoyaltyList.Add(.5);
            }
        }
        private double SatisfactionBasedOnLemons(int numLemons)
        {
            double adjustment = (numLemons / preferredNumberOfLemons);
            return adjustment;
        }
        private double SatisfactionBasedOnSugar(int cupsOfSugar)
        {
            double adjustment = (cupsOfSugar / preferredNumberOfCupsOfSugar);
            return adjustment;
        }
        public double GetSatisfactionBasedOnRecipe(Recipe recipe)
        {
            double lemonSat = SatisfactionBasedOnLemons(recipe.NumLemons);
            double sugarSat = SatisfactionBasedOnSugar(recipe.CupsSugar);
            return (lemonSat * sugarSat)/1.5;
        }
        private void AdjustLoyaltyBasedOnSatisfaction(Recipe recipe, int playerIndex)
        {
            LoyaltyList[playerIndex] *= GetSatisfactionBasedOnRecipe(recipe);
            if(LoyaltyList[playerIndex] > 1)
            {
                LoyaltyList[playerIndex] = 1;
            }
        }
        private void adjustInterestBasedOnLoyalty(int playerIndex)
        {
            Interest *= (LoyaltyList[playerIndex] / .75);
        }
        private void adjustInterestBasedOnIce(int actualNumberOfIceCubes)
        {
            double difference = Math.Abs(actualNumberOfIceCubes - preferredNumberOfIceCubes);
            double adjustment = (8/(difference+7));
            Interest *= adjustment;
        }
        private void adjustInterestBasedOnPrice(double price)
        {
            double adjustment = (preferredPrice / price);
            adjustment = Math.Pow(adjustment, 2);
            Interest *= adjustment;
        }
        private void getInterestInRecipe(Recipe recipe,int playerIndex)
        {
            adjustInterestBasedOnIce(recipe.NumIceCubes);
            adjustInterestBasedOnPrice(recipe.PricePerCup);
            adjustInterestBasedOnLoyalty(playerIndex);
        }
        public bool WillIPurchase(Recipe recipe,int playerIndex)
        {
            getInterestInRecipe(recipe,playerIndex);
            if (variance <= Interest)
            {
                AdjustLoyaltyBasedOnSatisfaction(recipe, playerIndex);
                return true;
            }
            return false;
        }

    }
}
