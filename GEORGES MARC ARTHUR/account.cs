using System;
using Bank2026.Models;

namespace Bank2026.Accounts;


public abstract class Account
{
    public string Number { get; }

    
    public double Balance { get; private set; }

    public Person Owner { get; }

    protected Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
    }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Dépôt refusé : le montant doit être positif.");
            return;
        }

        Balance += amount;
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Retrait refusé : le montant doit être positif.");
            return;
        }

        Balance -= amount;
    }

    
    protected abstract double CalculInterets();

    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }
}