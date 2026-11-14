
class CurrentAccount : Account
{   
    //Constructeur nécessaire car il y en a un dans Account.
    // base() renvoie les info à Account
    public CurrentAccount(string number, Person owner, double creditLine)
        : base(number, owner)
    {
        CreditLine = creditLine;
    }

    /*
    On peut faire un "if" dans une propriété, pour ca, il faut d'abord
    écrire un champ privé qui stock la valeur.
    */
    private double _creditLine;
    public double CreditLine
    {
        get { return _creditLine; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "La ligne de crédit doit être supérieure ou égale à 0.");
            }
            _creditLine = value;
        }
    }
    

    //Il n'est pas nécessaire de mettre un paramètre dans la méthode,
    //  car la méthode traite déjà le "current account".
    public double GetBalance()
    {
        return Balance;
    }

    protected override double CalculInterets()
    {
        if (Balance > 0)
        {
            return Balance* 0.03;
        }
        return Balance*0.0975;
    }

    /*
        On réécrit Withdraw car dans la méthode de base, on ne prend pas en compte CreditLine.
    */
    public override void Withdraw(double amount)
    {
            /*
            Notions bancaires pour mieux comprendre ce qui se passe:
                La ligne de crédit, c’est le découvert autorisé. Exemple : solde 100, ligne de crédit 1200, retrait de 500.

                    Avec Balance - amount < 0 : 100 - 500 = -400, donc refusé. Mais ce compte a le droit d’aller jusqu’à -1200 : refus injustifié.
                    Avec Balance + CreditLine - amount < 0 : 100 + 1200 - 500 = 800, donc accepté.
            */
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (Balance + CreditLine - amount < 0)
        {
            throw new InsufficientBalanceException();
        }

        bool etaitPositif = Balance >= 0;
        base.Withdraw(amount); //"base" désigne la classe mère. cette ligne dit: "exécute la version de Withdraw écrite dans Account", car seule Account peut modifier Balance (private set).
                                // Finalement, ce "Withdraw" est juste un test, l'action se fera dans Account.

        if (etaitPositif && Balance < 0)
        {
            OnNegativeBalance();
        }
    }

}
