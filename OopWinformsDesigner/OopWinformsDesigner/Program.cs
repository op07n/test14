﻿using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;

using System;
using System.Windows.Forms;

namespace OopWinformsDesigner {
    static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if NETCOREAPP
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            // Adding default LookAndFeel (Office 2019 Black). This style an be changed using the StatusBar component.
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.Office2019Black);
            Application.Run(new MainForm());
        }
    }
}
