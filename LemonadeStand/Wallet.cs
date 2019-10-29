using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Wallet
    {
        //MembVars
        public double Money;
        private double CurrentFunds;
        private double dailyProfit;
        private double totalProfit;
        public double DailyProfit
        {
            get => dailyProfit;
        }
        public double TotalProfit
        {
            get => totalProfit;
        }
        //Contr
        public Wallet()
        {
            Money = 20.00;
            CurrentFunds = Money;
        }
        //MembMeth
        public void PrintWallet()
        {
            Console.WriteLine($"Wallet: {Money}");
        }
        public void UpdateDailyProfit()
        {
            Money = Math.Floor(Money * 100) / 100;
            dailyProfit = Money - CurrentFunds;
            CurrentFunds = Money;
        }
        public void UpdateTotalProfit()
        {
            totalProfit += dailyProfit;
        }
    }
}
