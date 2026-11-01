public class CurrentAccount(string number, Person owner) : Account(number, owner)
{
    public double CreditLine { get; set; }

    protected override double MinimumBalance => -CreditLine;

    protected override double CalculInterets()
    {
        return Balance > 0 ? Balance * 0.03 : Balance * 0.0975;
    }
}