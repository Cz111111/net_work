namespace week6
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.searchbtn = new System.Windows.Forms.Button();
            this.addSCbtn = new System.Windows.Forms.Button();
            this.addCLbtn = new System.Windows.Forms.Button();
            this.addSTbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deletebtn = new System.Windows.Forms.Button();
            this.studentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.schoolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.opbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(674, 28);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(24, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 26);
            this.comboBox1.TabIndex = 1;
            // 
            // searchbtn
            // 
            this.searchbtn.Location = new System.Drawing.Point(812, 12);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(114, 35);
            this.searchbtn.TabIndex = 2;
            this.searchbtn.Text = "搜索";
            this.searchbtn.UseVisualStyleBackColor = true;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // addSCbtn
            // 
            this.addSCbtn.Location = new System.Drawing.Point(22, 63);
            this.addSCbtn.Name = "addSCbtn";
            this.addSCbtn.Size = new System.Drawing.Size(145, 42);
            this.addSCbtn.TabIndex = 3;
            this.addSCbtn.Text = "添加学校";
            this.addSCbtn.UseVisualStyleBackColor = true;
            this.addSCbtn.Click += new System.EventHandler(this.addSCbtn_Click);
            // 
            // addCLbtn
            // 
            this.addCLbtn.Location = new System.Drawing.Point(190, 63);
            this.addCLbtn.Name = "addCLbtn";
            this.addCLbtn.Size = new System.Drawing.Size(145, 42);
            this.addCLbtn.TabIndex = 4;
            this.addCLbtn.Text = "添加班级";
            this.addCLbtn.UseVisualStyleBackColor = true;
            this.addCLbtn.Click += new System.EventHandler(this.addCLbtn_Click);
            // 
            // addSTbtn
            // 
            this.addSTbtn.Location = new System.Drawing.Point(367, 63);
            this.addSTbtn.Name = "addSTbtn";
            this.addSTbtn.Size = new System.Drawing.Size(145, 42);
            this.addSTbtn.TabIndex = 5;
            this.addSTbtn.Text = "添加学生";
            this.addSTbtn.UseVisualStyleBackColor = true;
            this.addSTbtn.Click += new System.EventHandler(this.addSTbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentIDDataGridViewTextBoxColumn,
            this.studentNameDataGridViewTextBoxColumn,
            this.classNameDataGridViewTextBoxColumn,
            this.schoolNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(22, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1270, 688);
            this.dataGridView1.TabIndex = 6;
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(545, 63);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(145, 42);
            this.deletebtn.TabIndex = 7;
            this.deletebtn.Text = "删除学生";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // studentIDDataGridViewTextBoxColumn
            // 
            this.studentIDDataGridViewTextBoxColumn.DataPropertyName = "StudentID";
            this.studentIDDataGridViewTextBoxColumn.HeaderText = "学生ID";
            this.studentIDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.studentIDDataGridViewTextBoxColumn.Name = "studentIDDataGridViewTextBoxColumn";
            this.studentIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // studentNameDataGridViewTextBoxColumn
            // 
            this.studentNameDataGridViewTextBoxColumn.DataPropertyName = "StudentName";
            this.studentNameDataGridViewTextBoxColumn.HeaderText = "学生姓名";
            this.studentNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.studentNameDataGridViewTextBoxColumn.Name = "studentNameDataGridViewTextBoxColumn";
            this.studentNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // classNameDataGridViewTextBoxColumn
            // 
            this.classNameDataGridViewTextBoxColumn.DataPropertyName = "ClassName";
            this.classNameDataGridViewTextBoxColumn.HeaderText = "班级";
            this.classNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.classNameDataGridViewTextBoxColumn.Name = "classNameDataGridViewTextBoxColumn";
            this.classNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // schoolNameDataGridViewTextBoxColumn
            // 
            this.schoolNameDataGridViewTextBoxColumn.DataPropertyName = "SchoolName";
            this.schoolNameDataGridViewTextBoxColumn.HeaderText = "学校";
            this.schoolNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.schoolNameDataGridViewTextBoxColumn.Name = "schoolNameDataGridViewTextBoxColumn";
            this.schoolNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(ado.StudentInfo);
            // 
            // opbtn
            // 
            this.opbtn.Location = new System.Drawing.Point(720, 63);
            this.opbtn.Name = "opbtn";
            this.opbtn.Size = new System.Drawing.Size(145, 42);
            this.opbtn.TabIndex = 8;
            this.opbtn.Text = "操作记录";
            this.opbtn.UseVisualStyleBackColor = true;
            this.opbtn.Click += new System.EventHandler(this.opbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 821);
            this.Controls.Add(this.opbtn);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.addSTbtn);
            this.Controls.Add(this.addCLbtn);
            this.Controls.Add(this.addSCbtn);
            this.Controls.Add(this.searchbtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.Button addSCbtn;
        private System.Windows.Forms.Button addCLbtn;
        private System.Windows.Forms.Button addSTbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn schoolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button opbtn;
    }
}

