using DDSoft.Common;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ZSM.CMS.Presentation.Models;
using ZSM.CMS.Presentation.Extensions;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Presentation.ViewModels
{
    class UserDetailsViewModel : ViewModelBase
    {
        #region Private field

        private UserModel _user;

        #endregion

        #region Constructor

        public UserDetailsViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, UserDetails view)
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

        #endregion

        #region Publc methos

        public void SetUser(UserModel user)
        {
            SelectedItem = user;
            _user = user;
            if (_user.Id == 0)
            {
                IsEidtEnabled = true;
            }
        }

        #endregion

        #region Command handlers

        public override void OnSave(object param)
        {
            bool result = _user.Id == 0 ? CreateNewItem() : UpdateItem();

            if (result)
                base.OnSave(param);
            else
                MessageBox.Show("Save failed.");
        }

        #endregion

        #region Private methods

        private bool UpdateItem()
        {
            Logger.Debug(string.Format("Update user- {0}", (UserModel)SelectedItem));
            _user.UpdateDate = DateTime.Now;
            return _user.ToDataModel().UpdateToDb();
        }

        private bool CreateNewItem()
        {
            Logger.Debug(string.Format("Create new user- {0}", (UserModel)SelectedItem));
            _user.CreateDate = DateTime.Now;
            _user.UpdateDate = DateTime.Now;
            return _user.ToDataModel().SaveToDb();
        }

        #endregion
    }
}
