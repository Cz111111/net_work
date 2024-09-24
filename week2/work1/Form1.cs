using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work1
{
    public partial class Form1 : Form
    {
        private ATM atm = new ATM();
        private CreditAccount account;
        public Form1()
        {
            InitializeComponent();
            account=new CreditAccount("czh_account","czh",1000000,100000);
            atm.BigMoneyFetched += Atm_BigMoneyFetched;
        }
        private void Atm_BigMoneyFetched(object sender, BigMoneyArgs e)
        {
            MessageBox.Show($"警告：账号 {e.AccountNumber} 取款金额超过10000元！");
        }

        private void withdraw_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = decimal.Parse(textBox1.Text);
                atm.Withdraw(account, amount);
                label3.Text = $"{account.Balance}";
            }
            catch (BadCashException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

    }
}
