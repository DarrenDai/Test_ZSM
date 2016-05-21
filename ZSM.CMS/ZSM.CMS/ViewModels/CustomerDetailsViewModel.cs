using DDSoft.Common;
using DDSoft.Framework;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ZSM.CMS.Presentation.Models;
using ZSM.CMS.Presentation.Extensions;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Presentation.ViewModels
{
    class CustomerDetailsViewModel : ViewModelBase
    {
        #region Private field

        private CustomerModel _customer;

        #endregion

        #region Constructor

        public CustomerDetailsViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, CustomerDetails view)
            : base(view)
        {
            Container = container;
            RegionManager = regionManage;
            EventAggregator = eventAggregator;
        }

        #endregion

        #region Commands

        public ICommand PJDCommand { get; set; }

        #endregion

        #region Public Properties
        #endregion

        #region Initialize Methods

        public override void InitializeCommands()
        {
            base.InitializeCommands();

            PJDCommand = new DelegateCommand<object>(new Action<object>(OnPJD));
        }

        #endregion

        #region Publc methos

        public void SetCustomer(CustomerModel customer)
        {
            SelectedItem = customer;
            _customer = customer;
            if (_customer.Id == 0)
            {
                IsEidtEnabled = true;
            }
        }

        #endregion

        #region Command handlers

        public override void OnSave(object param)
        {
            bool result = _customer.Id == 0 ? CreateNewItem() : UpdateItem();

            if (result)
                base.OnSave(param);
            else
                MessageBox.Show("Save failed.");
        }

        #endregion

        #region Command handlers

        public virtual void OnPJD(object param)
        {
            //AppendView<PrescriptionsViewModel>();
            var viewModel = this.Container.Resolve<PrescriptionsViewModel>(new ResolverOverride[0]);
            viewModel.CustomerInfo = SelectedItem as CustomerModel;
            viewModel.Initialize();

            Logger.Debug(string.Format("Open prescription for customer:{0}", viewModel.CustomerInfo));
            this.RegionManager.Regions[RegionNames.MainRegion].Add(((IViewModel)viewModel).View);
        }

        #endregion

        #region Private methods

        private bool UpdateItem()
        {
            Logger.Debug(string.Format("Updated for customer:{0}", _customer));
            return _customer.ToDataModel().UpdateToDb();
        }

        private bool CreateNewItem()
        {
            Logger.Debug(string.Format("Creating customer:{0}", _customer));
            _customer.CreateDate = DateTime.Now;
            return _customer.ToDataModel().SaveToDb();
        }

        #endregion
    }
}
