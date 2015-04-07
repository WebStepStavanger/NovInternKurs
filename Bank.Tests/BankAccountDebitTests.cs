using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;

namespace Bank.Tests
{
    [TestClass]
    public class BankAccountDebitTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            //Arrange
            const double balance = 999.99;
            const int debitAmount = 199;
            var account = new BankAccount("Test account", balance);
            //Act
            account.Debit(debitAmount);
            //Assert
            Assert.AreEqual(800.99, account.Balance, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_Frozen_ThrowsException()
        {
            //Arrange
            var account = new BankAccount("Test account", 0);
            account.FreezeAccount();
            //act && assert
            ExceptionAssert.Throws<Exception>(() => account.Debit(10), "Account frozen");
        }
    }
}
