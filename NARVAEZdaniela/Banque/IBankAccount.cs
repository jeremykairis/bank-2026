namespace Banque
{
    public interface IBankAccount : IAccount
    {
        void ApplyInterest();
        string Number { get; }
        Person Owner { get; }
    }
}