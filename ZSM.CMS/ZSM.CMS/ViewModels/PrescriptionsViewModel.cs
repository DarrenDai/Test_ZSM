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
using System;

namespace ZSM.CMS.Presentation.ViewModels
{
    public class PrescriptionsViewModel : ViewModelBase
    {
        #region Private field
        #endregion

        #region Constructor

        public PrescriptionsViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, Prescriptions view)
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

        public CustomerModel CustomerInfo { get; set; }

        #endregion

        #region Initialize Methods

        public override void InitializeDisplay()
        {
            using (var helper = new AccessDbHelper())
            {
                Items = helper.GetDataTable(string.Format(@"SELECT * FROM [Prescription] WHERE CustomerId= {0} AND ISDELETED = 0", CustomerInfo.Id)).ToItemList<Prescription>().Select(x => (IModel)x.ToViewModel()).ToList();
            }

            base.InitializeDisplay();
        }

        public override void InitializeSearch()
        {
            //SearchConditionList = new List<SearchCondition>();
            //SearchConditionList.Add(new SearchCondition() { Name = "客户姓名", DbKey = "CustomerName" });
        }

        #endregion

        #region Publc methos

        #endregion

        #region Command handlers

        public override void OnSearch(object param)
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                Items = TempItems.Select(x => x).ToList();
            }
            else
            {
                Logger.Debug(string.Format("Search prescription with text- {0}", SearchText));
                Items = TempItems.Where(x => ((PrescriptionModel)x).Comments.Contains(SearchText.Trim())).ToList();
            }
        }

        public override void OnNew(object param)
        {

            var viewModel = this.Container.Resolve<PrescriptionDetailsViewModel>(new ResolverOverride[0]);
            viewModel.CustomerInfo = this.CustomerInfo;
            viewModel.SetPrescription(new PrescriptionModel() { CreateDate = DateTime.Now });
            viewModel.Initialize();
            viewModel.SavedSucceed += (object obj) =>
            {
                this.RegionManager.Regions[RegionNames.MainRegion].Remove(viewModel.View);
                InitializeDisplay();
            };
            Logger.Debug(string.Format("Create new prescription for customer- {0}", CustomerInfo));
            this.RegionManager.Regions[RegionNames.MainRegion].Add(viewModel.View);
        }

        public override void OnDetails(object param)
        {
            if (SelectedItem == null)
                return;

            var viewModel = this.Container.Resolve<PrescriptionDetailsViewModel>(new ResolverOverride[0]);
            viewModel.CustomerInfo = this.CustomerInfo;
            viewModel.SetPrescription((PrescriptionModel)SelectedItem);
            viewModel.Initialize();
            viewModel.SavedSucceed += (object obj) =>
            {
                this.RegionManager.Regions[RegionNames.MainRegion].Remove(viewModel.View);
                InitializeDisplay();
            };

            Logger.Debug(string.Format("Shows prescription details- {0}", (PrescriptionModel)SelectedItem));

            this.RegionManager.Regions[RegionNames.MainRegion].Add(viewModel.View);
        }

        public override void OnDelete(object param)
        {
            if (SelectedItem == null)
                return;

            if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Logger.Debug(string.Format("Deleting prescription- {0}", (PrescriptionModel)SelectedItem));

                ((PrescriptionModel)SelectedItem).ToDataModel().DeleteFromDb();
                InitializeDisplay();
            }
        }

        #endregion

        #region Private methods

        #endregion
    }
}
