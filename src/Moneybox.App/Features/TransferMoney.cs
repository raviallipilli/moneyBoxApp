using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using System;

namespace Moneybox.App.Features
{
    public class TransferMoney
    {
        private IAccountRepository accountRepository;
        private INotificationService notificationService;

        public TransferMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            this.accountRepository = accountRepository;
            this.notificationService = notificationService;

        }

        public void Execute(Guid fromAccountId, Guid toAccountId, decimal amount)
        {
            var from = this.accountRepository.GetAccountById(fromAccountId);
            var to = this.accountRepository.GetAccountById(toAccountId);

            if (!from.HasSufficientFundsToWithdraw(amount))
            {
                throw new InvalidOperationException("Insufficient funds to make transfer");
            }

            if (from.FundsLowAfterWithdrawn(amount, 500m))
            {
                this.notificationService.NotifyFundsLow(from.User.Email);
            }

            if (to.HasPaidInLimitReached(amount))
            {
                throw new InvalidOperationException("Account pay in limit reached");
            }

            var paidIn = to.PaidIn + amount;
            if (Account.PayInLimit - paidIn < 500m)
            {
                this.notificationService.NotifyApproachingPayInLimit(to.User.Email);
            }

            from.Withdraw(amount);
            to.Deposit(amount);

            this.accountRepository.Update(from);
            this.accountRepository.Update(to);
        }
    }
}
