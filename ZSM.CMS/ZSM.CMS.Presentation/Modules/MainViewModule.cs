using DDSoft.Common;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZSM.CMS.Presentation.ViewModels;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Presentation.Modules
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
            var viewModel = this.Container.Resolve<MainViewViewModel>(new ResolverOverride[0]);
            viewModel.Initialize();
            this.RegionManager.Regions[RegionNames.MainRegion].Add(viewModel.View);

            if (!ApplicationContext.Current.Configuration.IsDebugMode)
            {
                var loginView = this.Container.Resolve<LoginViewModel>(new ResolverOverride[0]);
                loginView.Initialize();
                this.RegionManager.Regions[RegionNames.MainRegion].Add(loginView.View);
            }
        }

        public IUnityContainer Container { get; private set; }

        public IEventAggregator EventAggregator { get; private set; }

        public IRegionManager RegionManager { get; private set; }
    }
}