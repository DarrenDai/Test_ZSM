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
    public class UpdateCustomerModule : IModule
    {
        public UpdateCustomerModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.Container = container;
            this.RegionManager = regionManager;
            this.EventAggregator = eventAggregator;
            this.EventAggregator.GetEvent<EidtCustomerEvent>().Subscribe(new Action<object>(this.OnUpdateCustomer), true);
        }

        public void Initialize()
        {
        }

        private void OnUpdateCustomer(object customerInfo)
        {
            CustomerBasicInfoModel model = customerInfo as CustomerBasicInfoModel;
            UpdateCustomerPrsenter prsenter = this.Container.Resolve<UpdateCustomerPrsenter>(new ResolverOverride[0]);
            prsenter.Initialize(model);
            this.RegionManager.Regions["MainRegion"].Add(prsenter.View);
        }

        public IUnityContainer Container { get; private set; }

        public IEventAggregator EventAggregator { get; private set; }

        public IRegionManager RegionManager { get; private set; }
    }
}

