using DDSoft.Common;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZSM.CMS.Presentation.Events;
using ZSM.CMS.Presentation.ViewModels;

namespace ZSM.CMS.Presentation.Modules
{
    public class DataManagementModule : IModule
    {
        public DataManagementModule(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.Container = container;
            this.RegionManager = regionManager;
            this.EventAggregator = eventAggregator;

            this.EventAggregator.GetEvent<DataManagementEvent>().Subscribe(new Action<object>(this.OnDataManagement), true);
        }

        public void Initialize()
        {
            
        }

        private void OnDataManagement(object param)
        {
            var viewModel = this.Container.Resolve<DataMangementViewModel>(new ResolverOverride[0]);
            viewModel.Initialize();
            this.RegionManager.Regions[RegionNames.MainRegion].Add(viewModel.View);
        }

        public IUnityContainer Container { get; private set; }

        public IEventAggregator EventAggregator { get; private set; }

        public IRegionManager RegionManager { get; private set; }
    }
}
