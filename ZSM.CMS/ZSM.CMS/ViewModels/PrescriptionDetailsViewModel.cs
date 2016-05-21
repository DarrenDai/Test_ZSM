using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using ZSM.CMS.Presentation.Models;
using ZSM.CMS.Presentation.Extensions;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Presentation.ViewModels
{
    class PrescriptionDetailsViewModel : ViewModelBase
    {
        #region Private field

        private PrescriptionModel _prescription;

        #endregion

        #region Constructor

        public PrescriptionDetailsViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, PrescriptionDetails view)
            : base(view)
        {
            Container = container;
            RegionManager = regionManage;
            EventAggregator = eventAggregator;
        }

        #endregion

        #region Commands

        public ICommand PrintCommand { get; set; }

        #endregion

        #region Initialize Methods

        public override void InitializeCommands()
        {
            base.InitializeCommands();

            PrintCommand = new DelegateCommand<object>(new Action<object>(OnPrint));
        }

        #endregion

        #region Publc methos

        public void SetPrescription(PrescriptionModel prescription)
        {
            SelectedItem = prescription;
            _prescription = prescription;
            if (_prescription.Id == 0)
            {
                IsEidtEnabled = true;
            }
        }

        #endregion

        #region Public properties

        public CustomerModel CustomerInfo { get; set; }

        #endregion

        #region Command handlers

        public override void OnSave(object param)
        {
            bool result = _prescription.Id == 0 ? CreateNewItem() : UpdateItem();

            if (result)
                base.OnSave(param);
            else
                MessageBox.Show("Save failed.");
        }

        public void OnPrint(object param)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog().Value)
            {
                FlowDocument doc = (FlowDocument)param;
                DocumentPaginator page = ((IDocumentPaginatorSource)doc).DocumentPaginator;
                IsEidtEnabled = true;
                printDialog.PrintDocument(page, "Test Description");
                IsEidtEnabled = false;

                Logger.Debug(string.Format("Printed prescription for customer- {0}", CustomerInfo));
                OnBack(null);
            }
        }

        #endregion

        #region Private methods

        private bool UpdateItem()
        {
            Logger.Debug(string.Format("Update prescription for customer- {0}", CustomerInfo));
            return _prescription.ToDataModel().UpdateToDb();
        }

        private bool CreateNewItem()
        {
            Logger.Debug(string.Format("Create prescription for customer- {0}", CustomerInfo));
            _prescription.CreateDate = DateTime.Now;
            _prescription.CustomerId = CustomerInfo.Id;
            return _prescription.ToDataModel().SaveToDb();
        }

        #endregion
    }
}
