using Banking;

using System;

using Xunit;

namespace UnitTestBanking {

    public class TestAccount : IDisposable {

        Account account;

        public TestAccount() {
            account = new Account();
        }

        public void Dispose() {
            account = null;
        }

        [Theory]
        [InlineData(100, 100)]
        [InlineData(200, 200)]
        [InlineData(300, 300)]
        public void TestDeposit(decimal balance, decimal amount) {
            account.Deposit(amount);
            Assert.Equal(balance, account.Balance);
        }
        [Fact]
        public void TestNegativeDepositAmount() {
            Action depNegAmt = () => account.Deposit(-100);
            Assert.Throws<Exception>(depNegAmt);
        }
    }
}
