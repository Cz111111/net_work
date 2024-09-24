using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work1
{
    internal class Account
    {
        public string AccountNumber { get; private set; }
        public string AccountHolder { get; private set; }
        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        public Account(string accountNumber, string accountHolder, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("amount", "存款金额必须大于0");
            }
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                }
                else
                {
                    throw new InvalidOperationException("余额不足，无法取款");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("amount", "取款金额必须大于0");
            }
        }
    }
}
