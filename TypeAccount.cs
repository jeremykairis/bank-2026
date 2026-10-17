using System;

namespace Namespace_ExercicePerson;


public class SavingsAccount : Account
{

    public override void Withdraw(double amount)
    {
        if (Balance - amount < 0)
        {
            Console.WriteLine("Retrait refusé : solde insuffisant sur le carnet d'épargne.");
            return;
        }

        base.Withdraw(amount);
    }

    // Interets compte épargne
    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}


public class CurrentAccount : Account
{
    public double CreditLine { get; set; }

    public override void Withdraw(double amount)
    {
        if (Balance + CreditLine < amount)
        {
            Console.WriteLine("Retrait refusé : dépassement ligne de crédit.");
            return;
        }

        base.Withdraw(amount);
    }

    protected override double CalculInterets()
    {
        if (Balance >= 0)
        {
            return Balance * 0.03;
        }
        else
        {
            return Balance * 0.0975;
        }
    }
}