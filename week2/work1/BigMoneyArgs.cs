using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work1
{
    internal class BigMoneyArgs : EventArgs
    {
        public string AccountNumber { get; private set; }
        public decimal Amount { get; private set; }

        public BigMoneyArgs(string accountNumber, decimal amount)
        {
            AccountNumber = accountNumber;
            Amount = amount;
        }
    }
}
