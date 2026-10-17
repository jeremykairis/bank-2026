var p1 = new Person();
p1.FirstName = "Gaetan";
p1.LastName = "Leplae";
p1.BirthDate = new DateTime(2002, 1, 17);

var currentAcc = new CurrentAccount();
currentAcc.Number = "BE12-3456-7890";
currentAcc.Owner = p1;
currentAcc.CreditLine = 200;
currentAcc.Deposit(1000);

var savingsAcc = new SavingsAccount();
savingsAcc.Number = "BE12-3456-7891";
savingsAcc.Owner = p1;
savingsAcc.DateLastWithdraw = DateTime.Now;
savingsAcc.Deposit(10000);

var myBank = new Bank();
myBank.Name = "Fortis";

myBank.AddAccount(currentAcc);
myBank.AddAccount(savingsAcc);

Console.WriteLine($"Solde de {p1.FirstName} {p1.LastName} avec :");
myBank.GetallBalanceAccount(p1);

class Person
{
    public string FirstName;
    public string LastName;
    public DateTime BirthDate;
}

abstract class Account
{
    public string Number;
    public double Balance { get; protected set; }
    public Person Owner;

    protected abstract double CalculInterets();

    public void ApplyInterests()
    {
        Balance += CalculInterets();
    }
}

class CurrentAccount : Account
{
    public double CreditLine;

    public double GetBalance()
    {
        return Balance;
    }

    public void Withdraw(double amount)
    {
        Balance -= amount;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    protected override double CalculInterets()
    {
        if (Balance > 0)
        {
            return Balance * 0.03;
        }
        else
        {
            return Balance * 0.0975;
        }
    }
}

class SavingsAccount : Account
{
    public DateTime DateLastWithdraw;

    public void Withdraw(double amount)
    {
        Balance -= amount;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}

class Bank
{
    public Dictionary<string, Account> Accounts = new();
    public string Name;

    public void AddAccount(Account account)
    {
        Accounts.Add(account.Number, account);
    }

    public void DeleteAccount(string number)
    {
        Accounts.Remove(number);
    }

    public void GetallBalanceAccount(Person owner)
    {
        double allAcoountBalance = 0;
        foreach (var b in Accounts.Values)
        {
            allAcoountBalance += b.Balance;
        }

        Console.Write(allAcoountBalance);
    }
}