using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using ZSM.CMS.Presentation;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Launcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        [STAThreadAttribute()]
        public static void Main()
        {
            new App().Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            XmlConfigurator.Configure();
            ApplicationContext.Current.Logger.Debug("System started.");
            this.SetDataBaseFile();

            this.DispatcherUnhandledException += App_DispatcherUnhandledException;

            ResourceDictionary item = new ResourceDictionary
            {
                Source = new Uri("/DDSoft.Common;component/Styles/Common/Generic.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(item);

            new Bootstrapper().Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ApplicationContext.Current.Logger.Debug("System Exited.");
            base.OnExit(e);
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ApplicationContext.Current.Logger.Error("Unhandled exception happened.", e.Exception);
            MessageBox.Show("Error happened, please restart the program. ");
            Environment.Exit(-1);
        }

        private void SetDataBaseFile()
        {
            if (!File.Exists(ApplicationContext.Current.Configuration.DBLocation))
            {
                ApplicationContext.Current.Logger.Debug("DB file not exist, copy it to destination.");
                File.Copy(@"Data\ZSM.CMS.mdb", ApplicationContext.Current.Configuration.DBLocation, false);
            }

            UpgradeDB.Upgrade();

            //if (!File.Exists(@"C:\ZSMCMSDB\dd"))
            //{
            //    if (!Directory.Exists(@"C:\ZSMCMSDB"))
            //    {
            //        Directory.CreateDirectory(@"C:\ZSMCMSDB");
            //    }
            //    File.Copy(@"Data\ZSM.CMS.mdb", @"C:\ZSMCMSDB\dd", true);
            //}
        }
    }
}
