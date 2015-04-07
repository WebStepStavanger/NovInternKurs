using System.Collections.Generic;
using Bank.Interfaces;

namespace Bank
{
    public class BankContext : IBankContext
    {
        public IList<BankAccount> BankAccounts
        {
            get
            {
                return new List<BankAccount>
                {
                    new BankAccount("Skov, Mikael", -200000),
                    new BankAccount("Brattetaule, Øystein", 1.56),
                    new BankAccount("Fatland, Roy", 1435243.99)
                };
            }
        }
    }
}

    

