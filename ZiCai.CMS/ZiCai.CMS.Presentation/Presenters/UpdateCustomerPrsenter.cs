using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ZiCai.CMS.Framework;
using ZiCai.CMS.Presentation.Helper;
using ZiCai.CMS.Presentation.Views;
using ZiCai.CMS.ViewModels;
using ZiCai.CMS.WPF.Extensions;

namespace ZiCai.CMS.Presentation.Presenters
{
    public class UpdateCustomerPrsenter : Presenter
    {
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManage;

        public UpdateCustomerPrsenter(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, UpdateCustomerView view)
            : base(view)
        {
            this._container = container;
            this._regionManage = regionManage;
            this._eventAggregator = eventAggregator;
            this.InitializeCommands();
        }

        public void Initialize(CustomerBasicInfoModel model)
        {
            AccessDbHelper helper = new AccessDbHelper();
            List<CustomerBasicInfoModel> source = helper.SelectToDataTable(string.Format("Select * from CustomerInfo where CustomerNo='{0}'", model.CustomerNo)).List<CustomerBasicInfoModel>();
            helper.Close();
            this.CustomerInfo = source.Any<CustomerBasicInfoModel>() ? source.FirstOrDefault<CustomerBasicInfoModel>() : new CustomerBasicInfoModel();
        }

        private void InitializeCommands()
        {
            this.UpdateInfoCommand = new DelegateCommand<object>(new Action<object>(this.OnUpdateInfo));
            this.BackCommand = new DelegateCommand<object>(new Action<object>(this.OnBack));
        }

        private void OnBack(object payload)
        {
            this._regionManage.Regions["MainRegion"].Remove(base.View);
            this._eventAggregator.GetEvent<RefreshMainViewDataEvent>().Publish(null);
        }

        private void OnUpdateInfo(object payload)
        {
            AccessDbHelper helper = new AccessDbHelper();
            helper.ExecuteSQLNonquery(string.Format(" update CustomerInfo set \r\n                 CustomerNo='{0}',\r\n                    CreateDate=#{1}#,\r\n                    BeautyAdvisor='{2}',\r\n                    CustomerName='{3}',\r\n                    Birthday=#{4}#,\r\n                    TelephoneNumber='{5}',\r\n                    Address='{6}', \r\n                    Trade='{7}', \r\n                    Email='{8}', \r\n                    QQNumber='{9}', \r\n                    SkinCondition='{10}', \r\n                    Comment='{11}'\r\n                    where CustomerNo='{0}'", new object[] { this.CustomerInfo.CustomerNo.Trim(), (this.CustomerInfo.CreateDate.Year == 1) ? DateTime.Now.ToShortDateString() : this.CustomerInfo.CreateDate.ToShortDateString(), this.CustomerInfo.BeautyAdvisor.Trim(), this.CustomerInfo.CustomerName.Trim(), (this.CustomerInfo.Birthday.Year == 1) ? DateTime.Now.ToShortDateString() : this.CustomerInfo.Birthday.ToShortDateString(), this.CustomerInfo.TelephoneNumber.Trim(), this.CustomerInfo.Address.Trim(), this.CustomerInfo.Trade.Trim(), this.CustomerInfo.Email.Trim(), this.CustomerInfo.QQNumber.Trim(), this.CustomerInfo.SkinCondition.Trim(), this.CustomerInfo.Comment.Trim() }));
            helper.Close();
            this.OnBack(null);
        }

        public ICommand BackCommand { get; set; }

        public CustomerBasicInfoModel CustomerInfo { get; set; }

        public ICommand UpdateInfoCommand { get; set; }
    }
}

