namespace Banque
{
    public class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; private set; }

        public SavingsAccount(string number, Person person) : base(number, person) { }

        public SavingsAccount(string number, Person person, double initialBalance) : base(number, person, initialBalance) { }
    
        public override void Withdraw(double amount)       
        {
            base.Withdraw(amount);
            DateLastWithdraw = DateTime.Now;
        }

        protected override double CalculInterets()
        {
            return Balance * 0.045; 
        }
    }

}
