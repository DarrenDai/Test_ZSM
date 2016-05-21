using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using ZiCai.CMS.Common.EnumDefinitions;
using ZiCai.CMS.Framework;
using ZiCai.CMS.Presentation.Helper;
using ZiCai.CMS.Presentation.Views;
using ZiCai.CMS.ViewModels;
using ZiCai.CMS.WPF.Extensions;

namespace ZiCai.CMS.Presentation.Presenters
{
    public class MainViewPresenter : Presenter
    {
        #region Private fields

        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;
        private IRegionManager _regionManage;

        #endregion

        #region Constructor

        public MainViewPresenter(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, MainView view)
            : base(view)
        {
            this._container = container;
            this._regionManage = regionManage;
            this._eventAggregator = eventAggregator;
            this.Initialise();
            this.InitializeCommands();
            this.SubscribeEvents();
        }

        #endregion

        #region Public methods

        public void Initialise()
        {
            this.SearchConditionList = new ObservableCollection<SearchConditionModel>();
            SearchConditionModel item = new SearchConditionModel
            {
                Name = "显示全部",
                ConditonType = SearchConditionEnum.ALL
            };
            this.SearchConditionList.Add(item);
            SearchConditionModel model2 = new SearchConditionModel
            {
                Name = "会员编号",
                ConditonType = SearchConditionEnum.CUSTOMER_NO
            };
            this.SearchConditionList.Add(model2);
            SearchConditionModel model3 = new SearchConditionModel
            {
                Name = "美容顾问",
                ConditonType = SearchConditionEnum.BEAUTY_ADVISOR
            };
            this.SearchConditionList.Add(model3);
            SearchConditionModel model4 = new SearchConditionModel
            {
                Name = "会员姓名",
                ConditonType = SearchConditionEnum.CUSTOMER_NAME
            };
            this.SearchConditionList.Add(model4);
            SearchConditionModel model5 = new SearchConditionModel
            {
                Name = "联系电话",
                ConditonType = SearchConditionEnum.TELEPHONE_NUMBER
            };
            this.SearchConditionList.Add(model5);
            SearchConditionModel model6 = new SearchConditionModel
            {
                Name = "工作行业",
                ConditonType = SearchConditionEnum.TRADE
            };
            this.SearchConditionList.Add(model6);
            SearchConditionModel model7 = new SearchConditionModel
            {
                Name = "QQ号码",
                ConditonType = SearchConditionEnum.QQ
            };
            this.SearchConditionList.Add(model7);
            this.CustomerList = new ObservableCollection<CustomerBasicInfoModel>();
            this.LoadCustomerInfo("");
        }

        #endregion

        #region Private methods

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
        }

        private void InitializeCommands()
        {
            this.SearchCustomerInfoCommand = new DelegateCommand<object>(new Action<object>(this.OnSearchCustomerInfo));
            this.AddCustomerCommand = new DelegateCommand<object>(new Action<object>(this.OnAddCustomer));
            this.UpdateCustomerCommand = new DelegateCommand<object>(new Action<object>(this.OnUpdateCustomer));
            this.ViewCustomerDetailsCommand = new DelegateCommand<object>(new Action<object>(this.OnViewCustomerDetails));
            this.DeleteCustomerCommand = new DelegateCommand<object>(new Action<object>(this.OnDeleteCustomer));
        }

        private void LoadCustomerInfo(string sql = "")
        {
            AccessDbHelper helper = new AccessDbHelper();
            DataTable dt = helper.SelectToDataTable(string.IsNullOrEmpty(sql) ? "Select * from CustomerInfo" : sql);
            helper.Close();
            List<CustomerBasicInfoModel> list = dt.List<CustomerBasicInfoModel>();
            this.CustomerList.Clear();
            foreach (CustomerBasicInfoModel model in list)
            {
                this.CustomerList.Add(model);
            }
        }

        private void OnAddCustomer(object payload)
        {
            this._eventAggregator.GetEvent<AddCustomerEvent>().Publish(null);
        }

        private void OnDeleteCustomer(object payload)
        {
            if (MessageBox.Show("大龙，你真的要删除么？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.No)
            {
                AccessDbHelper helper = new AccessDbHelper();
                helper.ExecuteSQLNonquery(string.Format("delete from CustomerInfo where CustomerNo='{0}'", this.SelectedModel.CustomerNo));
                helper.Close();
                this.LoadCustomerInfo("");
            }
        }

        private void OnSearchCustomerInfo(object payload)
        {
            string sql = string.Empty;
            switch (this.SelectedConditon.ConditonType)
            {
                case SearchConditionEnum.JOIN_DATE:
                    sql = string.Format("Select * from CustomerInfo where CreateDate=#{0}#", this.EnteredCondition.Trim());
                    break;

                case SearchConditionEnum.CUSTOMER_NO:
                    sql = string.Format("Select * from CustomerInfo where CustomerNo='{0}'", this.EnteredCondition.Trim());
                    break;

                case SearchConditionEnum.BEAUTY_ADVISOR:
                    sql = string.Format("Select * from CustomerInfo where BeautyAdvisor='{0}'", this.EnteredCondition.Trim());
                    break;

                case SearchConditionEnum.CUSTOMER_NAME:
                    sql = string.Format("Select * from CustomerInfo where CustomerName='{0}'", this.EnteredCondition.Trim());
                    break;

                case SearchConditionEnum.BIRTHDAY:
                    sql = string.Format("Select * from CustomerInfo where Birthday=#{0}#", this.EnteredCondition.Trim());
                    break;

                case SearchConditionEnum.TELEPHONE_NUMBER:
                    sql = string.Format("Select * from CustomerInfo where TelephoneNumber='{0}'", this.EnteredCondition.Trim());
                    break;

                case SearchConditionEnum.TRADE:
                    sql = string.Format("Select * from CustomerInfo where Trade='{0}'", this.EnteredCondition.Trim());
                    break;

                case SearchConditionEnum.QQ:
                    sql = string.Format("Select * from CustomerInfo where QQNumber='{0}'", this.EnteredCondition.Trim());
                    break;
            }
            this.LoadCustomerInfo(sql);
        }

        private void OnUpdateCustomer(object payload)
        {
            this._eventAggregator.GetEvent<EidtCustomerEvent>().Publish(this.SelectedModel);
        }

        private void OnViewCustomerDetails(object payload)
        {
            this._eventAggregator.GetEvent<ViewCustomerDetailsEvent>().Publish(this.SelectedModel);
        }

        private void SubscribeEvents()
        {
            this._eventAggregator.GetEvent<RefreshMainViewDataEvent>().Subscribe(new Action<object>(this.OnSearchCustomerInfo));
        }

        #endregion

        #region Public properties

        public ObservableCollection<CustomerBasicInfoModel> CustomerList { get; set; }

        public string EnteredCondition { get; set; }

        public ObservableCollection<SearchConditionModel> SearchConditionList { get; set; }

        public SearchConditionModel SelectedConditon { get; set; }

        public CustomerBasicInfoModel SelectedModel { get; set; }

        #endregion

        #region commands

        public ICommand UpdateCustomerCommand { get; set; }

        public ICommand ViewCustomerDetailsCommand { get; set; }

        public ICommand AddCustomerCommand { get; set; }

        public ICommand SearchCustomerInfoCommand { get; set; }

        public ICommand DeleteCustomerCommand { get; set; }

        #endregion
    }
}

