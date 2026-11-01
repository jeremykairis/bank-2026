public class SavingsAccount(string number, Person owner) : Account(number, owner)
{
    public DateTime DateLastWithdraw { get; private set; }

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