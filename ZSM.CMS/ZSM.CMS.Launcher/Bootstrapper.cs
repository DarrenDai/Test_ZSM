using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
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
        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>The shell of the application.</returns>
        /// <remarks>
        /// If the returned instance is a <see cref="DependencyObject"/>, the
        /// <see cref="Bootstrapper"/> will attach the default <seealso cref="Prism.Regions.IRegionManager"/> of
        /// the application in its <see cref="Prism.Regions.RegionManager.RegionManagerProperty"/> attached property
        /// in order to be able to add regions by using the <seealso cref="Prism.Regions.RegionManager.RegionNameProperty"/>
        /// attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell()
        {
            var shell = ServiceLocator.Current.GetInstance<Shell>();
            shell.Title = string.Format("{0} - 客户管理系统 - {1}",
                ApplicationContext.Current.Configuration.CompanyName,
                Assembly.GetExecutingAssembly().GetName().Version.ToString());
            return shell;
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        /// <remarks>
        /// The base implemention ensures the shell is composed in the container.
        /// </remarks>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the <see cref="IUnityContainer"/>. May be overwritten in a derived class to add specific
        /// type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        /// <summary>
        /// Returns the module catalog that will be used to initialize the modules.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IModuleCatalog"/> that will be used to initialize the modules.
        /// </returns>
        /// <remarks>
        /// When using the default initialization behavior, this method must be overwritten by a derived class.
        /// </remarks>
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new AggregateModuleCatalog();
        //}

        protected override void InitializeModules()
        {
            base.InitializeModules();
            //this.ModuleCatalog.AddModule();
            //IModule module = base.Container.Resolve<MainViewModule>(new ResolverOverride[0]);
            //module.Initialize();
            //base.Container.Resolve<CustomersModule>(new ResolverOverride[0]);
            //base.Container.Resolve<UsersModule>(new ResolverOverride[0]);
            //base.Container.Resolve<DataManagementModule>(new ResolverOverride[0]);
        }

        protected override void ConfigureModuleCatalog()
        {
            AddModule<MainViewModule>();
            AddModule<CustomersModule>();
            AddModule<UsersModule>();
            AddModule<DataManagementModule>();

            //Type moduleCType = typeof(ModuleC);
            //ModuleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = moduleCType.Name,
            //    ModuleType = moduleCType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.OnDemand
            //});

            // Module B and Module D are copied to a directory as part of a post-build step.
            // These modules are not referenced in the project and are discovered by inspecting a directory.
            // Both projects have a post-build step to copy themselves into that directory.
            //DirectoryModuleCatalog directoryCatalog = new DirectoryModuleCatalog() { ModulePath = @".\DirectoryModules" };
            //((AggregateModuleCatalog)ModuleCatalog).AddCatalog(directoryCatalog);

            // Module E and Module F are defined in configuration.
            //ConfigurationModuleCatalog configurationCatalog = new ConfigurationModuleCatalog();
            //((AggregateModuleCatalog)ModuleCatalog).AddCatalog(configurationCatalog);
        }

        private void AddModule<T>()
        {
            var moduleType = typeof(T);
            ModuleCatalog.AddModule(new ModuleInfo(moduleType.Name, moduleType.AssemblyQualifiedName));
        }
    }
}

