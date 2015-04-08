using System;

namespace Bank
{
    public class BankAccount
    {
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";
        
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
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage );
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            Balance -= amount;
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

        public void UnfreezeAccount()
        {
            frozen = false;
        }
    }
}
