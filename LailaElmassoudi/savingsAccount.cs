using System;

namespace Bank2026.Accounts
{
    class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; set; }

        protected override double CalculInterets()
        {
            return Balance * 0.045;
        }

        public override void Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                SetBalance(Balance - amount);

                DateLastWithdraw = DateTime.Now;

                Console.WriteLine("Retrait effectué.");
            }
            else
            {
                Console.WriteLine("Solde insuffisant.");
            }
        }
    }
}