/*
 * Project      : Sherlock's Eyes
 * Description  : Form that shows all available Wifi profiles stored on the local machine.
 * Author       : Inoel Arifin
 * Date         : 2022-11-12
 * Module       : frmWifiPasswords.cs
 * 
 * Copyright (C) 2022 Inoel Arifin. All rights reserved.
 */

namespace Sherlock_s_Eyes
{
    public partial class frmWifiPasswords : Form
    {
        private List<WLANProfile> _wifiData = new List<WLANProfile>();

        public frmWifiPasswords(List<WLANProfile> wifiData )
        {
            InitializeComponent();

            _wifiData = wifiData;
        }

        private void frmWifiPasswords_Load(object sender, EventArgs e)
        {
            try
            {
                lsvSSID.Items.Clear();
                lsvDetails.Items.Clear();

                foreach (WLANProfile curWifiData in _wifiData)
                {
                    if (curWifiData != null)
                    {
                        ListViewItem listItem = lsvSSID.Items.Add(curWifiData.Name);
                        listItem.Tag = curWifiData;
                    }

                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lsvSSID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lsvSSID.SelectedItems.Count > 0)
                {
                    lsvDetails.Items.Clear();

                    WLANProfile curWifiData = (WLANProfile)lsvSSID.SelectedItems[0].Tag;
                    if (curWifiData != null)
                    {
                        AddFieldToList(lsvDetails, "Name", curWifiData.Name);
                        AddFieldToList(lsvDetails, "SSID", curWifiData.SSIDConfig?.SSID?.Name);
                        AddFieldToList(lsvDetails, "SSID Hex", curWifiData.SSIDConfig?.SSID?.Hex);
                        AddFieldToList(lsvDetails, "Interface Name", curWifiData.InterfaceName);
                        AddFieldToList(lsvDetails, "Interface Desc.", curWifiData.InterfaceDescription);
                        AddFieldToList(lsvDetails, "Interface Status", curWifiData.InterfaceStatus);
                        AddFieldToList(lsvDetails, "Connection Mode", curWifiData.ConnectionMode);
                        AddFieldToList(lsvDetails, "Connection Type", curWifiData.ConnectionType);
                        AddFieldToList(lsvDetails, "Authentication", curWifiData.MSM?.Security?.AuthEncryption?.Authentication);
                        AddFieldToList(lsvDetails, "Encryption", curWifiData.MSM?.Security?.AuthEncryption?.Encryption);
                        AddFieldToList(lsvDetails, "Use One Time", curWifiData.MSM?.Security?.AuthEncryption?.UseOneX);
                        AddFieldToList(lsvDetails, "Key Type", curWifiData.MSM?.Security?.SharedKey?.KeyType);
                        AddFieldToList(lsvDetails, "Uncrypted Key", curWifiData.MSM?.Security?.SharedKey?.KeyMaterial);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddFieldToList(ListView listView, string fieldName, string? fieldValue)
        {
            if (!string.IsNullOrWhiteSpace(fieldName))
            {
                ListViewItem lsvItem = lsvDetails.Items.Add(fieldName);
                
                if (!string.IsNullOrWhiteSpace(fieldValue))
                    lsvItem.SubItems.Add(fieldValue);
            }
        }

        private void lsvDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsvDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsvSSID.SelectedItems.Count > 0)
            {
                try
                {
                    string? fieldValue = lsvDetails.SelectedItems[0].SubItems[1]?.Text;

                    if (!string.IsNullOrWhiteSpace(fieldValue))
                    {
                        Clipboard.SetText(fieldValue);
                        MessageBox.Show("Field value has been copied to Clipboard", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    //do nothing
                }
            }
        }
    }
}
