interface IAccount
{
    //propriétés d'office public.
    //Tout comme abstract, pas de "corp" pour les methodes, juste leur nom.
    double Balance { get;}
    void Deposit(double amount);
    void Withdraw(double amount);   
}