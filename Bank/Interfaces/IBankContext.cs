using System.Collections.Generic;

namespace Bank.Interfaces
{
    public interface IBankContext
    {
        IList<BankAccount> BankAccounts { get; }
    }
}
