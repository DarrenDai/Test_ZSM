using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Runtime.CompilerServices;
using ZiCai.CMS.Framework;
using ZiCai.CMS.Presentation.Presenters;
using ZiCai.CMS.ViewModels;

namespace ZiCai.CMS.Presentation.Modules
{
    public class CustomerDetailsModule : IModule
    {
        public CustomerDetailsModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.Container = container;
            this.RegionManager = regionManager;
            this.EventAggregator = eventAggregator;
            this.EventAggregator.GetEvent<ViewCustomerDetailsEvent>().Subscribe(new Action<object>(this.OnViewCustomerDetails), true);
        }

        public void Initialize()
        {
        }

        private void OnViewCustomerDetails(object customerInfo)
        {
            CustomerBasicInfoModel model = customerInfo as CustomerBasicInfoModel;
            CustomerDetailsPrsenter prsenter = this.Container.Resolve<CustomerDetailsPrsenter>(new ResolverOverride[0]);
            prsenter.Initialize(model);
            this.RegionManager.Regions["MainRegion"].Add(prsenter.View);
        }

        public IUnityContainer Container { get; private set; }

        public IEventAggregator EventAggregator { get; private set; }

        public IRegionManager RegionManager { get; private set; }
    }
}

