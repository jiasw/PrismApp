﻿using Application.ShowData;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ShowModule.Views;
using System;

namespace ShowModule
{
    public class ShowModuleModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ShowModuleModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
            Console.WriteLine("ShowModuleModule initialized");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IShowData, ShowData>();
            Console.WriteLine("ShowModuleModule registering types");
        }
    }
}