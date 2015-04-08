using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;

namespace Bank.Tests
{
    [TestClass]
    public class BankAccountDebitTests
    {
        private const string testAccountName = "Brattetaule, Øystein";

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            //Arrange
            var account = new BankAccount(testAccountName, 99.99);
            //Act
            account.Debit(19);
            //Assert
            Assert.AreEqual(800.99, account.Balance, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_Frozen_ThrowsException()
        {
            //Arrange
            var account = new BankAccount(testAccountName, 0);
            account.FreezeAccount();
            //act && assert
            ExceptionAssert.Throws<Exception>(() => account.Debit(10), "Account frozen");
        }

        [TestMethod]
        public void Debit_WhenAmountIsGreaterThanBalance_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            var account = new BankAccount(testAccountName, 11.99);
            //Act & Assert
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => account.Debit(20), BankAccount.DebitAmountExceedsBalanceMessage, ExceptionMessageCompareOptions.Contains);
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            var account = new BankAccount(testAccountName, 11.99);
            //Act & Assert
            ExceptionAssert.Throws<ArgumentOutOfRangeException>(() => account.Debit(-1), BankAccount.DebitAmountLessThanZeroMessage, ExceptionMessageCompareOptions.Contains);
        }
    }
}
