public interface IBankAccount : IAccount
{
    string Number { get; }

    Person Owner { get; }

    event Action<Account>? NegativeBalanceEvent;

    void ApplyInterest();
}