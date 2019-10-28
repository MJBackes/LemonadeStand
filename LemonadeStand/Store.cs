using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {

        //MembVars
        private double lemonPrice;
        private double sugarPrice;
        private double cupPrice;
        private double icePrice;
        private bool isDoneShopping;
        //Contr
        public Store()
        {
            lemonPrice = .10;
            sugarPrice = .125;
            cupPrice = .0125;
            icePrice = .15;
            isDoneShopping = false;
        }
        //MembMeth
        public void GoToStore(Player player)
        {
            do
            {
                SellItem(player);
            } while (!isDoneShopping);
        }
        private int GetPurchaseSize(Player player,string itemName,double itemPrice)
        {
            int purchaseSize;
            bool isValidInput;
            Console.WriteLine($"Price per {itemName}: {itemPrice}");
            Console.WriteLine("Your Wallet: " + player.wallet.Money);
            Console.WriteLine($"How many {itemName}(s) would you like to buy?");
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out purchaseSize);
            } while (!isValidInput);
            return purchaseSize;
        }
        private string GetItemToSell(Player player)
        {
            string input;
            Console.Clear();
            player.PrintResources();
            Console.WriteLine("1.Buy Lemons.");
            Console.WriteLine("2.Buy Ice Cubes.");
            Console.WriteLine("3.Buy Cups of Sugar.");
            Console.WriteLine("4.Buy Cups");
            Console.WriteLine("5.Return.");
            Console.WriteLine("Enter the number coresponding to the purchase you would like to make or 5 to return to the previous screen.");
            do
            {
                input = Console.ReadLine();
            } while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5");
            switch (input)
            {
                case "1":
                    return "lemon";
                case "2":
                    return "ice cube";
                case "3":
                    return "sugar,cup";
                case "4":
                    return "cup";
                default:
                    isDoneShopping = true;
                    return "return";
            }
        }
        public void SellItem(Player player)
        {
            string itemName = GetItemToSell(player);
            int purchaseSize;
            switch (itemName)
            {
                case "lemon":
                    purchaseSize = GetPurchaseSize(player, itemName, lemonPrice);
                    UpdatePlayerTraitsLemons(player,purchaseSize);
                    break;
                case "ice cube":
                    purchaseSize = GetPurchaseSize(player, itemName, icePrice);
                    UpdatePlayerTraitsIce(player, purchaseSize);
                    break;
                case "sugar,cup":
                    purchaseSize = GetPurchaseSize(player, itemName, sugarPrice);
                    UpdatePlayerTraitsSugar(player, purchaseSize);
                    break;
                case "cup":
                    purchaseSize = GetPurchaseSize(player, itemName, cupPrice);
                    UpdatePlayerTraitsCups(player, purchaseSize);
                    break;
                default:
                    break;
            }

        }
        private void UpdatePlayerTraitsLemons(Player player, int purchaseSize)
        {
            double saleTotal = purchaseSize * lemonPrice;
            if (player.wallet.Money >= saleTotal)
            {
                player.inventory.LemonStock += purchaseSize;
                player.wallet.Money -= (saleTotal);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not enough money to purchase that many.");
                Console.ReadLine();
            }
        }
        private void UpdatePlayerTraitsSugar(Player player, int purchaseSize)
        {
            double saleTotal = purchaseSize * sugarPrice;
            if (player.wallet.Money >= saleTotal)
            {
                player.inventory.SugarStock += purchaseSize;
                player.wallet.Money -= (saleTotal);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not enough money to purchase that many.");
                Console.ReadLine();
            }
        }
        private void UpdatePlayerTraitsIce(Player player, int purchaseSize)
        {
            double saleTotal = purchaseSize * icePrice;
            if (player.wallet.Money >= saleTotal)
            {
                player.inventory.IceStock += purchaseSize;
                player.wallet.Money -= (saleTotal);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not enough money to purchase that many.");
                Console.ReadLine();
            }
        }
        private void UpdatePlayerTraitsCups(Player player, int purchaseSize)
        {
            double saleTotal = purchaseSize * cupPrice;
            if (player.wallet.Money >= saleTotal)
            {
                player.inventory.CupStock += purchaseSize;
                player.wallet.Money -= (saleTotal);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Not enough money to purchase that many.");
                Console.ReadLine();
            }
        }
    }
}
