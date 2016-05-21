using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace ZiCai.CMS.Launcher
{
    public class App : Application
    {
        [STAThreadAttribute()]
        public static void Main()
        {
            new App().Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.SetDataBaseFile();
            ResourceDictionary item = new ResourceDictionary
            {
                Source = new Uri("/ZiCai.CMS.Common;component/Styles/Generic.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(item);
            new Bootstrapper().Run();
        }

        private void SetDataBaseFile()
        {
            if (!File.Exists(@"C:\ZiCaiCMSDB\ZiCaiCMSDB.mdb"))
            {
                if (!Directory.Exists(@"C:\ZiCaiCMSDB"))
                {
                    Directory.CreateDirectory(@"C:\ZiCaiCMSDB");
                }
                File.Copy("ZiCaiCMSDB.mdb", @"C:\ZiCaiCMSDB\ZiCaiCMSDB.mdb", true);
            }
        }
    }
}
