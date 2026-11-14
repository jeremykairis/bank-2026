interface IBankAccount
{
    double Balance { get;}
    void Deposit(double amount);
    void Withdraw(double amount);
    void ApplyInterest();
    Person? Owner {get;}
    string? Number {get;}
    event Action<Account>? NegativeBalanceEvent;
}