using DDSoft.Common;
using DDSoft.Framework;
using log4net;
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

namespace ZSM.CMS.Presentation.ViewModels
{
    public class ViewModelBase : NotifyPropertyChangedObject, IViewModel
    {
        #region Private field

        private List<IModel> _items = null;
        private bool _isEidtEnabled;
        private IModel _selectedItem;
        private string _searchText;
        //private bool _isEidtButtonEnabled;
        private Visibility _eidtButtonVisible;
        private Visibility _saveButtonVisible;
        //private List<string> _searchConditionList;

        #endregion

        #region Constructor

        public ViewModelBase()
        {
        }

        public ViewModelBase(IView view)
        {
            View = view;
            View.DataContext = this;
        }

        #endregion

        #region Commands

        public ICommand SearchCommand { get; set; }

        public ICommand NewCommand { get; set; }

        public ICommand DetailsCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand BackCommand { get; set; }

        #endregion

        #region Public Properties

        public IView View { get; set; }

        public List<IModel> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged(() => Items);
            }
        }

        public int Count
        {
            get { return Items.Count(); }
        }

        public List<IModel> TempItems { get; set; }

        public List<SearchCondition> SearchConditionList
        {
            get;
            set;
            //get
            //{
            //    return _searchConditionList;
            //}
            //set
            //{
            //    _searchConditionList = value;
            //    OnPropertyChanged(() => SearchConditionList);
            //}
        }

        public SearchCondition SelectedConditon { get; set; }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(() => SearchText);
            }
        }

        public IModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(() => SelectedItem);
            }
        }

        public bool IsEidtEnabled
        {
            get { return _isEidtEnabled; }
            set
            {
                _isEidtEnabled = value;
                OnPropertyChanged(() => IsEidtEnabled);
            }
        }

        //public bool IsEidtButtonEnabled
        //{
        //    get { return _isEidtButtonEnabled; }
        //    set { _isEidtButtonEnabled = value; OnPropertyChanged(() => IsEidtButtonEnabled); }
        //}

        public Visibility EidtButtonVisible
        {
            get { return _eidtButtonVisible; }
            set { _eidtButtonVisible = value; OnPropertyChanged(() => EidtButtonVisible); }
        }

        public Visibility SaveButtonVisible
        {
            get { return _saveButtonVisible; }
            set { _saveButtonVisible = value; OnPropertyChanged(() => SaveButtonVisible); }
        }

        #endregion

        #region Protected properties

        protected IUnityContainer Container { get; set; }

        protected IRegionManager RegionManager { get; set; }

        protected IEventAggregator EventAggregator { get; set; }

        public ILog Logger { get { return ApplicationContext.Current.Logger; } }

        public ApplicationContext AppContext { get { return ApplicationContext.Current; } }

        #endregion

        #region Events

        public event Action<object> SavedSucceed;
        //public event Action<object, object> Saved;
        //public event Action<object, object> Saved;

        #endregion

        #region Initialize Methods

        public virtual void Initialize()
        {
            InitializeCommands();
            InitializeDisplay();
            InitializeSearch();
        }

        public virtual void InitializeDisplay()
        {
            if (Items != null)
                TempItems = Items.Select(x => x).ToList();

            if (SelectedItem != null)
            {
                //Detail view
                if (SelectedItem.Id != 0)
                {
                    EidtButtonVisible = Visibility.Visible;
                    SaveButtonVisible = Visibility.Collapsed;

                }
                //New item view
                else
                {
                    EidtButtonVisible = Visibility.Collapsed;
                    SaveButtonVisible = Visibility.Visible;
                }
            }

            OnPropertyChanged(() => Count);
        }

        public virtual void InitializeSearch()
        {

        }

        public virtual void InitializeCommands()
        {
            SearchCommand = new DelegateCommand<object>(new Action<object>(OnSearch));

            NewCommand = new DelegateCommand<object>(new Action<object>(OnNew));

            DetailsCommand = new DelegateCommand<object>(new Action<object>(OnDetails));

            DeleteCommand = new DelegateCommand<object>(new Action<object>(OnDelete));

            EditCommand = new DelegateCommand<object>(new Action<object>(OnEdit));
            SaveCommand = new DelegateCommand<object>(new Action<object>(OnSave));

            BackCommand = new DelegateCommand<object>(new Action<object>(OnBack));
        }

        #endregion

        #region Publc methos

        #endregion

        #region Command handlers

        public virtual void OnSearch(object param)
        {

        }

        public virtual void OnNew(object param)
        {

        }

        public virtual void OnDetails(object param)
        {

        }

        public virtual void OnDelete(object param)
        {

        }

        public virtual void OnEdit(object param)
        {
            IsEidtEnabled = true;
            EidtButtonVisible = Visibility.Hidden;
            SaveButtonVisible = Visibility.Visible;
        }

        public virtual void OnSave(object param)
        {
            if (SavedSucceed != null)
                SavedSucceed.Invoke(SelectedItem);
        }

        public virtual void OnBack(object param)
        {
            RemoveView(this);
        }

        #endregion

        #region Protected methods

        protected void AppendView<T>()
        {
            Logger.Debug("Opening view.");
            var viewModel = this.Container.Resolve<T>(new ResolverOverride[0]);
            ((IViewModel)viewModel).Initialize();
            this.RegionManager.Regions[RegionNames.MainRegion].Add(((IViewModel)viewModel).View);
        }

        protected void RemoveView(IViewModel viewModel)
        {
            Logger.Debug("Closing view.");
            this.RegionManager.Regions[RegionNames.MainRegion].Remove(viewModel.View);
        }

        #endregion

        #region Private methods

        #endregion
    }
}
