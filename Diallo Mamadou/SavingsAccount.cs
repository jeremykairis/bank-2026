public class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; private set; }

    public SavingsAccount(string number, Person owner)
        : base(number, owner)
    {
    }

    public SavingsAccount(string number, Person owner, double balance)
        : base(number, owner, balance)
    {
    }

    public override void Withdraw(double amount)
    {
        base.Withdraw(amount);
        DateLastWithdraw = DateTime.Now;
    }

    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}