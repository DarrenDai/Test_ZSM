using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Input;
using ZSM.CMS.Presentation.Models;
using ZSM.CMS.Presentation.Events;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Presentation.ViewModels
{
    public class MainViewViewModel : ViewModelBase
    {
        #region Private field

        //private Window _window;

        #endregion

        #region Constructor

        public MainViewViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, MainWindow view)
            : base(view)
        {
            Container = container;
            RegionManager = regionManage;
            EventAggregator = eventAggregator;
        }

        #endregion

        #region Commands

        public ICommand CustomerManagementCommand { get; set; }

        public ICommand UserManagementCommand { get; set; }

        //public ICommand PrescriptionManagementCommand { get; set; }

        public ICommand AboutCommand { get; set; }

        public ICommand DataMangementCommand { get; set; }

        #endregion

        #region Public Properties

        public string CompanyName { get { return ApplicationContext.Current.Configuration.CompanyName; } }

        public UserModel CurrentUser { get { return ApplicationContext.Current.CurrentUser; } }

        #endregion

        #region Publc methos

        #endregion

        #region Private methods

        public override void InitializeCommands()
        {
            //AboutCommand = new RoutedCommand("AboutCommand", typeof(MainWindow));
            //CommandBinding cb = new CommandBinding();
            //cb.Command = AboutCommand;
            //cb.CanExecute += new CanExecuteRoutedEventHandler(cb_CanExecute);
            //cb.Executed += new ExecutedRoutedEventHandler(cb_Executed);
            //_window.CommandBindings.Add(cb);

            AboutCommand = new DelegateCommand<object>(new Action<object>((param) =>
            {
                var about = new About();
                about.ShowDialog();
            }));
            UserManagementCommand = new DelegateCommand<object>(new Action<object>(this.OnUserManagement));
            CustomerManagementCommand = new DelegateCommand<object>(new Action<object>(this.OnCustomerManagement));
            DataMangementCommand = new DelegateCommand<object>(new Action<object>(this.OnDataMangement));
        }

        //private void cb_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    var about = new About();
        //    //about.Owner = _window;
        //    about.ShowDialog();
        //}

        //private void cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        private void OnUserManagement(object param)
        {
            EventAggregator.GetEvent<UserManagementEvent>().Publish(null);
            Logger.Debug(string.Format("Manage Users!"));
        }

        private void OnCustomerManagement(object param)
        {
            EventAggregator.GetEvent<CustomerManagementEvent>().Publish(null);
            Logger.Debug(string.Format("Manage Customers!"));
        }

        private void OnDataMangement(object param)
        {
            EventAggregator.GetEvent<DataManagementEvent>().Publish(null);
            Logger.Debug(string.Format("Manage data!"));
        }

        #endregion
    }
}
