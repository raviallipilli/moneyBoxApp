using System;

namespace Moneybox.App
{
    public class Account
    {
        private Account() { }

        private readonly string m_customerName;

        private double m_balance;

        private double m_paidIn;

        public const double AccountPayInLimit = 15;

        public Account(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public double AccountBalance
        {
            get { return m_balance; }
        }

        public const decimal PayInLimit = 4000m;

        public Guid Id { get; set; }

        public User User { get; set; }

        public decimal Balance { get; private set; }

        public decimal Withdrawn { get; private set; }

        public decimal PaidIn { get; private set; }

        public double AccountPaidIn
        {
            get { return m_paidIn; }
        }

        internal bool HasSufficientFundsToWithdraw(decimal amountWithdrawn)
        {
            var balanceLeft = Balance - amountWithdrawn;
            return balanceLeft >= 0m;
        }

        // testing for sufficient funds
        public bool HasSufficientFundsToWithdrawTest(double amount)
        {
            var balanceLeft = AccountBalance - amount;
           return balanceLeft >= 0; 
        }

        internal void Withdraw(decimal amountWithdrawn)
        {
            Balance = Balance - amountWithdrawn;
            Withdrawn = Withdrawn - amountWithdrawn;
        }

        // testing for withdraw
        public void WithdrawTest(double amountWithdrawn)
        {
            if (amountWithdrawn > m_balance)
            {
                throw new ArgumentOutOfRangeException("amountWithdrawn");
            }

            if (amountWithdrawn < 0)
            {
                throw new ArgumentOutOfRangeException("amountWithdrawn");
            }

            m_balance -= amountWithdrawn; 
        }

        internal void Deposit(decimal amountDeposited)
        {
            Balance = Balance + amountDeposited;
            PaidIn = PaidIn + amountDeposited;
        }

        // testing for deposit
        public void DepositTest(double amountDeposited)
        {
            if (amountDeposited > m_balance)
            {
                throw new ArgumentOutOfRangeException("amountDeposited");
            }

            if (amountDeposited < 0)
            {
                throw new ArgumentOutOfRangeException("amountDeposited");
            }

            m_balance += amountDeposited; 
        }

        internal bool FundsLowAfterWithdrawn(decimal amountWithdrawn, decimal lowLimit)
        {
            var balanceLeft = Balance - amountWithdrawn;
            return balanceLeft < lowLimit;
        }

        // testing for low sufficient funds
        public bool FundsLowAfterWithdrawnTest(double amountWithdrawn, double lowLimit)
        {
            var balanceLeft = AccountBalance - amountWithdrawn;
            return balanceLeft < lowLimit;
        }

        internal bool HasPaidInLimitReached(decimal amountToDeposit)
        {
            var balance = PaidIn + amountToDeposit;
            return balance > Account.PayInLimit;
        }

        // testing for limit reached funds
        public bool HasPaidInLimitReachedTest(double amountToDeposit)
        {
            var balance = AccountPaidIn + amountToDeposit;
            return balance > Account.AccountPayInLimit;
        }
    }
}
