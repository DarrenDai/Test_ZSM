using DDSoft.Common;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ZSM.CMS.Presentation.DataModel;
using ZSM.CMS.Presentation.Models;
using ZSM.CMS.Presentation.Extensions;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Presentation.ViewModels
{
    class DataMangementViewModel : ViewModelBase
    {
        #region Constructor

        public DataMangementViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, DataMangement view)
            : base(view)
        {
            Container = container;
            RegionManager = regionManage;
            EventAggregator = eventAggregator;
        }

        #endregion

        #region Commands

        public ICommand BackUpCommand { get; set; }

        public ICommand RestoreCommand { get; set; }

        #endregion

        #region Initialize Methods

        public override void InitializeCommands()
        {
            base.InitializeCommands();

            BackUpCommand = new DelegateCommand<object>(new Action<object>(OnBackUp));
            RestoreCommand = new DelegateCommand<object>(new Action<object>(OnRestore));
        }

        #endregion

        #region Command handlers

        private void OnBackUp(object param)
        {
            FileInfo file = new FileInfo(AppContext.Configuration.DBLocation);
            if (file.Exists)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = string.Format("data-{0}.bak", DateTime.Now.Ticks);
                if (dialog.ShowDialog().Value)
                {
                    file.CopyTo(dialog.FileName);

                    Logger.Info("Data Backed up successfully.");
                    MessageBox.Show("备份成功！请保管好数据文件。", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("数据文件不存在！", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OnRestore(object param)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Data files (*.bak)|*.BAK";
            if (dialog.ShowDialog().Value)
            {
                FileInfo file = new FileInfo(dialog.FileName);
                file.CopyTo(AppContext.Configuration.DBLocation, true);

                Logger.Info("Data resotered successfully.");
                MessageBox.Show("还原成功。", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #endregion
    }
}
