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
            lemonPrice = .075;
            sugarPrice = .0825;
            cupPrice = .0325;
            icePrice = .0175;
            isDoneShopping = false;
        }
        //MembMeth
        public void SellToPlayer(Player player)
        {
            isDoneShopping = false;
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
                    SellLemons(player,purchaseSize);
                    break;
                case "ice cube":
                    purchaseSize = GetPurchaseSize(player, itemName, icePrice);
                    SellIce(player, purchaseSize);
                    break;
                case "sugar,cup":
                    purchaseSize = GetPurchaseSize(player, itemName, sugarPrice);
                    SellSugar(player, purchaseSize);
                    break;
                case "cup":
                    purchaseSize = GetPurchaseSize(player, itemName, cupPrice);
                    SellCups(player, purchaseSize);
                    break;
                default:
                    break;
            }

        }
        private void PrintIfPurchaseTooLarge()
        {
            Console.Clear();
            Console.WriteLine("Not enough money to purchase that many.");
            Console.ReadLine();
        }
        private void SellLemons(Player player, int purchaseSize)
        {
            double saleTotal = purchaseSize * lemonPrice;
            if (player.wallet.Money >= saleTotal)
            {
                UpdatePlayerTraitsLemons(player, purchaseSize);
            }
            else
            {
                PrintIfPurchaseTooLarge();
            }
        }
        private void UpdatePlayerTraitsLemons(Player player,int purchaseSize)
        {
            player.inventory.LemonStock += purchaseSize;
            player.wallet.Money -= (lemonPrice * purchaseSize);
        }
        private void SellSugar(Player player, int purchaseSize)
        {
            double saleTotal = purchaseSize * sugarPrice;
            if (player.wallet.Money >= saleTotal)
            {
                UpdatePlayerTraitsSugar(player,purchaseSize);
            }
            else
            {
                PrintIfPurchaseTooLarge();
            }
        }
        private void UpdatePlayerTraitsSugar(Player player, int purchaseSize)
        {
            player.inventory.SugarStock += purchaseSize;
            player.wallet.Money -= (sugarPrice * purchaseSize);
        }
        private void SellIce(Player player, int purchaseSize)
        {
            double saleTotal = purchaseSize * icePrice;
            if (player.wallet.Money >= saleTotal)
            {
                UpdatePlayerTraitsIce(player, purchaseSize);
            }
            else
            {
                PrintIfPurchaseTooLarge();
            }
        }
        private void UpdatePlayerTraitsIce(Player player, int purchaseSize)
        {
            player.inventory.IceStock += purchaseSize;
            player.wallet.Money -= (icePrice * purchaseSize);
        }
        private void SellCups(Player player, int purchaseSize)
        {
            double saleTotal = purchaseSize * cupPrice;
            if (player.wallet.Money >= saleTotal)
            {
                UpdatePlayerTraitsCups(player, purchaseSize);
            }
            else
            {
                PrintIfPurchaseTooLarge();
            }
        }
        private void UpdatePlayerTraitsCups(Player player, int purchaseSize)
        {
            player.inventory.CupStock += purchaseSize;
            player.wallet.Money -= (cupPrice * purchaseSize);
        }
    }
}
