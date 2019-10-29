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
        public double DailyProfit;
        public double TotalProfit;
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
            DailyProfit = Money - CurrentFunds;
            CurrentFunds = Money;
        }
        public void UpdateTotalProfit()
        {
            TotalProfit += DailyProfit;
        }
    }
}
