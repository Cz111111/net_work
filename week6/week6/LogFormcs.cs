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

namespace week6
{
    public partial class LogFormcs : Form
    {
        private DatabaseHelper dbHelper;
        public LogFormcs()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            bindingSource1.DataSource = dbHelper.GetAllLogs();
        }
    }
}
