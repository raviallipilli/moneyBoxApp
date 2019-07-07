using System;

namespace Moneybox.App
{
    public class Account
    {
        public const decimal PayInLimit = 4000m;

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; private set; }

        public decimal Withdrawn { get; private set; }

        public decimal PaidIn { get; private set; }

        internal bool HasSufficientFundsToWithdraw(decimal amountWithdrawn)
        {
            var balanceLeft = Balance - amountWithdrawn;
            return balanceLeft >= 0m;
        }

        internal void Withdraw(decimal amountWithdrawn)
        {
            Balance = Balance - amountWithdrawn;
            Withdrawn = Withdrawn - amountWithdrawn;
        }

        internal void Deposit(decimal amountDeposited)
        {
            Balance = Balance + amountDeposited;
            PaidIn = PaidIn + amountDeposited;
        }

        internal bool FundsLowAfterWithdrawn(decimal amountWithdrawn, decimal lowLimit)
        {
            var balanceLeft = Balance - amountWithdrawn;
            return balanceLeft < lowLimit;
        }

        internal bool HasPaidInLimitReached(decimal amountToDeposit)
        {
            var balance = PaidIn + amountToDeposit;

            return balance > Account.PayInLimit;
        }

    }
}
