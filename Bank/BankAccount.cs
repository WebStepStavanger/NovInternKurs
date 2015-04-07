using System;

namespace Bank
{
    public class BankAccount
    {
        private readonly string customerName;

        private bool frozen;
        
        public BankAccount(string customerName, double balance)
        {
            this.customerName = customerName;
            this.Balance = balance;
        }

        public string CustomerName
        {
            get { return customerName; }
        }

        public double Balance { get; private set; }

        public void Debit(double amount)
        {
            if (frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            Balance += amount;
        }

        public void Credit(double amount)
        {
            if (frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            Balance += amount;
        }

        public void FreezeAccount()
        {
            frozen = true;
        }

        private void UnfreezeAccount()
        {
            frozen = false;
        }
    }
}
