using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ado;
namespace week6
{
    public partial class AddCLForm : Form
    {
        private DatabaseHelper dbHelper=new DatabaseHelper();
        public AddCLForm()
        {
            InitializeComponent();
            comboBox1.DataSource = dbHelper.GetSchoolNameList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("输入空白，重新输入");
                return;
            }
            List<string> classes = dbHelper.GetClassNameListBySchoolName(comboBox1.SelectedItem.ToString());
            bool flag = false;
            foreach (string cl in classes)
            {
                if (cl.Equals(this.textBox1.Text))
                {
                    flag = true;
                }
            }
            if (flag)
            {
                MessageBox.Show("班级名重复");
                return;
            }

            dbHelper.AddClass(comboBox1.SelectedItem.ToString(), textBox1.Text);
            MessageBox.Show("添加成功");
           
        }
    }
}
