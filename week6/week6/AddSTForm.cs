using ado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace week6
{
    public partial class AddSTForm : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private BindingSource bindingSource;
        public AddSTForm(BindingSource bindingSource1)
        {
            InitializeComponent();
            comboBox1.DataSource = dbHelper.GetSchoolNameList();
            comboBox2.DataSource=dbHelper.GetClassNameListBySchoolName(comboBox1.SelectedItem.ToString());
            bindingSource=bindingSource1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = dbHelper.GetClassNameListBySchoolName(comboBox1.SelectedItem.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "")
            {
                MessageBox.Show("输入空白，重新输入");
                return;
            }
            List<string> students = dbHelper.GetAllStudentNames();
            bool flag = false;
            foreach (string student in students)
            {
                if (student.Equals(this.textBox1.Text))
                {
                    flag = true;
                }
            }
            if (flag)
            {
                MessageBox.Show("学生名重复");
                return;
            }

            dbHelper.AddStudent(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(),textBox1.Text);
            bindingSource.DataSource = dbHelper.GetAllStudentsWithDetails();
            MessageBox.Show("添加成功");
        }

    }
}
