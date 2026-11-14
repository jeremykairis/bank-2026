class SavingsAccount : Account
{
    public SavingsAccount(string Number, Person Owner): base(Number, Owner){}
    public DateTime DateLastWithdraw{ get; private set; }

    protected override double CalculInterets()
    {
        return Balance*0.045;
    }
}
