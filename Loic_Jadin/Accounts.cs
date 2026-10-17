
namespace Bank2026
{
    public abstract class Account
    {
        public string Number { get; set; } = string.Empty;
        public double Balance { get; private set; }
        public Person Owner { get; set; }

        public Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            Balance = 0;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Le montant doit être positif.");
                return;
            }

            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Le montant doit être positif.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Solde insuffisant.");
                return;
            }

            Balance -= amount;
        }

        
        protected void ChangeBalance(double amount)
        {
            Balance += amount;
        }

        protected double GetBalanceValue()
        {
            return Balance;
        }

        protected double GetCurrentBalance()
        {
            return Balance;
        }

        protected abstract double CalculInterets();

        public void ApplyInterest()
        {
            Balance += CalculInterets();
        }
    }
}
