using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using ZiCai.CMS.Framework;
using ZiCai.CMS.Presentation.Helper;
using ZiCai.CMS.Presentation.Views;
using ZiCai.CMS.ViewModels;
using ZiCai.CMS.WPF.Extensions;

namespace ZiCai.CMS.Presentation.Presenters
{
    public class CustomerDetailsPrsenter : Presenter
    {
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManage;

        public CustomerDetailsPrsenter(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, CustomerDetailsView view)
            : base(view)
        {
            this._container = container;
            this._regionManage = regionManage;
            this._eventAggregator = eventAggregator;
            this.InitializeCommands();
            this.SubscribeEvents();
        }

        public void Initialize(CustomerBasicInfoModel model)
        {
            this.PurchaseHistory = new ObservableCollection<PurchaseInfo>();
            AccessDbHelper helper = new AccessDbHelper();
            List<CustomerBasicInfoModel> source = helper.SelectToDataTable(string.Format("Select * from CustomerInfo where CustomerNo='{0}'", model.CustomerNo)).List<CustomerBasicInfoModel>();
            helper.Close();
            this.CustomerInfo = source.Any<CustomerBasicInfoModel>() ? source.FirstOrDefault<CustomerBasicInfoModel>() : new CustomerBasicInfoModel();
            this.LoadHistoryData();
        }

        private void InitializeCommands()
        {
            this.BackCommand = new DelegateCommand<object>(new Action<object>(this.OnBack));
            this.DeletePurchaseHistoryCommand = new DelegateCommand<object>(new Action<object>(this.OnDeletePurchaseHistory));
            this.AddPurchaseHistoryrCommand = new DelegateCommand<object>(new Action<object>(this.OnAddPurchaseHistoryr));
            this.UpdatePurchaseHistoryCommand = new DelegateCommand<object>(new Action<object>(this.OnUpdatePurchaseHistory));
        }

        private void LoadHistoryData()
        {
            AccessDbHelper helper = new AccessDbHelper();
            List<PurchaseInfo> list = helper.SelectToDataTable(string.Format("Select * from PurchaseInfo  where CustomerNo='{0}' ", this.CustomerInfo.CustomerNo)).List<PurchaseInfo>();
            helper.Close();
            this.PurchaseHistory.Clear();
            foreach (PurchaseInfo info in list)
            {
                this.PurchaseHistory.Add(info);
            }
        }

        private void OnAddPurchaseHistoryr(object payload)
        {
            this._eventAggregator.GetEvent<AddPurchaseInfoHistoryEvent>().Publish(this.CustomerInfo);
        }

        private void OnBack(object payload)
        {
            this._regionManage.Regions["MainRegion"].Remove(base.View);
            this._eventAggregator.GetEvent<RefreshMainViewDataEvent>().Publish(null);
            this.UnSubscribeEvents();
        }

        private void OnDeletePurchaseHistory(object payload)
        {
            if (MessageBox.Show("大龙，你真的要删除么？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.No)
            {
                AccessDbHelper helper = new AccessDbHelper();
                helper.ExecuteSQLNonquery(string.Format("delete * from PurchaseInfo  where ID={0} ", this.SelectedHistory.ID));
                helper.Close();
                this.LoadHistoryData();
            }
        }

        private void OnUpdatePurchaseHistory(object payload)
        {
            UpdatePurchaseHistoryModel model = new UpdatePurchaseHistoryModel
            {
                CustomerInfo = this.CustomerInfo,
                PurchaseInfo = this.SelectedHistory
            };
            this._eventAggregator.GetEvent<EditPurchaseInfoHistoryEvent>().Publish(model);
        }

        private void RefreshHistoryData(object payload)
        {
            this.LoadHistoryData();
        }

        private void SubscribeEvents()
        {
            this._eventAggregator.GetEvent<RefreshCustomerDetailViewDataEvent>().Subscribe(new Action<object>(this.RefreshHistoryData));
        }

        private void UnSubscribeEvents()
        {
            this._eventAggregator.GetEvent<RefreshCustomerDetailViewDataEvent>().Unsubscribe(new Action<object>(this.RefreshHistoryData));
        }

        public ICommand AddPurchaseHistoryrCommand { get; set; }

        public ICommand BackCommand { get; set; }

        public CustomerBasicInfoModel CustomerInfo { get; set; }

        public ICommand DeletePurchaseHistoryCommand { get; set; }

        public ObservableCollection<PurchaseInfo> PurchaseHistory { get; set; }

        public PurchaseInfo SelectedHistory { get; set; }

        public ICommand UpdatePurchaseHistoryCommand { get; set; }
    }
}

