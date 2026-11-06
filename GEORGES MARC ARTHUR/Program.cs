using System;
using Bank2026.Accounts;
using Bank2026.Models;
using Bank2026.Services;

Console.WriteLine("=== Scénario d'utilisation : Bank-2026 ===");


var laila = new Person { FirstName = "Laila", LastName = "Massoudi", BirthDate = new DateTime(2005, 4, 12) };
var souleyman = new Person { FirstName = "Souleyman", LastName = "Conde", BirthDate = new DateTime(2000, 9, 3) };


var bank = new Bank("Bank-2026");

var lailaCurrent = new CurrentAccount("BE01-1234", laila, 500);
var lailaSavings = new SavingsAccount("BE01-4321", laila);
var souleymanCurrent = new CurrentAccount("BE01-5678", souleyman, 200);

bank.AddAccount(lailaCurrent);
bank.AddAccount(lailaSavings);
bank.AddAccount(souleymanCurrent);
Console.WriteLine($"{bank.Name} : {bank.Accounts.Count} comptes ouverts.");


Console.WriteLine("\n--- Dépôts et retraits ---");
lailaCurrent.Deposit(1000);
lailaSavings.Deposit(2000);
souleymanCurrent.Deposit(100);

lailaCurrent.Withdraw(1300);
Console.WriteLine($"{lailaCurrent.Number} : {lailaCurrent.Balance:F2} € (ligne de crédit {lailaCurrent.CreditLine})");

lailaSavings.Withdraw(500);
Console.WriteLine($"{lailaSavings.Number} : {lailaSavings.Balance:F2} € (dernier retrait : {lailaSavings.DateLastWithdraw})");


Console.WriteLine("\n--- Retraits refusés ---");
souleymanCurrent.Withdraw(1000);
lailaSavings.Withdraw(5000);


Console.WriteLine("\n--- Soldes ---");
Console.WriteLine($"Solde de {lailaCurrent.Number} : {bank.GetBalance(lailaCurrent.Number):F2} €");
Console.WriteLine($"Total des comptes de {laila.FirstName} {laila.LastName} : {bank.GetTotalBalance(laila):F2} €");


Console.WriteLine("\n--- Après application des intérêts ---");
foreach (var account in bank.Accounts.Values)
    account.ApplyInterest();

foreach (var account in bank.Accounts.Values)
    Console.WriteLine($"{account.Number} ({account.Owner.FirstName} {account.Owner.LastName}) : {account.Balance:F2} €");


Console.WriteLine("\n--- Suppression ---");
bank.DeleteAccount(souleymanCurrent.Number);
Console.WriteLine($"Comptes restants : {bank.Accounts.Count}");