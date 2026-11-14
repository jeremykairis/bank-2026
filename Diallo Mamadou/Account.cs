public abstract class Account : IBankAccount
{
    public event Action<Account>? NegativeBalanceEvent;

    public string Number { get; private set; }
    public double Balance { get; private set; }
    public Person Owner { get; private set; }

    protected virtual double MinimumBalance => 0;

    // Constructeur 1 : numéro et titulaire
    protected Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
    }

    // Constructeur 2 : numéro, titulaire et solde (cas d'une base de données)
    protected Account(string number, Person owner, double balance) : this(number, owner)
    {
        Balance = balance;
    }

    protected abstract double CalculInterets();

    protected virtual void OnNegativeBalance()
        => NegativeBalanceEvent?.Invoke(this);

    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être positif.");
        Balance += amount;
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant doit être positif.");
        if (Balance - amount < MinimumBalance)
            throw new InsufficientBalanceException("Solde insuffisant.");
        Balance -= amount;
    }

    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }
}