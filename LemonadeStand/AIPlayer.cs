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
        public override bool SetUpForTheDay(Store store)
        {
            SetRecipe();
            SetStandingReserves();
            PurchaseIngredients(store);
            return true;
        }
        private void SetRecipe()
        {
            recipe.ChangeLemons(GetNumberOfLemons());
            recipe.ChangeSugar(GetNumberOfSugarCups());
            recipe.ChangeIce(GetNumberOfIceCubes());
            recipe.ChangePrice(GetPrice());
        }
        private int GetNumberOfLemons()
        {
            return rng.Next(4, 7);
        }
        private int GetNumberOfSugarCups()
        {
            return rng.Next(5, 8);
        }
        private int GetNumberOfIceCubes()
        {
            return rng.Next(8);
        }
        private double GetPrice()
        {
            double price = rng.Next(9, 14);
            price /= 100;
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
            store.SellItem(this, "ice cube", purchaseSize);
        }
        private void PurchaseLemons(Store store)
        {
            int purchaseSize = (StandingNumberOfLemons) - inventory.LemonStock;
            store.SellItem(this, "lemon", purchaseSize);
        }
        private void PurchaseSugar(Store store)
        {
            int purchaseSize = (StandingNumberOfSugarCups) - inventory.SugarStock;
            store.SellItem(this, "sugar,cup", purchaseSize);
        }
        private void PurchaseCups(Store store)
        {
            int purchaseSize = (StandingNumberOfCups) - inventory.CupStock;
            store.SellItem(this, "cup", purchaseSize);
        }
    }
}
