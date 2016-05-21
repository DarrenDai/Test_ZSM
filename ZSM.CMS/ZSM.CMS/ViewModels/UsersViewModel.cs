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
    class UsersViewModel : ViewModelBase
    {
        #region Private field
        #endregion

        #region Constructor

        public UsersViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, Users view)
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
            using (AccessDbHelper helper = new AccessDbHelper())
            {
                Items = helper.GetDataTable(@"SELECT * FROM [USER] WHERE ISDELETED = 0").ToItemList<User>().Select(x => (IModel)x.ToViewModel()).ToList();
            }

            base.InitializeDisplay();
        }

        public override void InitializeSearch()
        {
            SearchConditionList = new List<SearchCondition>();
            SearchConditionList.Add(new SearchCondition() { Name = "用户名", DbKey = "UserName" });
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
                Logger.Debug(string.Format("Search user with text- {0}", SearchText));
                Items = TempItems.Where(x => ((UserModel)x).UserName.Contains(SearchText.Trim())).ToList();
            }
        }

        public override void OnNew(object param)
        {
            var viewModel = this.Container.Resolve<UserDetailsViewModel>(new ResolverOverride[0]);
            viewModel.SetUser(new UserModel() { CreateDate = DateTime.Now, UpdateDate = DateTime.Now });
            viewModel.Initialize();
            viewModel.SavedSucceed += (object obj) =>
            {
                this.RegionManager.Regions[RegionNames.MainRegion].Remove(viewModel.View);
                InitializeDisplay();
            };

            Logger.Debug(string.Format("Create new user- {0}", (UserModel)SelectedItem));
            this.RegionManager.Regions[RegionNames.MainRegion].Add(viewModel.View);
        }

        public override void OnDetails(object param)
        {
            if (SelectedItem == null)
                return;

            var viewModel = this.Container.Resolve<UserDetailsViewModel>(new ResolverOverride[0]);
            viewModel.SetUser((UserModel)SelectedItem);
            viewModel.Initialize();
            viewModel.SavedSucceed += (object obj) =>
            {
                this.RegionManager.Regions[RegionNames.MainRegion].Remove(viewModel.View);
                InitializeDisplay();
            };

            Logger.Debug(string.Format("Shows details of user- {0}", (UserModel)SelectedItem));

            this.RegionManager.Regions[RegionNames.MainRegion].Add(viewModel.View);
        }

        public override void OnDelete(object param)
        {
            if (SelectedItem == null)
                return;

            if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Logger.Debug(string.Format("Deleting user- {0}", (UserModel)SelectedItem));
                ((UserModel)SelectedItem).ToDataModel().DeleteFromDb();
                InitializeDisplay();
            }
        }

        #endregion

        #region Private methods

        #endregion
    }
}
