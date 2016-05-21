using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Windows;
using ZiCai.CMS.Presentation.Modules;

namespace ZiCai.CMS.Launcher
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Shell shell = new Shell();
            shell.Show();
            return shell;
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            IModule module = base.Container.Resolve<MainViewModule>(new ResolverOverride[0]);
            base.Container.Resolve<AddCustomerModule>(new ResolverOverride[0]);
            base.Container.Resolve<UpdateCustomerModule>(new ResolverOverride[0]);
            base.Container.Resolve<CustomerDetailsModule>(new ResolverOverride[0]);
            base.Container.Resolve<AddPurchaseInfoHistoryModule>(new ResolverOverride[0]);
            base.Container.Resolve<UpdatePurchaseInfoHistoryModule>(new ResolverOverride[0]);
            module.Initialize();
        }
    }
}

