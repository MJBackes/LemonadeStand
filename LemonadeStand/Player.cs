using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    abstract class Player
    {

        //MembVars
        public string Name;
        public Inventory inventory;
        public Wallet wallet;
        public Pitcher pitcher;
        public Recipe recipe;
        public bool isSoldOut;
        public int TotalCupsSold;
        public int CupsSoldToday;
        public int PlayerNumber;
        private bool isBankrupt;
        public bool IsBankrupt
        {
            get => isBankrupt;
        }
        //Contr

        //MembMeth
        public abstract bool SetUpForTheDay(Store store,Weather todaysForecast,bool showCityName = false);
        public void UpdateTotalCupsSold()
        {
            TotalCupsSold += CupsSoldToday;
        }
        public void ResetCupsSoldToday()
        {
            CupsSoldToday = 0;
        }
        public void RefillPitcher()
        {
            if (inventory.LemonStock >= recipe.NumLemons && inventory.SugarStock >= recipe.CupsSugar)
            {
                Fill();
            }
            else
            {
                isSoldOut = true;
            }
        }
        private void Fill()
        {
            inventory.LemonStock -= recipe.NumLemons;
            inventory.SugarStock -= recipe.CupsSugar;
            pitcher.Refill();

        }
        public void GoBankrupt()
        {
            isBankrupt = true;
        }
        public void ChangeRecipe()
        {
            string input;
            bool isDoneChangingRecipe = false;
            do
            {
                Console.Clear();
                UserInterface.PrintRecipe(recipe);
                input = GetRecipeChangeInput();
                switch (input)
                {
                    case "lemon":
                        recipe.ChangeLemons();
                        break;
                    case "ice":
                        recipe.ChangeIce();
                        break;
                    case "sugar":
                        recipe.ChangeSugar();
                        break;
                    case "price":
                        recipe.ChangePrice();
                        break;
                    default:
                        isDoneChangingRecipe = true;
                        break;

                }
            } while (!isDoneChangingRecipe);
        }
        private string GetRecipeChangeInput()
        {
            string input;
            UserInterface.PrintGetChangeRecipeInputText(recipe);
            do
            {
                input = Console.ReadLine();
            } while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5");
            switch (input)
            {
                case "1":
                    return "lemon";
                case "2":
                    return "sugar";
                case "3":
                    return "ice";
                case "4":
                    return "price";
                default:
                    return "return";
            }
        }
        public void CustomerSale()
        {
            if (pitcher.isEmpty)
            {
                RefillPitcher();
            }
            if (!CheckIfSoldOut())
            {
                SellCup();
            }
        }
        private bool CheckIfSoldOut()
        {
            if(recipe.NumIceCubes > inventory.IceStock || inventory.CupStock < 1 || isSoldOut)
            {
                return true;
            }
            return false;
        }
        private void SellCup()
        {
            wallet.Money += recipe.PricePerCup;
            UpdateInventoryAfterSale();
            pitcher.CheckIfEmpty();
            CupsSoldToday++;
        }
        private void UpdateInventoryAfterSale()
        {
            pitcher.CupsLeftInPitcher--;
            pitcher.CheckIfEmpty();
            inventory.IceStock -= recipe.NumIceCubes;
            inventory.CupStock--;
        }
        
        
    }
}
