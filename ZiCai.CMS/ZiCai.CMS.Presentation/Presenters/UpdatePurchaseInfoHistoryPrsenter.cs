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
    public class UpdatePurchaseInfoHistoryPrsenter : Presenter
    {
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManage;

        public UpdatePurchaseInfoHistoryPrsenter(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, UpdatePurchaseInfoHistoryView view) : base(view)
        {
            this._container = container;
            this._regionManage = regionManage;
            this._eventAggregator = eventAggregator;
            this.InitializeCommands();
        }

        public void Initialize(object updateHistoryInfo)
        {
            this.CustomerInfo = (updateHistoryInfo as UpdatePurchaseHistoryModel).CustomerInfo;
            this.PurchaseInfo = (updateHistoryInfo as UpdatePurchaseHistoryModel).PurchaseInfo;
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
            helper.ExecuteSQLNonquery(string.Format(" update PurchaseInfo \r\n                                                                    set CreateDate=#{1}#,\r\n                                                                    Product='{2}',\r\n                                                                    Amount= {3},\r\n                                                                    CurrentScore={4},\r\n                                                                    TotalScore={5},\r\n                                                                    Gift='{6}',\r\n                                                                    IsExchanged={7},\r\n                                                                    BeautyAdvisor='{8}'\r\n                                                                    where ID={0} ", new object[] { this.PurchaseInfo.ID, this.PurchaseInfo.CreateDate.ToShortDateString(), this.PurchaseInfo.Product.Trim(), this.PurchaseInfo.Amount, this.PurchaseInfo.CurrentScore, this.PurchaseInfo.TotalScore, this.PurchaseInfo.Gift.Trim(), this.PurchaseInfo.IsExchanged, this.PurchaseInfo.BeautyAdvisor.Trim() }));
            helper.Close();
            this.OnBack(null);
        }

        public ICommand BackCommand { get; set; }

        public CustomerBasicInfoModel CustomerInfo { get; set; }

        public ZiCai.CMS.ViewModels.PurchaseInfo PurchaseInfo { get; set; }

        public ICommand SaveInfoCommand { get; set; }
    }
}

