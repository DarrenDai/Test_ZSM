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
    public class MainViewModule : IModule
    {
        public MainViewModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.Container = container;
            this.RegionManager = regionManager;
            this.EventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            MainViewPresenter presenter = this.Container.Resolve<MainViewPresenter>(new ResolverOverride[0]);
            this.RegionManager.Regions["MainRegion"].Add(presenter.View);
        }

        public IUnityContainer Container { get; private set; }

        public IEventAggregator EventAggregator { get; private set; }

        public IRegionManager RegionManager { get; private set; }
    }
}

