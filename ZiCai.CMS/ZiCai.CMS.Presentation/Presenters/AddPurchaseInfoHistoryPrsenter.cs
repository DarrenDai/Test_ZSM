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
    public class AddPurchaseInfoHistoryPrsenter : Presenter
    {
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManage;

        public AddPurchaseInfoHistoryPrsenter(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, AddPurchaseInfoHistoryView view) : base(view)
        {
            this._container = container;
            this._regionManage = regionManage;
            this._eventAggregator = eventAggregator;
            this.InitializeCommands();
        }

        public void Initialize(object customerNo)
        {
            this.CustomerInfo = customerNo as CustomerBasicInfoModel;
            ZiCai.CMS.ViewModels.PurchaseInfo info = new ZiCai.CMS.ViewModels.PurchaseInfo {
                CreateDate = DateTime.Now,
                CustomerNo = this.CustomerInfo.CustomerNo
            };
            this.PurchaseInfo = info;
        }

        private void InitializeCommands()
        {
            this.SaveInfoCommand = new DelegateCommand<object>(new Action<object>(this.OnSaveInfo));
            this.BackCommand = new DelegateCommand<object>(new Action<object>(this.OnBack));
        }

        private void OnBack(object payload)
        {
            this._regionManage.Regions["MainRegion"].Remove(base.View);
            this._eventAggregator.GetEvent<RefreshCustomerDetailViewDataEvent>().Publish(null);
        }

        private void OnSaveInfo(object payload)
        {
            AccessDbHelper helper = new AccessDbHelper();
            helper.ExecuteSQLNonquery(string.Format(" insert into PurchaseInfo \r\n                (CustomerNo,CreateDate,Product,Amount,CurrentScore,TotalScore,Gift,IsExchanged,BeautyAdvisor)\r\n                values('{0}', #{1}#, '{2}', {3}, {4}, {5}, '{6}', {7}, '{8}' ) ", new object[] { this.PurchaseInfo.CustomerNo.Trim(), this.PurchaseInfo.CreateDate.ToShortDateString(), this.PurchaseInfo.Product.Trim(), this.PurchaseInfo.Amount, this.PurchaseInfo.CurrentScore, this.PurchaseInfo.TotalScore, this.PurchaseInfo.Gift.Trim(), this.PurchaseInfo.IsExchanged, this.PurchaseInfo.BeautyAdvisor.Trim() }));
            helper.Close();
            this.OnBack(null);
        }

        public ICommand BackCommand { get; set; }

        public CustomerBasicInfoModel CustomerInfo { get; set; }

        public ZiCai.CMS.ViewModels.PurchaseInfo PurchaseInfo { get; set; }

        public ICommand SaveInfoCommand { get; set; }
    }
}

