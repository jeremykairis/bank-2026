public class CurrentAccount : Account
{
    private double _creditLine;

    public double CreditLine
    {
        get => _creditLine;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "La ligne de crédit doit être positive ou nulle.");
            _creditLine = value;
        }
    }

    public CurrentAccount(string number, Person owner)
        : base(number, owner)
    {
    }

    public CurrentAccount(string number, Person owner, double balance)
        : base(number, owner, balance)
    {
    }

    protected override double MinimumBalance => -CreditLine;

    public override void Withdraw(double amount)
    {
        var etaitPositif = Balance >= 0;

        base.Withdraw(amount);

        if (etaitPositif && Balance < 0)
            OnNegativeBalance();
    }

    protected override double CalculInterets()
    {
        return Balance > 0 ? Balance * 0.03 : Balance * 0.0975;
    }
}