
namespace Bank2026
{
    public class CurrentAccount : Account
    {
        public double CreditLine { get; set; }

        public CurrentAccount(
            string number,
            Person owner,
            double creditLine)
            : base(number, owner)
        {
            CreditLine = creditLine;
        }

        public override void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Le montant doit être positif.");
                return;
            }

            if (amount > Balance + CreditLine)
            {
                Console.WriteLine("Solde insuffisant.");
                return;
            }

            WithdrawFromBalance(amount);
        }

        private void WithdrawFromBalance(double amount)
        {
            ChangeBalance(-amount);
        }

        protected override double CalculInterets()
        {
            if (Balance > 0)
            {
                return Balance * 0.03;
            }
            else
            {
                return Balance * 0.0975;
            }
        }
    }
}
