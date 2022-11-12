using ManagedNativeWifi;
using NativeWifi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Sherlock_s_Eyes;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Whois.NET;

public partial class frmMain : Form
{
    private readonly HttpClient _client = new HttpClient();

    public frmMain()
    {
        InitializeComponent();
    }

    private void FillListWithGeoData()
    {
        try
        {
            lsvLocations.Items.Clear();
            List<GeoLocation> geodata = GetData();

            if (geodata != null)
            {
                foreach (GeoLocation curLocation in geodata)
                {
                    if (!string.IsNullOrWhiteSpace(curLocation.country))
                    {
                        ListViewItem listItem = lsvLocations.Items.Add(curLocation.query);
                        listItem.Tag = curLocation;
                        listItem.SubItems.Add(curLocation.country);

                        string address = GetAddressByLocation(curLocation);

                        if (!string.IsNullOrWhiteSpace(address))
                            listItem.SubItems.Add($"{address}");
                        else    
                            listItem.SubItems.Add($"{curLocation.city}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private List<GeoLocation> GetData()
    {
        List<GeoLocation> geodata = new List<GeoLocation>();
        IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
        TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();
        TcpConnectionInformation[] strippedList =
            tcpConnections
                .GroupBy(item => item.RemoteEndPoint.Address)
                .Select(item => item.First())
                .Where(item => item.State == TcpState.Established &&
                    !item.RemoteEndPoint.Address.ToString().StartsWith("127")).ToArray();

        //Console.WriteLine($"Number of IP's: {tcpConnections.Length}");
        //Console.WriteLine($"Number of Stripped IP's: {strippedList.Length}");

        try
        {
            foreach (TcpConnectionInformation info in strippedList)
            {
                string remoteAddress = info.RemoteEndPoint.Address.ToString().Replace(" ", "").Replace(":", "");

                if (!string.IsNullOrWhiteSpace(remoteAddress) && remoteAddress.Length > 7) //1.0.0.1
                {
                    GeoLocation geoLocation = GetLocationByIP(remoteAddress);
                    if (geoLocation != null && geoLocation.status == "success" && !string.IsNullOrWhiteSpace(geoLocation.query))
                        geodata.Add(geoLocation);
                    else
                        geodata.Add(new GeoLocation { query = remoteAddress });
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }

        return geodata;
    }

    private string GetAddressByLocation(GeoLocation geoLocation)
    {
        //codecage apikey: 50765e6223e0456abf45fd9c628b7e4e
        //https://api.opencagedata.com/geocode/v1/json?key=50765e6223e0456abf45fd9c628b7e4e&q=52.3877830%2C+9.7334394&pretty=1&no_annotations=1
        string request = $"https://api.opencagedata.com/geocode/v1/json?key=50765e6223e0456abf45fd9c628b7e4e&q={geoLocation.lat},{geoLocation.lon}&pretty=1&no_annotations=1";
        string stringResult = _client.GetStringAsync($"{request}").GetAwaiter().GetResult();

        if (!string.IsNullOrEmpty(stringResult))
        {
            try
            {
                GeoLocationDetails? geoAddress = JsonConvert.DeserializeObject<GeoLocationDetails>(stringResult);
                if (geoAddress != null && geoAddress.results != null)
                {
                    Result? addressResult = geoAddress.results?.FirstOrDefault();
                    if (addressResult != null && addressResult.components != null)
                    {
                        string address = $"{addressResult.components.road} {addressResult.components.house_number}. {addressResult.components.postcode}. {addressResult.components.city}";
                        return NormalizeWhiteSpace(address);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return string.Empty;
    }

    private static string NormalizeWhiteSpace(string input, char normalizeTo = ' ')
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        StringBuilder output = new StringBuilder();
        bool skipped = false;

        foreach (char c in input)
        {
            if (char.IsWhiteSpace(c))
            {
                if (!skipped)
                {
                    output.Append(normalizeTo);
                    skipped = true;
                }
            }
            else
            {
                skipped = false;
                output.Append(c);
            }
        }

        return output.ToString();
    }

    private GeoLocation? GetLocationByIP(string remoteAddress)
    {
       
        string stringResult = _client.GetStringAsync($"http://ip-api.com/json/{remoteAddress}").GetAwaiter().GetResult();

        if (!string.IsNullOrEmpty(stringResult))
        {
            try
            {
                GeoLocation? geoLocation = JsonConvert.DeserializeObject<GeoLocation>(stringResult);
                if (geoLocation != null)
                    return geoLocation;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }        

        return null;
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
        try
        {
            lsvLocations.Columns[0].TextAlign = HorizontalAlignment.Right;

            FillListWithGeoData();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void btnMap_Click(object sender, EventArgs e)
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

    private void button1_Click(object sender, EventArgs e)
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

    private void btnInfo_Click(object sender, EventArgs e)
    {
        string message = $"{Application.ProductName} {Application.ProductVersion}\r\n© 2022 Inoel Arifin. All rights reserved.\r\n\r\ninoelcorp@gmail.com";

        MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnWiFi_Click(object sender, EventArgs e)
    {
        try
        {
            WlanClient wlanClient = new WlanClient();
            List<WLANProfile> wifiProfiles = new List<WLANProfile>();

            foreach (WlanClient.WlanInterface wlanIface in wlanClient.Interfaces)
            {
                foreach (Wlan.WlanProfileInfo profileInfo in wlanIface.GetProfiles())
                {
                    string profileInfoXml = wlanIface.GetProfileXmlUnencrypted(profileInfo.profileName);
                    if (!string.IsNullOrWhiteSpace(profileInfoXml))
                    {
                        XmlDocument profileXml = new XmlDocument();
                        profileXml.LoadXml(profileInfoXml);

                        profileXml.DocumentElement?.SetAttribute("InterfaceName", wlanIface.InterfaceName);
                        profileXml.DocumentElement?.SetAttribute("InterfaceDescription", wlanIface.InterfaceDescription);
                        profileXml.DocumentElement?.SetAttribute("InterfaceStatus", wlanIface.InterfaceState.ToString());

                        using (Stream xmlStream = new MemoryStream(Encoding.UTF8.GetBytes(profileXml.DocumentElement.OuterXml)))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(WLANProfile));
                            WLANProfile lanProfile = (WLANProfile)serializer.Deserialize(xmlStream);
                            if (lanProfile != null)
                                wifiProfiles.Add(lanProfile);
                        }

                    }
                }
            }

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
        //if (e.ColumnIndex == 0)
        //    e.DrawText(TextFormatFlags.Right);
        //else
        //    e.DrawDefault = true;
        
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
}
