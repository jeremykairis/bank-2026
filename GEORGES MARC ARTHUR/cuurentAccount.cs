using System;
using Bank2026.Models;

namespace Bank2026.Accounts;

public class CurrentAccount : Account
{
    public double CreditLine { get; set; }

    public CurrentAccount(string number, Person owner, double creditLine)
        : base(number, owner)
    {
        CreditLine = creditLine;
    }

    public override void Withdraw(double amount)
    {
        
        if (Balance - amount < -CreditLine)
        {
            Console.WriteLine("Retrait refusé : la ligne de crédit serait dépassée.");
            return;
        }

        base.Withdraw(amount);
    }

    
    protected override double CalculInterets()
    {
        if (Balance >= 0)
            return Balance * 0.03;
        else
            return Balance * 0.0975;
    }
}