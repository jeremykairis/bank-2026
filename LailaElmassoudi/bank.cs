using System.Collections.Generic;
using Bank2026.Accounts;
using Bank2026.Persons;

namespace Bank2026.Banks
{
    class Bank
    {
        public Dictionary<string, Account> Accounts { get; }

        public string Name { get; set; }

        public Bank()
        {
            Accounts = new Dictionary<string, Account>();
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account.Number, account);
        }

        public void DeleteAccount(string number)
        {
            Accounts.Remove(number);
        }

        public double GetBalance(string number)
        {
            if (Accounts.ContainsKey(number))
            {
                return Accounts[number].Balance;
            }

            return 0;
        }

        public double GetTotalBalance(Person personne)
        {
            double somme = 0;

            foreach (Account account in Accounts.Values)
            {
                if (account.Owner == personne)
                {
                    somme = somme + account.Balance;
                }
            }

            return somme;
        }
    }
}