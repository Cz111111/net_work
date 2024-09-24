using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work1
{
    internal class ATM
    {
        public event EventHandler<BigMoneyArgs> BigMoneyFetched;

        protected virtual void OnBigMoneyFetched(BigMoneyArgs e)
        {
            BigMoneyFetched?.Invoke(this, e);
        }

        public void Withdraw(Account account, decimal amount)
        {
            if (amount > 10000)
            {
                OnBigMoneyFetched(new BigMoneyArgs(account.AccountNumber, amount));
            }

            // 模拟坏钞率
            Random random = new Random();
            if (random.Next(100) < 30)
            {
                throw new BadCashException("检测到坏钞，请重试");
            }

            account.Withdraw(amount);
        }
    }
}
