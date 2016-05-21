using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ZiCai.CMS.Framework;
using ZiCai.CMS.Presentation.Helper;
using ZiCai.CMS.Presentation.Views;
using ZiCai.CMS.ViewModels;

namespace ZiCai.CMS.Presentation.Presenters
{
    public class AddCustomerPrsenter : Presenter
    {
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManage;

        public AddCustomerPrsenter(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, AddCustomerView view)
            : base(view)
        {
            this._container = container;
            this._regionManage = regionManage;
            this._eventAggregator = eventAggregator;
            this.Initialize();
            this.InitializeCommands();
        }

        private void Initialize()
        {
            CustomerBasicInfoModel model = new CustomerBasicInfoModel
            {
                Birthday = DateTime.Now,
                CreateDate = DateTime.Now
            };
            this.CustomerInfo = model;
        }

        private void InitializeCommands()
        {
            this.SaveInfoCommand = new DelegateCommand<object>(new Action<object>(this.OnSaveInfo));
            this.BackCommand = new DelegateCommand<object>(new Action<object>(this.OnBack));
        }

        private void OnBack(object payload)
        {
            this._regionManage.Regions["MainRegion"].Remove(base.View);
            this._eventAggregator.GetEvent<RefreshMainViewDataEvent>().Publish(null);
        }

        private void OnSaveInfo(object payload)
        {
            AccessDbHelper helper = new AccessDbHelper();
            helper.ExecuteSQLNonquery(
                string.Format(@" insert into CustomerInfo values('{0}', #{1}#, '{2}', '{3}', #{4}#, '{5}', '{6}', '{7}', 
                                                                  '{8}', '{9}', '{10}', '{11}' ) ",
                new object[] { this.CustomerInfo.CustomerNo.Trim(), (this.CustomerInfo.CreateDate.Year == 1) ? DateTime.Now.ToShortDateString() : this.CustomerInfo.CreateDate.ToShortDateString(), 
                    this.CustomerInfo.BeautyAdvisor.Trim(), 
                    this.CustomerInfo.CustomerName.Trim(), 
                    (this.CustomerInfo.Birthday.Year == 1) ? DateTime.Now.ToShortDateString() : this.CustomerInfo.Birthday.ToShortDateString(), 
                    this.CustomerInfo.TelephoneNumber.Trim(), 
                    this.CustomerInfo.Address.Trim(), 
                    this.CustomerInfo.Trade.Trim(), 
                    this.CustomerInfo.Email.Trim(),
                    this.CustomerInfo.QQNumber.Trim(), 
                    this.CustomerInfo.SkinCondition.Trim(),
                    this.CustomerInfo.Comment.Trim() }));
            helper.Close();
            this.OnBack(null);
        }

        public ICommand BackCommand { get; set; }

        public CustomerBasicInfoModel CustomerInfo { get; set; }

        public ICommand SaveInfoCommand { get; set; }
    }
}

