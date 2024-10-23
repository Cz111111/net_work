namespace week5
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
            this.cmbSearchEngine = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridViewPhones = new System.Windows.Forms.DataGridView();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShowUrls = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSearchEngine
            // 
            this.cmbSearchEngine.FormattingEnabled = true;
            this.cmbSearchEngine.Items.AddRange(new object[] {
            "Baidu",
            "Bing"});
            this.cmbSearchEngine.Location = new System.Drawing.Point(250, 27);
            this.cmbSearchEngine.Name = "cmbSearchEngine";
            this.cmbSearchEngine.Size = new System.Drawing.Size(136, 26);
            this.cmbSearchEngine.TabIndex = 2;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(392, 27);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(726, 28);
            this.txtKeyword.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1124, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 33);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridViewPhones
            // 
            this.dataGridViewPhones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phone,
            this.url});
            this.dataGridViewPhones.Location = new System.Drawing.Point(12, 103);
            this.dataGridViewPhones.Name = "dataGridViewPhones";
            this.dataGridViewPhones.RowHeadersWidth = 62;
            this.dataGridViewPhones.RowTemplate.Height = 30;
            this.dataGridViewPhones.Size = new System.Drawing.Size(1514, 784);
            this.dataGridViewPhones.TabIndex = 5;
            // 
            // phone
            // 
            this.phone.HeaderText = "手机号";
            this.phone.MinimumWidth = 8;
            this.phone.Name = "phone";
            this.phone.Width = 150;
            // 
            // url
            // 
            this.url.HeaderText = "URL";
            this.url.MinimumWidth = 8;
            this.url.Name = "url";
            this.url.Width = 150;
            // 
            // btnShowUrls
            // 
            this.btnShowUrls.Location = new System.Drawing.Point(1248, 903);
            this.btnShowUrls.Name = "btnShowUrls";
            this.btnShowUrls.Size = new System.Drawing.Size(278, 45);
            this.btnShowUrls.TabIndex = 6;
            this.btnShowUrls.Text = "爬取的URL";
            this.btnShowUrls.UseVisualStyleBackColor = true;
            this.btnShowUrls.Click += new System.EventHandler(this.btnShowUrls_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 66);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1514, 21);
            this.progressBar.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 960);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnShowUrls);
            this.Controls.Add(this.dataGridViewPhones);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.cmbSearchEngine);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSearchEngine;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridViewPhones;
        private System.Windows.Forms.Button btnShowUrls;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

