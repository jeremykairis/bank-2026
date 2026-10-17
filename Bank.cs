using System;

using Namespace_ExercicePerson;

public class Bank
{
    public required string Name { get; set; }

    
    public Dictionary<string, Account> Accounts { get; } = new Dictionary<string, Account>(); // J'ai modifié CurrentAccount -> Account selon les consignes


    public void AddAccount(Account account)
    {
        if (!Accounts.ContainsKey(account.Number))
        {
            Accounts.Add(account.Number, account);
        }
        else
        {
            Console.WriteLine($"Le compte {account.Number} existe déjà.");
        }
    }

    
    public void DeleteAccount(string number)
    {
        if (Accounts.ContainsKey(number))
        {
            Accounts.Remove(number);
        }
        else
        {
            Console.WriteLine($"Le compte {number} est introuvable.");
        }
    }


    public double GetAccountBalance(string number)
    {
        if (Accounts.TryGetValue(number, out Account? account))
        {
            return account.Balance;
        }

        Console.WriteLine($"Le compte {number} est introuvable.");
        return 0;
    }

   
    public double GetTotalBalance(Person Owner)
    {
        double total = 0;

        foreach (Account account in Accounts.Values)
        {
            if (account.Owner == Owner)
            {total += account.Balance;}
        }

        return total;
    }
}