using System;
using System.Collections.Generic;
using Bank2026.Accounts;
using Bank2026.Models;

namespace Bank2026.Services;

public class Bank
{
    
    public Dictionary<string, Account> Accounts { get; private set; } = new Dictionary<string, Account>();

    public string Name { get; set; }

    public Bank(string name)
    {
        Name = name;
    }

    public void AddAccount(Account account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine("Ajout refusé : ce numéro de compte existe déjà.");
            return;
        }

        Accounts.Add(account.Number, account);
    }

    public void DeleteAccount(string number)
    {
        if (!Accounts.ContainsKey(number))
        {
            Console.WriteLine("Suppression impossible : compte introuvable.");
            return;
        }

        Accounts.Remove(number);
    }

    
    public double GetBalance(string number)
    {
        if (!Accounts.ContainsKey(number))
        {
            Console.WriteLine("Compte introuvable.");
            return 0;
        }

        return Accounts[number].Balance;
    }

    
    public double GetTotalBalance(Person owner)
    {
        double total = 0;

        foreach (Account account in Accounts.Values)
        {
            if (account.Owner == owner)
                total += account.Balance;
        }

        return total;
    }
}