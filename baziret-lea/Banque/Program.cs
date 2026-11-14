System.Console.WriteLine("Début programme:\n");

Bank banque = new Bank();
banque.Name = "nomDeBanque";

Person Lea = new Person("Lea", "Baziret", new DateTime(2006,02,08));

CurrentAccount myAccount = new CurrentAccount("BE123456789", Lea, 1200);


SavingsAccount mySavingsAccount = new SavingsAccount("BE987654321", Lea);


banque.AddAccount(myAccount);
banque.AddAccount(mySavingsAccount);

myAccount.Deposit(500);
mySavingsAccount.Deposit(67);

Console.WriteLine("Solde courant avant intérêt : " + myAccount.Balance);
Console.WriteLine("Solde épargne avant intérêt: " + mySavingsAccount.Balance);
Console.WriteLine("Total de Lea avant intérêt: " + banque.GetTotalSumAccount(Lea));
System.Console.WriteLine("\n");

myAccount.ApplyInterest();
mySavingsAccount.ApplyInterest();

Console.WriteLine("Solde courant : " + myAccount.Balance);
Console.WriteLine("Solde épargne : " + mySavingsAccount.Balance);
Console.WriteLine("Total de Lea : " + banque.GetTotalSumAccount(Lea));

//test pour voir si les throw exceptions fonctionnent. OK
try
{
    CurrentAccount test = new CurrentAccount("BE000", Lea, -100);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine("Erreur : " + ex.Message);
}

try { myAccount.Deposit(-50); }
catch (ArgumentOutOfRangeException ex) { Console.WriteLine("Dépôt refusé : " + ex.Message); }

try { mySavingsAccount.Withdraw(1000); }
catch (InsufficientBalanceException ex) { Console.WriteLine("Retrait refusé : " + ex.Message); }

myAccount.Withdraw(1500);   // passe en négatif : la banque affiche l'alerte