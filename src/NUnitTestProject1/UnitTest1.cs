using NUnit.Framework;
using Moneybox.App.Features;
using System;
using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using Moneybox.App;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void _WithdrawTest()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            Account account = new Account("Mr. Bryan Walton", beginningBalance);

            // Act
            account.WithdrawTest(debitAmount);

            // Assert
            decimal actual = (decimal)account.AccountBalance;
            Assert.AreEqual(expected, (double)actual, 0.001, "Account not debited correctly");
        }

        [Test]
        public void _DepositTest()
        {
            // Arrange
            double beginningBalance = 11.99;
            double depositAmount = 4.55;
            double expected = 16.54;
            Account account = new Account("Mr. Bryan Walton", beginningBalance);

            // Act
            account.DepositTest(depositAmount);

            // Assert
            decimal actual = (decimal)account.AccountBalance;
            Assert.AreEqual(expected, (double)actual, 16.54, "Account not deposited correctly");
        }

        [Test]
        public void _HasSufficientFundsToWithdrawTest()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            Account account = new Account("Mr. Bryan Walton", beginningBalance);
            var balanceLeft = beginningBalance - debitAmount;

            // Act
            account.HasSufficientFundsToWithdrawTest(balanceLeft);

            // Assert
            decimal actual = (decimal)account.AccountBalance;
            Assert.AreEqual(expected, (double)actual, 7.44, "Account has no suffcient funds to withdraw");
        }

        [Test]
        public void _FundsLowAfterWithdrawnTest()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            Account account = new Account("Mr. Bryan Walton", beginningBalance);

            var balanceLeft = beginningBalance - debitAmount;
           
            // Act
            account.FundsLowAfterWithdrawnTest(balanceLeft,0);

            // Assert
            decimal actual = (decimal)account.AccountBalance;
            Assert.AreEqual(expected, (double)actual, 7.44, "Account has Funds Low After Withdrawn");
        }

        [Test]
        public void _HasPaidInLimitReachedTest()
        {
            // Arrange
            double beginningBalance = 11.99;
            double depositedAmount = 4.55;
            double expected = 16.54;
            Account account = new Account("Mr. Bryan Walton", beginningBalance);

            var balance = beginningBalance + depositedAmount;
           
            // Act
            account.HasPaidInLimitReachedTest(balance);

            // Assert
            decimal actual = (decimal)account.AccountBalance;
            Assert.AreEqual(expected, (double)actual, 16.54, "Account has reached its limits");
        }
    }
}