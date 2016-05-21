using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Reflection;
using System.Windows;
using ZSM.CMS.Presentation;
using ZSM.CMS.Presentation.Modules;

namespace ZSM.CMS.Launcher
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var shell = new Shell();
            shell.Title = string.Format("{0} - 客户管理系统 - {1}",
                ApplicationContext.Current.Configuration.CompanyName,
                Assembly.GetExecutingAssembly().GetName().Version.ToString());

            shell.Show();
            return shell;
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            IModule module = base.Container.Resolve<MainViewModule>(new ResolverOverride[0]);
            module.Initialize();

            base.Container.Resolve<CustomersModule>(new ResolverOverride[0]);
            base.Container.Resolve<UsersModule>(new ResolverOverride[0]);
            base.Container.Resolve<DataManagementModule>(new ResolverOverride[0]);
        }
    }
}

