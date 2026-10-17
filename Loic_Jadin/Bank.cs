
namespace Bank2026
{
    public class Bank
    {
        public Dictionary<string, Account> Accounts { get; private set; }
        public string Name { get; set; }

        public Bank(string name)
        {
            Name = name;
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
            return Accounts[number].Balance;
        }

        public double GetTotalBalance(Person owner)
        {
            double total = 0;

            foreach (Account account in Accounts.Values)
            {
                if (account.Owner == owner)
                {
                    total += account.Balance;
                }
            }

            return total;
        }
    }
}
