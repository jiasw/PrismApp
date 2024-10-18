using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Scottplot.Views.ScottplotDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scottplot
{
    public class ScottplotModule : IModule
    {
        private readonly IRegionManager regionManager;

        public ScottplotModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(SimpleDemo));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SimpleDemo>();
        }
    }
}
