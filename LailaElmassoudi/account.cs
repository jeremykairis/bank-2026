using System;
using Bank2026.Persons;

namespace Bank2026.Accounts
{
    abstract class Account
    {
        public string Number { get; set; }

        public double Balance { get; private set; }

        public Person Owner { get; set; }

        protected abstract double CalculInterets();

        public virtual void Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance = Balance - amount;
                Console.WriteLine("Retrait effectué.");
            }
            else
            {
                Console.WriteLine("Solde insuffisant.");
            }
        }

        public virtual void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance = Balance + amount;
                Console.WriteLine("Dépôt effectué.");
            }
            else
            {
                Console.WriteLine("Montant invalide.");
            }
        }

        protected void SetBalance(double balance)
        {
            Balance = balance;
        }

        public void ApplyInterest()
        {
            Balance = Balance + CalculInterets();
        }
    }
}