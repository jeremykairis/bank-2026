using System;

namespace Namespace_ExercicePerson;

// Account est maintenant abstraite
public abstract class Account
{
    public required string Number { get; set; }
    
    // Lecture seule depuis l'extérieur, modifiable uniquement dans Account
    public double Balance { get; private set; }
    
    public required Person Owner { get; set; }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant du dépôt doit être positif (>= 0 ).");
            return;
        }

        Balance -= amount;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant du dépôt doit être positif (>= 0 ).");
            return;
        }

        Balance += amount;
    }

    
    protected abstract double CalculInterets();


    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }
}