namespace Banque
{
    public class Bank
    {
        public Dictionary<string, IBankAccount> Accounts { get; private set; }= new Dictionary<string, IBankAccount>();
        public string Name { get; set; } = string.Empty;

        public void AddAccount(IBankAccount account)
        {
            if (Accounts.ContainsKey(account.Number))
            {
                throw new Exception("Le compte existe déjà");
            }
            Accounts.Add(account.Number, account);

            if (account is Account a)
            {
                a.NegativeBalanceEvent += NegativeBalanceAction;
            }
        }

        public void DeleteAccount(string number)
        {
            if (!Accounts.ContainsKey(number))
            {
                throw new Exception("Le compte n'existe pas");
            }
            Accounts.Remove(number);
        }

        public double TotalBalance(Person owner)
        {
            double totalBalance = 0;
            foreach (var account in Accounts.Values)
            {
                if (account.Owner == owner)
                {
                    totalBalance += account.Balance;
                }
            }
            return totalBalance;
        }

        public void NegativeBalanceAction(Account account)
        {
            Console.WriteLine($"Le numéro de compte {account.Number} vient de passer en négatif.");
        }

    }
}