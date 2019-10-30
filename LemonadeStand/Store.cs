﻿using System;
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
        private double largeDiscount;
        private double smallDiscount;
        //Contr
        public Store()
        {
            lemonPrice = .075;
            sugarPrice = .0825;
            cupPrice = .0325;
            icePrice = .0175;
            largeDiscount = .85;
            smallDiscount = .9;
            isDoneShopping = false;
        }
        //MembMeth
        public void SellToHumanPlayer(Player player)
        {
            isDoneShopping = false;
            do
            {
                SellItem(player);
            } while (!isDoneShopping);
        }
        private int GetPurchaseSize(Player player,string itemName,double itemPrice,int smallDiscountThreshold,int largeDiscountThreshold)
        {
            int purchaseSize;
            bool isValidInput;
            Console.WriteLine($"Price per {itemName}: {itemPrice}");
            Console.WriteLine($"10% Discount on purchases of {smallDiscountThreshold} or more.");
            Console.WriteLine($"15% Discount on purchases of {largeDiscountThreshold} or more.");
            Console.WriteLine("Your Wallet: " + player.wallet.Money);
            Console.WriteLine($"How many {itemName}(s) would you like to buy?");
            do
            {
                isValidInput = int.TryParse(Console.ReadLine(), out purchaseSize);
            } while (!isValidInput || purchaseSize < 0);
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
                    purchaseSize = GetPurchaseSize(player, itemName, lemonPrice, 25, 50);
                    SellLemons(player,purchaseSize);
                    break;
                case "ice cube":
                    purchaseSize = GetPurchaseSize(player, itemName, icePrice, 100, 250);
                    SellIce(player, purchaseSize);
                    break;
                case "sugar,cup":
                    purchaseSize = GetPurchaseSize(player, itemName, sugarPrice, 20, 40);
                    SellSugar(player, purchaseSize);
                    break;
                case "cup":
                    purchaseSize = GetPurchaseSize(player, itemName, cupPrice, 100, 250);
                    SellCups(player, purchaseSize);
                    break;
                default:
                    break;
            }

        }
        public void SellItem(Player player,string itemName,int purchaseSize)
        {
            switch (itemName)
            {
                case "lemon":
                    SellLemons(player, purchaseSize);
                    break;
                case "ice cube":
                    SellIce(player, purchaseSize);
                    break;
                case "sugar,cup":
                    SellSugar(player, purchaseSize);
                    break;
                case "cup":
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
            double saleTotal = getSaleTotal_Lemons(purchaseSize);
            if (player.wallet.Money >= saleTotal)
            {
                UpdatePlayerTraits_Lemons(player, purchaseSize);
            }
            else
            {
                PrintIfPurchaseTooLarge();
            }
        }
        private void UpdatePlayerTraits_Lemons(Player player,int purchaseSize)
        {
            player.inventory.LemonStock += purchaseSize;
            player.wallet.Money -= (lemonPrice * purchaseSize);
        }
        private double getSaleTotal_Lemons(int purchaseSize)
        {
            if(purchaseSize > 50)
            {
                return purchaseSize * lemonPrice * largeDiscount;
            }
            else if(purchaseSize > 25)
            {
                return purchaseSize * lemonPrice * smallDiscount;
            }
            else
            {
                return purchaseSize * lemonPrice;
            }
        }
        private void SellSugar(Player player, int purchaseSize)
        {
            double saleTotal = getSaleTotal_Sugar(purchaseSize);
            if (player.wallet.Money >= saleTotal)
            {
                UpdatePlayerTraits_Sugar(player,purchaseSize);
            }
            else
            {
                PrintIfPurchaseTooLarge();
            }
        }
        private void UpdatePlayerTraits_Sugar(Player player, int purchaseSize)
        {
            player.inventory.SugarStock += purchaseSize;
            player.wallet.Money -= (sugarPrice * purchaseSize);
        }
        private double getSaleTotal_Sugar(int purchaseSize)
        {
            if (purchaseSize > 40)
            {
                return purchaseSize * sugarPrice * largeDiscount;
            }
            else if (purchaseSize > 20)
            {
                return purchaseSize * sugarPrice * smallDiscount;
            }
            else
            {
                return purchaseSize * sugarPrice;
            }
        }
        private void SellIce(Player player, int purchaseSize)
        {
            double saleTotal = getSaleTotal_Ice(purchaseSize);
            if (player.wallet.Money >= saleTotal)
            {
                UpdatePlayerTraits_Ice(player, purchaseSize);
            }
            else
            {
                PrintIfPurchaseTooLarge();
            }
        }
        private void UpdatePlayerTraits_Ice(Player player, int purchaseSize)
        {
            player.inventory.IceStock += purchaseSize;
            player.wallet.Money -= (icePrice * purchaseSize);
        }
        private double getSaleTotal_Ice(int purchaseSize)
        {
            if (purchaseSize > 250)
            {
                return purchaseSize * icePrice * largeDiscount;
            }
            else if (purchaseSize > 100)
            {
                return purchaseSize * icePrice * smallDiscount;
            }
            else
            {
                return purchaseSize * icePrice;
            }
        }
        private void SellCups(Player player, int purchaseSize)
        {
            double saleTotal = getSaleTotal_Cups(purchaseSize);
            if (player.wallet.Money >= saleTotal)
            {
                UpdatePlayerTraits_Cups(player, purchaseSize);
            }
            else
            {
                PrintIfPurchaseTooLarge();
            }
        }
        private void UpdatePlayerTraits_Cups(Player player, int purchaseSize)
        {
            player.inventory.CupStock += purchaseSize;
            player.wallet.Money -= (cupPrice * purchaseSize);
        }
        private double getSaleTotal_Cups(int purchaseSize)
        {
            if (purchaseSize > 250)
            {
                return purchaseSize * cupPrice * largeDiscount;
            }
            else if (purchaseSize > 100)
            {
                return purchaseSize * cupPrice * smallDiscount;
            }
            else
            {
                return purchaseSize * cupPrice;
            }
        }
    }
}
