using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using PrismAPP.Views;
using Scottplot;
using ShowModule;
using System.Windows;

namespace PrismAPP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IEventAggregator, EventAggregator>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);


            //添加模块A
            moduleCatalog.AddModule<ShowModuleModule>();
            moduleCatalog.AddModule<ScottplotModule>();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return base.CreateModuleCatalog();
        //}
    }
}
