using System.Collections.Generic;
using System.Linq;
using Bank.Interfaces;

namespace Bank
{
    public class BankAccounts : IBankAccounts
    {
        private readonly IBankContext context;
        
        public BankAccounts(IBankContext context)
        {
            this.context = context;
        }

        public List<BankAccount> GetBankAccounts()
        {
            return context.BankAccounts.OrderBy(c => c.CustomerName).ToList();
        }
    }
}
