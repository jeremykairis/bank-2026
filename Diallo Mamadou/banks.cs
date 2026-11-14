public class Bank(string name)
{
    public string Name { get; set; } = name;
    public Dictionary<string, IBankAccount> Accounts { get; } = new();

    public void AddAccount(IBankAccount account)
    {
        if (!Accounts.TryAdd(account.Number, account))
            throw new InvalidOperationException($"Le compte {account.Number} existe déjà.");

        account.NegativeBalanceEvent += NegativeBalanceAction;
    }

    public void DeleteAccount(string number)
    {
        if (!Accounts.Remove(number, out var account))
            throw new KeyNotFoundException($"Le compte {number} n'existe pas.");

        account.NegativeBalanceEvent -= NegativeBalanceAction;
    }

    public double GetBalance(string number)
    {
        if (!Accounts.TryGetValue(number, out var account))
            throw new KeyNotFoundException($"Le compte {number} n'existe pas.");
        return account.Balance;
    }

    public double GetTotalBalance(Person owner)
    {
        var total = 0.0;
        foreach (var pair in Accounts)
        {
            if (pair.Value.Owner == owner)
                total += pair.Value.Balance;
        }
        return total;
    }

    private void NegativeBalanceAction(Account account)
        => Console.WriteLine($"Le numéro de compte {account.Number} vient de passer en négatif");
}