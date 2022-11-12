/*
 * Project      : Sherlock's Eyes
 * Description  : App which allows you get all the remote IP's connected to your computer. 
 *                Determines the geolocation, getting the owner-info thru Whois database. 
 *                There is also a feature that gets all the WiFi's once connected to your 
 *                computer and shows the encrypted password.
 * Author       : Inoel Arifin
 * Date         : 2022-11-12
 * Module       : frmMain.cs
 * 
 * Copyright (C) 2022 Inoel Arifin. All rights reserved.
 */

using Sherlock_s_Eyes;
using Sherlock_s_Eyes.Classes;
using Whois.NET;

public partial class frmMain : Form
{
    public frmMain()
    {
        InitializeComponent();
    }

    private void FillListWithGeoData()
    {
        lsvLocations.Items.Clear();
        List<GeoLocation> geodata = NetworkHelper.GetRemoteDataLocations();

        if (geodata != null)
        {
            foreach (GeoLocation curLocation in geodata)
            {
                if (!string.IsNullOrWhiteSpace(curLocation.country))
                {
                    ListViewItem listItem = lsvLocations.Items.Add(curLocation.query);
                    listItem.Tag = curLocation;
                    listItem.SubItems.Add(curLocation.country);

                    string address = NetworkHelper.GetAddressByLocation(curLocation);

                    if (!string.IsNullOrWhiteSpace(address))
                        listItem.SubItems.Add($"{address}");
                    else    
                        listItem.SubItems.Add($"{curLocation.city}");
                }
            }
        }
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
        try 
        { 
            FillListWithGeoData();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void Refresh_Click(object sender, EventArgs e)
    {
        try
        {
            FillListWithGeoData();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void btnMap_Click(object sender, EventArgs e)
    {
        try
        {
            if (lsvLocations.SelectedItems?.Count > 0)
            {
                GeoLocation geoLocation = (GeoLocation)lsvLocations.SelectedItems[0].Tag;
                if (geoLocation != null)
                {
                    frmMap mapForm = new frmMap(geoLocation.lat.ToString().Replace(",", "."), geoLocation.lon.ToString().Replace(",", "."));
                    mapForm.ShowDialog();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (lsvLocations.SelectedItems?.Count > 0)
            {
                WhoisResponse whoIs = WhoisClient.Query(lsvLocations.SelectedItems[0].Text);
                if (whoIs != null)
                {
                    frmWhoIs whoIsForm = new frmWhoIs(whoIs.Raw);
                    whoIsForm.ShowDialog();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void btnInfo_Click(object sender, EventArgs e)
    {
        string message = $"{Application.ProductName} {Application.ProductVersion}\r\n© 2022 Inoel Arifin. All rights reserved.\r\n\r\ninoelcorp@gmail.com";

        MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void lsvLocations_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnMap.Enabled = (lsvLocations.SelectedItems?.Count > 0);
        btnWhoIs.Enabled = btnMap.Enabled;
    }

    private void lsvLocations_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }

    private void lsvLocations_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        if (e.ItemIndex % 2 == 0)
            e.Item.BackColor = Color.FromArgb(242, 255, 255);
        else
            e.Item.BackColor = Color.White;

        e.DrawDefault = true;
    }

    private void wiFiPasswordsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            List<WLANProfile> wifiProfiles = NetworkHelper.GetWiFiProfiles();
            if (wifiProfiles.Count > 0)
            {
                frmWifiPasswords frmWifi = new frmWifiPasswords(wifiProfiles);
                frmWifi.ShowDialog();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
