using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class AIPlayer : Player
    {
        //MembVars
        private int StandingNumberOfLemons;
        private int StandingNumberOfSugarCups;
        private int StandingNumberOfCups;
        private int StandingNumberOfIceCubes;
        private Random rng;
        //Contr
        public AIPlayer(int playerNumber, Random rng)
        {
            Name = "AIPlayer" + playerNumber;
            this.rng = rng;
            wallet = new Wallet();
            inventory = new Inventory();
            pitcher = new Pitcher();
            recipe = new Recipe();
        }
        //MembMeth
        private void SetStandingReserves()
        {
            StandingNumberOfLemons = recipe.NumLemons * 2;
            StandingNumberOfSugarCups = recipe.CupsSugar * 2;
            StandingNumberOfCups = 50;
            StandingNumberOfIceCubes = recipe.NumIceCubes * 50;
        }
        public override bool SetUpForTheDay(Store store, Weather todaysForecast, bool showCityName = false)
        {
            isSoldOut = false;
            SetRecipe(todaysForecast);
            SetStandingReserves();
            PurchaseIngredients(store);
            return true;
        }
        private void SetRecipe(Weather todaysForecast)
        {
            recipe.ChangeLemons(GetNumberOfLemons());
            recipe.ChangeSugar(GetNumberOfSugarCups());
            recipe.ChangeIce(GetNumberOfIceCubes(todaysForecast));
            recipe.ChangePrice(GetPrice(todaysForecast));
        }
        private int GetNumberOfLemons()
        {
            return rng.Next(7, 9);
        }
        private int GetNumberOfSugarCups()
        {
            return rng.Next(8, 10);
        }
        private int GetNumberOfIceCubes(Weather todaysForecast)
        {
            int output = Convert.ToInt32((todaysForecast.Temperature - 50) / 5);
            if(output < 1)
            {
                return 1;
            }
            else
            {
                return output;
            }
        }
        private double GetPrice(Weather todaysForecast)
        {
            double multiplier = (todaysForecast.Temperature - 50) / 50;
            double price = .4;
            price *= multiplier;
            if(price < .15)
            {
                price = .15;
            }
            if(price > .4)
            {
                price = .4;
            }
            return price;
        }
        private void PurchaseIngredients(Store store)
        {
            DoINeed_Lemons(store);
            DoINeed_Sugar(store);
            DoINeed_Cups(store);
            PurchaseIce(store);
        }
        private void DoINeed_Lemons(Store store)
        {
            if(inventory.LemonStock < StandingNumberOfLemons)
            {
                PurchaseLemons(store);
            }
        }
        private void DoINeed_Sugar(Store store)
        {
            if (inventory.SugarStock < StandingNumberOfSugarCups)
            {
                PurchaseSugar(store);
            }
        }
        private void DoINeed_Cups(Store store)
        {
            if (inventory.CupStock < StandingNumberOfCups)
            {
                PurchaseCups(store);
            }
        }
        private void PurchaseIce(Store store)
        {
            int purchaseSize = StandingNumberOfIceCubes;
            if (!store.SellItem(this, "ice cube", purchaseSize))
            {
                GoBankrupt();
            }
        }
        private void PurchaseLemons(Store store)
        {
            int purchaseSize = (StandingNumberOfLemons) - inventory.LemonStock;
            if(!store.SellItem(this, "lemon", purchaseSize))
            {
                GoBankrupt();
            }
        }
        private void PurchaseSugar(Store store)
        {
            int purchaseSize = (StandingNumberOfSugarCups) - inventory.SugarStock;
            if(!store.SellItem(this, "sugar,cup", purchaseSize))
            {
                GoBankrupt();
            }
        }
        private void PurchaseCups(Store store)
        {
            int purchaseSize = (StandingNumberOfCups) - inventory.CupStock;
            if(!store.SellItem(this, "cup", purchaseSize))
            {
                GoBankrupt();
            }
        }
    }
}
