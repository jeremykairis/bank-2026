var person = new Person("Mamadou", "Diallo", new DateTime(2000, 9, 25));
Console.WriteLine($"Titulaire : {person.FirstName} {person.LastName}, né le {person.BirthDate:dd-MM-yyyy}");

var bank = new Bank("Ma Banque");

// Compte courant avec une ligne de crédit de 500
IBankAccount account = new CurrentAccount("BE01", person) { CreditLine = 500 };
bank.AddAccount(account);   // la banque s'abonne à l'événement
account.Deposit(1000);
account.Withdraw(1200);     // le compte passe en négatif : l'événement se déclenche
Console.WriteLine($"Solde BE01 : {account.Balance}");

// Exercice 18 : retrait impossible
try
{
    account.Withdraw(400);
}
catch (InsufficientBalanceException ex)
{
    Console.WriteLine($"Refusé : {ex.Message}");
}

// Exercice 18 : montant invalide
try
{
    account.Deposit(-50);
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Dépôt refusé : le montant doit être positif.");
}

// Exercice 19 : ligne de crédit négative
try
{
    _ = new CurrentAccount("BE99", person) { CreditLine = -100 };
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Ligne de crédit refusée : elle doit être positive ou nulle.");
}

Console.WriteLine($"Nombre de comptes : {bank.Accounts.Count}");
Console.WriteLine($"GetBalance BE01 : {bank.GetBalance("BE01")}");

foreach (KeyValuePair<string, IBankAccount> pair in bank.Accounts)
{
    Console.WriteLine($"{pair.Key} : {pair.Value.Balance}");
}

// Deux autres comptes
IBankAccount account2 = new CurrentAccount("BE02", person);
account2.Deposit(300);
bank.AddAccount(account2);

IBankAccount savings = new SavingsAccount("BE10", person);
savings.Deposit(500);
savings.Withdraw(200);
bank.AddAccount(savings);

Console.WriteLine($"Total de {person.FirstName} : {bank.GetTotalBalance(person)}");

// Intérêts
foreach (KeyValuePair<string, IBankAccount> pair in bank.Accounts)
{
    pair.Value.ApplyInterest();
}

foreach (KeyValuePair<string, IBankAccount> pair in bank.Accounts)
{
    Console.WriteLine($"{pair.Key} : {Math.Round(pair.Value.Balance, 2)}");
}
Console.WriteLine($"Total après intérêts : {Math.Round(bank.GetTotalBalance(person), 2)}");

// Suppression
bank.DeleteAccount("BE01");
bank.DeleteAccount("BE02");
bank.DeleteAccount("BE10");
Console.WriteLine($"Après suppression : {bank.Accounts.Count} compte(s)");

// Constructeur avec solde (cas d'une base de données)
IBankAccount fromDatabase = new SavingsAccount("BE20", person, 1000);
Console.WriteLine($"Compte chargé avec solde initial : {fromDatabase.Balance}");