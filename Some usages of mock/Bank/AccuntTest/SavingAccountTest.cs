using Account;
using NUnit;
using Moq;
using Moq.Protected;

namespace AccuntTest
{
    public class Tests
    {
        private SavingsAccount account = null;

        [SetUp]
        public void Setup()
        {
            account = new SavingsAccount();
        }

        [Test]
        public void testCreditAccountWhenCurrentBalanceIs5000()
        {
            var savingsAccount = new Mock<SavingsAccount> { CallBase = true };
            savingsAccount.Setup(account => account.GetBalance()).Returns(5000.00);
            savingsAccount.Protected().Setup<double>("UpdateBalanceInDB", ItExpr.IsAny<double>()).Returns(5000).Verifiable();
            

            double actualBalance =savingsAccount.Object.CreditAccount(15000.00);
            double expectedBalance= 20000.00;

            Assert.AreEqual(expectedBalance, actualBalance);
            savingsAccount.Verify(account=> account.GetBalance(), Times.Once());
        }
    }
}