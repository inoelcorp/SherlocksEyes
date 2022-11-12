using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sherlock_s_Eyes
{
    public partial class frmWhoIs : Form
    {
        public frmWhoIs(string whoIsInfo)
        {
            InitializeComponent();

            txtWhoIs.Text = Regex.Replace(whoIsInfo, "(?<!\r)\n", "\r\n");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmWhoIs_Load(object sender, EventArgs e)
        {
            txtWhoIs.SelectionStart = 0;
            txtWhoIs.SelectionLength = 0;
        }
    }
}
