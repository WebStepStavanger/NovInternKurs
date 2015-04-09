using System.Collections.Generic;
using System.Linq;
using Bank.Interfaces;

namespace Bank
{
    public class BankAccounts : IBankAccounts
    {
        private readonly BankContext bankContext = new BankContext();
        
        public List<BankAccount> GetBankAccounts()
        {
            return bankContext.BankAccounts.ToList();
        }
    }

    
}
