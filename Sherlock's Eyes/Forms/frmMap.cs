/*
 * Project      : Sherlock's Eyes
 * Description  : Form that shows Google map and positioned the specified location.
 * Author       : Inoel Arifin
 * Date         : 2022-11-12
 * Module       : frmMap.cs
 * 
 * Copyright (C) 2022 Inoel Arifin. All rights reserved.
 */

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
