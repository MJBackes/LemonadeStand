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
        //Contr

        //MembMeth
        public void PrintResources()
        {
            inventory.PrintInventory();
            wallet.PrintWallet();
        }
        public void PrintRecipe()
        {
            recipe.PrintRecipe();
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
        public void ChangeRecipe()
        {
            string input;
            bool isDoneChangingRecipe = false;
            do
            {
                Console.Clear();
                recipe.PrintRecipe();
                input = getRecipeChangeInput();
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
        private string getRecipeChangeInput()
        {
            string input;
            Console.WriteLine("1.Change Lemons per Pitcher.");
            Console.WriteLine("2.Change Cups of Sugar per Pitcher.");
            Console.WriteLine("3.Change Cubes of Ice per Cup.");
            Console.WriteLine("4.Change Price per Cup.");
            Console.WriteLine("5.Return.");
            Console.WriteLine("Enter the number coresponding to the component you would like to change or 5 to return to the previous screen.");
            do
            {
                input = Console.ReadLine();
            } while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5");
            switch (input)
            {
                case "1":
                    return "lemon";
                case "2":
                    return "ice";
                case "3":
                    return "sugar";
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
            if (!isSoldOut)
            {
                SellCup();
            }
        }
        private void SellCup()
        {
            wallet.Money += recipe.PricePerCup;
            UpdateInventoryAfterSale();
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
