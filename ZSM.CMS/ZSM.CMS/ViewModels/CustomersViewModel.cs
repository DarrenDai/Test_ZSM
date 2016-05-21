using DDSoft.Common;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ZSM.CMS.Presentation.DataModel;
using ZSM.CMS.Presentation.Models;
using ZSM.CMS.Presentation.Extensions;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Presentation.ViewModels
{
    class CustomersViewModel : ViewModelBase
    {
        #region Private field
        #endregion

        #region Constructor

        public CustomersViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, Customers view)
            : base(view)
        {
            Container = container;
            RegionManager = regionManage;
            EventAggregator = eventAggregator;
        }

        #endregion

        #region Commands
        #endregion

        #region Public Properties
        #endregion

        #region Initialize Methods

        public override void InitializeDisplay()
        {
            using (var helper = new AccessDbHelper())
            {
                Items = helper.GetDataTable(@"SELECT * FROM [CUSTOMER] WHERE ISDELETED = 0").ToItemList<Customer>().Select(x => (IModel)x.ToViewModel()).ToList();
            }

            base.InitializeDisplay();
        }

        public override void InitializeSearch()
        {
            SearchConditionList = new List<SearchCondition>();
            SearchConditionList.Add(new SearchCondition() { Name = "客户姓名", DbKey = "CustomerName" });
        }

        #endregion

        #region Publc methos

        #endregion

        #region Command handlers

        public override void OnSearch(object param)
        {
            Logger.Debug(string.Format("Search customer with param:{0}", SearchText));

            if (string.IsNullOrEmpty(SearchText))
            {
                Items = TempItems.Select(x => x).ToList();
            }
            else
            {
                Items = TempItems.Where(x => ((CustomerModel)x).CustomerName.Contains(SearchText.Trim())).ToList();
            }
        }

        public override void OnNew(object param)
        {
            Logger.Debug(string.Format("Create customer..."));

            var viewModel = this.Container.Resolve<CustomerDetailsViewModel>(new ResolverOverride[0]);
            viewModel.SetCustomer(new CustomerModel());
            viewModel.Initialize();
            viewModel.SavedSucceed += (object obj) =>
            {
                this.RegionManager.Regions[RegionNames.MainRegion].Remove(viewModel.View);
                InitializeDisplay();
            };

            this.RegionManager.Regions[RegionNames.MainRegion].Add(viewModel.View);
        }

        public override void OnDetails(object param)
        {
            if (SelectedItem == null)
                return;

            var viewModel = this.Container.Resolve<CustomerDetailsViewModel>(new ResolverOverride[0]);
            viewModel.SetCustomer((CustomerModel)SelectedItem);
            viewModel.Initialize();
            viewModel.SavedSucceed += (object obj) =>
            {
                this.RegionManager.Regions[RegionNames.MainRegion].Remove(viewModel.View);
                InitializeDisplay();
            };

            Logger.Debug(string.Format("Shows the details of customer- {0}", ((CustomerModel)SelectedItem)));

            this.RegionManager.Regions[RegionNames.MainRegion].Add(viewModel.View);
        }

        public override void OnDelete(object param)
        {
            if (SelectedItem == null)
                return;

            if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Logger.Debug(string.Format("Deleting customer- {0}", ((CustomerModel)SelectedItem)));

                ((CustomerModel)SelectedItem).ToDataModel().DeleteFromDb();
                InitializeDisplay();
            }
        }

        #endregion

        #region Private methods

        #endregion
    }
}
