/*
 * Project      : Sherlock's Eyes
 * Description  : App which allows you get all the remote IP's connected to your computer. 
 *                Determines the geolocation, getting the owner-info thru Whois database. 
 *                There is also a feature that gets all the WiFi's once connected to your 
 *                computer and shows the encrypted password.
 * Author       : Inoel Arifin
 * Date         : 2022-11-12
 * Module       : Program.cs
 * 
 * Copyright (C) 2022 Inoel Arifin. All rights reserved.
 */

namespace Sherlock_s_Eyes
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}