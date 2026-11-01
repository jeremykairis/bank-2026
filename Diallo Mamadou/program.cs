var person = new Person
{
    FirstName = "Mamadou",
    LastName = "Diallo",
    BirthDate = new DateTime(1990, 1, 1)
};

Console.WriteLine($"{person.FirstName} {person.LastName}, né le {person.BirthDate:dd/MM/yyyy}");

var account = new CurrentAccount("BE01", person) { CreditLine = 500 };

account.Deposit(1000);
account.Withdraw(1200);
Console.WriteLine($"Solde : {account.Balance}");

try
{
    account.Withdraw(400);
}
catch (InvalidOperationException e)
{
    Console.WriteLine($"Refusé : {e.Message}");
}

var bank = new Bank("Ma Banque");
bank.AddAccount(account);
Console.WriteLine($"Ma Banque : {bank.Accounts.Count} compte(s)");
Console.WriteLine($"Solde de BE01 : {bank.GetBalance("BE01")}");

foreach (KeyValuePair<string, Account> pair in bank.Accounts)
    Console.WriteLine($"{pair.Key} -> {pair.Value.Balance}");

var account2 = new CurrentAccount("BE02", person);
account2.Deposit(300);
bank.AddAccount(account2);

var savings = new SavingsAccount("BE10", person);
savings.Deposit(500);
savings.Withdraw(200);
bank.AddAccount(savings);
Console.WriteLine($"Épargne : {savings.Balance}, dernier retrait : {savings.DateLastWithdraw:dd/MM/yyyy}");
Console.WriteLine($"Total de {person.FirstName} : {bank.GetTotalBalance(person)}");

bank.DeleteAccount("BE01");
bank.DeleteAccount("BE02");
bank.DeleteAccount("BE10");
Console.WriteLine($"Après suppression : {bank.Accounts.Count} compte(s)");