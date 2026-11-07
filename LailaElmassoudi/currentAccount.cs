using System;

namespace Bank2026.Accounts
{
    class CurrentAccount : Account
    {
        public double CreditLine { get; set; }

        protected override double CalculInterets()
        {
            if (Balance > 0)
            {
                return Balance * 0.03;
            }
            else
            {
                return Math.Abs(Balance) * -0.0975;
            }
        }

        public override void Withdraw(double amount)
        {
            if (amount > 0 && Balance + CreditLine >= amount)
            {
                SetBalance(Balance - amount);
                Console.WriteLine("Retrait effectué.");
            }
            else
            {
                Console.WriteLine("Solde insuffisant.");
            }
        }
    }
}