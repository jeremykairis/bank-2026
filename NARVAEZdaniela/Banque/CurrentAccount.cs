namespace Banque
{
    public class CurrentAccount : Account
    {
        private double _creditLine;
        public double CreditLine { get => _creditLine; set {
            if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(CreditLine), "La limite de credit ne doit pas être négatif");
                }
                _creditLine = value;
            }}

        public CurrentAccount(string number, Person person) : base(number, person) { }

        public CurrentAccount(string number, Person person, double initialBalance) : base (number, person, initialBalance) { }

        protected override bool CanWithdraw(double amount)
        {
            return amount <= Balance + CreditLine;
        }
        
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
            if (Balance < 0)
            {
                OnNegativeBalance();
            }
        }

        protected override double CalculInterets()
        {
            if (Balance > 0)
            {
                return Balance * 0.03; // 3% d'intérêt pour les soldes positifs
            }
            else
            {
                return Balance * 0.0975; // 9.75% d'intérêt pour les soldes négatifs
            }
        }
    }
}
