public abstract class Account(string number, Person owner)
{
    public string Number { get; set; } = number;
    public double Balance { get; private set; }
    public Person Owner { get; set; } = owner;

    protected virtual double MinimumBalance => 0;

    protected abstract double CalculInterets();

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
            throw new InvalidOperationException("Solde insuffisant.");

        Balance -= amount;
    }

    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }
}