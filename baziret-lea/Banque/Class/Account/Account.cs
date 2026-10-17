
abstract class Account
{
    public string? Number;
    public double Balance { get; private set; }
    public Person? Owner;

    //Note: "virtual" car le comportement de Withdraw change en fonction du type d'Account.
    public virtual void Withdraw(double amount)
    {
        Balance -= amount;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    //Note: quand une méthode est "abstraite", il faut d'office l'écrire dans les classes filles.
    protected abstract double CalculInterets();

    /*Ajouter une méthode « public » à la classe « Account » appelée « ApplyInterest » qui 
additionnera le solde avec le retour de la méthode « CalculInterest ».*/
    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }
}
