namespace Banque
{
    public abstract class Account : IBankAccount
    {
        public string Number { get; private set; } = string.Empty;
        public double Balance { get; private set; }
        public Person Owner { get; private set; } 

        public Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
        }

        public Account(string number, Person owner, double initialBalance) : this(number, owner)
        {
            Balance = initialBalance;
        }

        public event Action<Account>? NegativeBalanceEvent;

        protected void OnNegativeBalance()
        {
            NegativeBalanceEvent?.Invoke(this);
        }

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être positif");
            }

            Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être positif");
            }

            if (!CanWithdraw(amount))
            {
                throw new InsufficientBalanceException("Fonds insuffisants");
            }
            Balance -= amount;
        }

        protected virtual bool CanWithdraw(double amount)
        {
            return amount <= Balance;
        }

        public double GetBalance()
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


