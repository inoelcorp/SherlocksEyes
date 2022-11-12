/*
 * Project      : Sherlock's Eyes
 * Description  : Form that display a ip's owner information based on the WiFi database.
 * Author       : Inoel Arifin
 * Date         : 2022-11-12
 * Module       : frmWhoIs.cs
 * 
 * Copyright (C) 2022 Inoel Arifin. All rights reserved.
 */

using System.Text.RegularExpressions;

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
