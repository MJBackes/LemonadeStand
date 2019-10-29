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
        public double GetDailyProfit()
        {
            Money = Math.Floor(Money * 100) / 100;
            double profit = Money - CurrentFunds;
            CurrentFunds = Money;
            return profit;
        }
    }
}
