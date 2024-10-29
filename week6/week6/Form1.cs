using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using ado;
namespace week6
{
    
    public partial class Form1 : Form
    {

        private DatabaseHelper dbHelper;
        private List<string> items= new List<string>{"全部","学生ID", "学生名", "班级", "学校"};
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = items;
            dbHelper = new DatabaseHelper();
            bindingSource1.DataSource= dbHelper.GetAllStudentsWithDetails();


        }

        private void addSCbtn_Click(object sender, EventArgs e)
        {
            AddSCForm addSCForm = new AddSCForm();
            addSCForm.Show();
        }

        private void addCLbtn_Click(object sender, EventArgs e)
        {
            AddCLForm addCLForm = new AddCLForm();
            addCLForm.Show();
        }

        private void addSTbtn_Click(object sender, EventArgs e)
        {
            AddSTForm addSTForm = new AddSTForm(bindingSource1);  
            addSTForm.Show();
        }

        private void opbtn_Click(object sender, EventArgs e)
        {
            LogFormcs logFormcs = new LogFormcs();
            logFormcs.Show();
        }
        private void searchbtn_Click(object sender, EventArgs e)
        {

            string select = comboBox1.SelectedItem.ToString();
            List<StudentInfo> studentInfos = new List<StudentInfo>();
            if (select.Equals("全部"))
            {
                studentInfos = dbHelper.GetAllStudentsWithDetails();
                bindingSource1.DataSource = studentInfos;
                return;
                
            }
            else if(textBox1.Text.Equals(""))
            {
                MessageBox.Show("查询内容并不能为空");
                return;
            }
            switch (select)
            {
                //"学生ID", "学生名", "班级", "学校"
                case "学生ID":
                    studentInfos=dbHelper.SearchStudentsById(int.Parse(textBox1.Text));
                    break;
                case "学生名":
                    studentInfos = dbHelper.SearchStudentsByName(textBox1.Text);
                    break;
                case "班级":
                    studentInfos = dbHelper.SearchStudentsByClass(textBox1.Text);
                    break;
                case "学校":
                    studentInfos = dbHelper.SearchStudentsBySchool(textBox1.Text);
                    break;
                default:
                    
                    break;


            }
            bindingSource1.DataSource=studentInfos;

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("没有选中学生");
                return;
            }
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            
            dbHelper.DeleteStudentByIdAndName(int.Parse(selectedRow.Cells[0].Value.ToString()), selectedRow.Cells[1].Value.ToString());
            bindingSource1.DataSource= dbHelper.GetAllStudentsWithDetails();
            MessageBox.Show("删除成功");
        }

    }
}
