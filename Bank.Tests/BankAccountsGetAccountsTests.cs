using System.Collections.Generic;
using Bank.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bank.Tests
{
    [TestClass]
    public class BankAccountsGetAccountsTests
    {
        private Mock<IBankContext> mockContext;
            
        [TestInitialize]
        public void TestSetup()
        {
            mockContext = new Mock<IBankContext>();
            mockContext.Setup(m => m.BankAccounts).Returns(new List<BankAccount>
            {
                new BankAccount("Skov, Mikael", -99999.99),
                new BankAccount("Brattetaule, Øystein", 1.56),
                new BankAccount("Fatland, Roy", 1435243.99)
            });
        }
        
        [TestMethod]
        public void GetBankAccounts_ReturnsBankAccounts_Sorted()
        {
            //Arrange
            var bankAccounts = new BankAccounts(mockContext.Object);
            //Act
            var accounts = bankAccounts.GetBankAccounts();
            //Assert
            Assert.AreEqual(3, accounts.Count);
            Assert.AreEqual("Brattetaule, Øystein", accounts[0].CustomerName);
            Assert.AreEqual("Fatland, Roy", accounts[1].CustomerName);
            Assert.AreEqual("Skov, Mikael", accounts[2].CustomerName);
            mockContext.Verify(p => p.BankAccounts, Times.Once);
        }
    }
}
