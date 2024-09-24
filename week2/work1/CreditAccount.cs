using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work1
{
    internal class CreditAccount : Account
    {
        public decimal CreditLimit { get; private set; }

        public CreditAccount(string accountNumber, string accountHolder, decimal initialBalance, decimal creditLimit)
            : base(accountNumber, accountHolder, initialBalance)
        {
            CreditLimit = creditLimit;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > CreditLimit + Balance)
            {
                throw new InvalidOperationException("超过信用额度，无法取款");
            }
            base.Withdraw(amount);
        }
    }
}
