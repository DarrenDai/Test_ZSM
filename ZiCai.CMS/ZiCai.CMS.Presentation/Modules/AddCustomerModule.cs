using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Runtime.CompilerServices;
using ZiCai.CMS.Framework;
using ZiCai.CMS.Presentation.Presenters;

namespace ZiCai.CMS.Presentation.Modules
{
    public class AddCustomerModule : IModule
    {
        public AddCustomerModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.Container = container;
            this.RegionManager = regionManager;
            this.EventAggregator = eventAggregator;
            this.EventAggregator.GetEvent<AddCustomerEvent>().Subscribe(new Action<object>(this.OnAddCustomer), true);
        }

        public void Initialize()
        {
        }

        private void OnAddCustomer(object payload)
        {
            AddCustomerPrsenter prsenter = this.Container.Resolve<AddCustomerPrsenter>(new ResolverOverride[0]);
            this.RegionManager.Regions["MainRegion"].Add(prsenter.View);
        }

        public IUnityContainer Container { get; private set; }

        public IEventAggregator EventAggregator { get; private set; }

        public IRegionManager RegionManager { get; private set; }
    }
}

