


namespace Bank2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Bank 2026");

            Person person1 = new Person
            {
                FirstName = "Loïc",
                LastName = "Jadin",
                BirthDate = new DateTime(2002, 11, 13)
            };

            Person person2 = new Person
            {
                FirstName = "Lolo",
                LastName = "Lala",
                BirthDate = new DateTime(2002, 5, 20)
            };

            CurrentAccount current1 =
                new CurrentAccount("BE1", person1, 200);

            SavingsAccount savings1 =
                new SavingsAccount("BE2", person1);

            CurrentAccount current2 =
                new CurrentAccount("BE3", person2, 100);

            bank.AddAccount(current1);
            bank.AddAccount(savings1);
            bank.AddAccount(current2);

            current1.Deposit(1000);
            savings1.Deposit(2000);
            current2.Deposit(500);

            current1.Withdraw(300);
            savings1.Withdraw(200);

            Console.WriteLine("BANK 2026");
            Console.WriteLine($"Banque : {bank.Name}");

            Console.WriteLine("Comptes");

            Console.WriteLine($"{person1.FirstName} {person1.LastName} - " + $"Compte courant : {current1.Balance} €");

            Console.WriteLine($"{person1.FirstName} {person1.LastName} - " + $"Compte épargne : {savings1.Balance} €");

            Console.WriteLine($"{person2.FirstName} {person2.LastName} - " + $"Compte courant : {current2.Balance} €");

            Console.WriteLine("Consultation");
            Console.WriteLine($"Solde du compte BE1 : {bank.GetBalance("BE1")} €");

            Console.WriteLine($"Total de {person1.FirstName} : " + $"{bank.GetTotalBalance(person1):F2} €");

            Console.WriteLine("Application des intérêt");

            current1.ApplyInterest();
            savings1.ApplyInterest();
            current2.ApplyInterest();

            Console.WriteLine($"Compte BE001 après intérêts : {current1.Balance:F2} €");

            Console.WriteLine($"Compte BE002 après intérêts : {savings1.Balance:F2} €");

            Console.WriteLine($"Compte BE003 après intérêts : {current2.Balance:F2} €");

            Console.WriteLine($"Total de {person1.FirstName} après intérêts : " + $"{bank.GetTotalBalance(person1):F2} €");

            bank.DeleteAccount("BE3");

            Console.WriteLine();
            Console.WriteLine(
                $"Nombre de comptes après suppression : " +
                $"{bank.Accounts.Count}");
        }
    }
}
