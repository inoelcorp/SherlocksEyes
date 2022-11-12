/*
 * Project      : Sherlock's Eyes
 * Description  : Network helper class contains sets of methods to do various networking functions.
 * Author       : Inoel Arifin
 * Date         : 2022-11-12
 * Module       : NetworkHelper.cs
 * 
 * Copyright (C) 2022 Inoel Arifin. All rights reserved.
 */

using NativeWifi;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Sherlock_s_Eyes.Classes
{
    internal static class NetworkHelper
    {
        private static readonly HttpClient _client = new HttpClient();
        private static readonly string _opencageApiKey = "50765e6223e0456abf45fd9c628b7e4e";

        /// <summary>
        /// This method gets all the ip address connected to the local machines and its geolocation
        /// </summary>
        /// <returns></returns>
        internal static List<GeoLocation> GetRemoteDataLocations()
        {
            List<GeoLocation> geodata = new List<GeoLocation>();
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            if (ipProperties != null)
            {
                TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();
                TcpConnectionInformation[] strippedList =
                    tcpConnections
                        .GroupBy(item => item.RemoteEndPoint.Address)
                        .Select(item => item.First())
                        .Where(item => item.State == TcpState.Established &&
                            !item.RemoteEndPoint.Address.ToString().StartsWith("127")).ToArray();

                //Console.WriteLine($"Number of IP's: {tcpConnections.Length}");
                //Console.WriteLine($"Number of Stripped IP's: {strippedList.Length}");

                foreach (TcpConnectionInformation info in strippedList)
                {
                    string remoteAddress = info.RemoteEndPoint.Address.ToString().Replace(" ", "").Replace(":", "");

                    if (!string.IsNullOrWhiteSpace(remoteAddress) && remoteAddress.Length > 7) //1.0.0.1
                    {
                        GeoLocation? geoLocation = GetLocationByIP(remoteAddress);
                        if (geoLocation?.status == "success" && !string.IsNullOrWhiteSpace(geoLocation.query))
                            geodata.Add(geoLocation);
                        else
                            geodata.Add(new GeoLocation { query = remoteAddress });
                    }
                }
            }

            return geodata;
        }

        /// <summary>
        /// Gets physical address based on location's coordinate
        /// </summary>
        /// <param name="geoLocation"></param>
        /// <returns></returns>
        internal static string GetAddressByLocation(GeoLocation geoLocation)
        {
            string request = $"https://api.opencagedata.com/geocode/v1/json?key={_opencageApiKey}&q={geoLocation.lat},{geoLocation.lon}&pretty=1&no_annotations=1";
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

        /// <summary>
        /// Gets location coordinate based on the ip-address
        /// </summary>
        /// <param name="remoteAddress"></param>
        /// <returns></returns>
        internal static GeoLocation? GetLocationByIP(string remoteAddress)
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
                    Console.WriteLine($"Error: {ex.ToString()}");
                }
            }

            return null;
        }

        /// <summary>
        /// Gets wifi profiles stored on the local machine
        /// </summary>
        /// <returns></returns>
        internal static List<WLANProfile> GetWiFiProfiles()
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

            return wifiProfiles;
        }

        private static string NormalizeWhiteSpace(string input, char normalizeTo = ' ')
        {
            if (string.IsNullOrEmpty(input))
                return input;

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
    }
}
