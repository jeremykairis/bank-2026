System.Console.WriteLine("Début programme:\n");

Bank banque = new Bank();
banque.Name = "nomDeBanque";

Person Lea = new Person("Lea", "Baziret", new DateTime(2006,02,08));

CurrentAccount myAccount = new CurrentAccount();
myAccount.Number = "BE123456789";
myAccount.CreditLine = 1200;
myAccount.Owner = Lea;

SavingsAccount mySavingsAccount = new SavingsAccount();
mySavingsAccount.Number = "BE987654321";
mySavingsAccount.Owner = Lea;

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