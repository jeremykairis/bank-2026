using System;
using Bank2026.Accounts;
using Bank2026.Banks;
using Bank2026.Persons;

namespace Bank2026
{
    class Program
    {
        static void Main(string[] args)
        {
            // Créer une personne
            Person personne = new Person
            {
                FirstName = "Laila",
                LastName = "Saida",
                BirthDate = new DateTime(2005, 1, 25)
            };

            // Créer un compte courant
            CurrentAccount compte = new CurrentAccount
            {
                Number = "001",
                Owner = personne,
                CreditLine = 200
            };

            // Créer un compte épargne
            SavingsAccount epargne = new SavingsAccount
            {
                Number = "002",
                Owner = personne
            };

            // Créer une banque
            Bank banque = new Bank
            {
                Name = "Ma Banque"
            };

            // Ajouter les comptes
            banque.AddAccount(compte);
            banque.AddAccount(epargne);

            // Effectuer des opérations
            compte.Deposit(1000);
            compte.Withdraw(200);

            epargne.Deposit(500);
            epargne.Withdraw(100);

            // Appliquer les intérêts
            compte.ApplyInterest();
            epargne.ApplyInterest();

            // Afficher les résultats
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Bienvenue dans " + banque.Name);

            Console.WriteLine("Prénom : " + personne.FirstName);
            Console.WriteLine("Nom : " + personne.LastName);
            Console.WriteLine("Date de naissance : " + personne.BirthDate.ToString("dd/MM/yyyy"));

            Console.WriteLine("--------------------------------");

            Console.WriteLine("Solde compte courant : " + banque.GetBalance("001") + " €");

            Console.WriteLine("Solde compte épargne : " + banque.GetBalance("002") + " €");

            Console.WriteLine("Solde total : " + banque.GetTotalBalance(personne) + " €");

            Console.WriteLine("--------------------------------");

            Console.WriteLine("Appuyez sur une touche pour quitter.");
            Console.ReadLine();
        }
    }
}