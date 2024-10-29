using ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week6
{
    public class AddSCForm : Form
    {
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private DatabaseHelper dbHelper;

        public AddSCForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

        }



        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(108, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "添加学校";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 156);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(258, 28);
            this.textBox1.TabIndex = 2;
            // 
            // AddSCForm
            // 
            this.ClientSize = new System.Drawing.Size(455, 359);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "AddSCForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "") 
            {
                MessageBox.Show("输入空白，重新输入");
                return;
            }
            List<string> schools = dbHelper.GetSchoolNameList();
            bool flag=false;
            foreach (string school in schools)
            {
                if (school.Equals(this.textBox1.Text))
                {
                    flag = true;
                }
            }
            if (flag)
            {
                MessageBox.Show("学校名重复");
                return;
            }
            dbHelper.AddSchool(this.textBox1.Text);
            MessageBox.Show("添加成功");

        }
    }
}
