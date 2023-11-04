using WithDrawExceptions.Entities.Exceptions;

namespace WithDrawExceptions.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithDrawLimit { get; set; }
        public double DepositLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawlimit, double depositlimit) 
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withdrawlimit;
            DepositLimit = depositlimit;
        }

        public void Deposit(double amount)
        {
            if (amount > DepositLimit)
            {
                throw new DomainException("Deposit error: The amount exceeds deposit limit");
            }
            Balance += amount;
        }

        public void WithDraw(double amount)
        {
            if (amount > WithDrawLimit)
            {
                throw new DomainException("Withdraw error: The amount exceeds withdraw limit");
            }
            if (amount > Balance)
            {
                throw new DomainException("Withdraw error: Not enough balance");
            }
            Balance -= amount;
        }

    }
}
