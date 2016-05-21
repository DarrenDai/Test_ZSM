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
    public class AddPurchaseInfoHistoryModule : IModule
    {
        public AddPurchaseInfoHistoryModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.Container = container;
            this.RegionManager = regionManager;
            this.EventAggregator = eventAggregator;
            this.EventAggregator.GetEvent<AddPurchaseInfoHistoryEvent>().Subscribe(new Action<object>(this.OnAddPurchaseHistory), true);
        }

        public void Initialize()
        {
        }

        private void OnAddPurchaseHistory(object customerInfo)
        {
            AddPurchaseInfoHistoryPrsenter prsenter = this.Container.Resolve<AddPurchaseInfoHistoryPrsenter>(new ResolverOverride[0]);
            prsenter.Initialize(customerInfo);
            this.RegionManager.Regions["MainRegion"].Add(prsenter.View);
        }

        public IUnityContainer Container { get; private set; }

        public IEventAggregator EventAggregator { get; private set; }

        public IRegionManager RegionManager { get; private set; }
    }
}

