using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week5
{
    public partial class Form2 : Form
    {
        private ListBox listBoxUrls;

        public Form2(List<string> urls)
        {
            InitializeComponent();
            foreach (var url in urls.Distinct())
            {
                listBoxUrls.Items.Add(url);
            }
        }

        private void InitializeComponent()
        {
            this.listBoxUrls = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxUrls
            // 
            this.listBoxUrls.FormattingEnabled = true;
            this.listBoxUrls.ItemHeight = 18;
            this.listBoxUrls.Location = new System.Drawing.Point(8, 12);
            this.listBoxUrls.Name = "listBoxUrls";
            this.listBoxUrls.Size = new System.Drawing.Size(713, 958);
            this.listBoxUrls.TabIndex = 0;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(728, 989);
            this.Controls.Add(this.listBoxUrls);
            this.Name = "Form2";
            this.ResumeLayout(false);

        }
    }
}
