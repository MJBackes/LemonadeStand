﻿using System;
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
        private IdealLemonade MyPreferredLemonade;
        private double HowInterestedINeedToBeToBuy;
        private Random rng;
        private List<double> LoyaltyList;
        //Contr
        public Customer(Random rng)
        {
            this.rng = rng;
            LoyaltyList = new List<double>();
            MyPreferredLemonade = new IdealLemonade();
        }
        //MembMeth
        public void PrepareForNewDay(Weather weather)
        {
            double temp = weather.Temperature;
            string conditions = weather.Conditions;
            GetInterest(temp, conditions);
            GetMyIdealLemonade(temp);
            HowInterestedINeedToBeToBuy = rng.Next(25, 50);
            HowInterestedINeedToBeToBuy /= 100;
        }
        private double GetBaseInterest()
        {
            double output = rng.Next(25, 35);
            output /= 100;
            return output;
        }
        private double GetNumberOfCubes(double temp)
        {
            double cubes = (temp - 50) / 5;
            if(cubes < 1)
            {
                cubes = 1;
            }
            return cubes;
        }
        private double GetNumberOfLemons()
        {
           return rng.Next(4, 7);
        }
        private double GetNumberOfSugars()
        {
            return rng.Next(5, 8);
        }
        private double GetPreferedPrice()
        {
            double desiredPrice = rng.Next(20, 25);
            desiredPrice /= 100;
            return desiredPrice;
        }
        private void GetMyIdealLemonade(double temp)
        {
            MyPreferredLemonade.PreferredNumberOfIceCubes = GetNumberOfCubes(temp);
            MyPreferredLemonade.PreferredNumberOfLemons = GetNumberOfLemons();
            MyPreferredLemonade.PreferredNumberOfCupsOfSugar = GetNumberOfSugars();
            MyPreferredLemonade.PreferredPrice = GetPreferedPrice();
        }
        private void GetInterest(double temp,string conditions)
        {
            Interest = GetBaseInterest();
            AdjustInterestBasedOnConditions(conditions);
            AdjustInterestBasedOnTemperature(temp);

        }
        private void AdjustInterestBasedOnTemperature(double temp)
        {
            double tempMultiplier = temp / 60;
            tempMultiplier = Math.Pow(tempMultiplier, 3);
            Interest *= tempMultiplier;
        }
        private void AdjustInterestBasedOnConditions(string conditions)
        {
            double rainyMultiplier = .5;
            double cloudyMultiplier = .8;
            double hazeyMultiplier = 1.25;
            double windyMultiplier = .9;
            double sunnyMultiplier = 1.15;
            switch (conditions)
            {
                case "Rainy":
                    Interest *= rainyMultiplier;
                    break;
                case "Cloudy":
                    Interest *= cloudyMultiplier;
                    break;
                case "Hazey":
                    Interest *= hazeyMultiplier;
                    break;
                case "Windy":
                    Interest *= windyMultiplier;
                    break;
                case "Sunny and Clear":
                    Interest *= sunnyMultiplier;
                    break;
                default:
                    break;
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
            double adjustment = (numLemons / MyPreferredLemonade.PreferredNumberOfLemons);
            return adjustment;
        }
        private double SatisfactionBasedOnSugar(int cupsOfSugar)
        {
            double adjustment = (cupsOfSugar / MyPreferredLemonade.PreferredNumberOfCupsOfSugar);
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
            double difference = Math.Abs(actualNumberOfIceCubes - MyPreferredLemonade.PreferredNumberOfIceCubes);
            double adjustment = (8/(difference+7));
            Interest *= adjustment;
        }
        private void adjustInterestBasedOnPrice(double price)
        {
            double adjustment = (MyPreferredLemonade.PreferredPrice / price);
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
            if (HowInterestedINeedToBeToBuy <= Interest)
            {
                AdjustLoyaltyBasedOnSatisfaction(recipe, playerIndex);
                return true;
            }
            return false;
        }

    }
}
