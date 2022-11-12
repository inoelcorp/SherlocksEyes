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
    public partial class frmMap : Form
    {
        public frmMap(string latitude, string longtitude)
        {
            InitializeComponent();

            string googleMapUrl = $"https://maps.google.com/maps?q={latitude} {longtitude}";
            webViewCtrl.Source = new Uri(googleMapUrl);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
