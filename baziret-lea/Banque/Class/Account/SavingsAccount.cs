class SavingsAccount : Account
{
    public DateTime DateLastWithdraw;

    protected override double CalculInterets()
    {
        return Balance*0.045;
    }
}
