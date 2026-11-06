using System;
using Bank2026.Models;

namespace Bank2026.Accounts;

public class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; private set; }

    public SavingsAccount(string number, Person owner)
        : base(number, owner)
    {
    }

    public override void Withdraw(double amount)
    {
        
        if (amount <= 0 || amount > Balance)
        {
            Console.WriteLine("Retrait refusé sur le livret : montant invalide ou solde insuffisant.");
            return;
        }

        base.Withdraw(amount);
        DateLastWithdraw = DateTime.Now;
    }

    
    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}