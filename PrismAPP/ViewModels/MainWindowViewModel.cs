﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace PrismAPP.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "主窗体";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private readonly IRegionManager _regionManager;

        public ICommand ShowViewACommand { get; private set; }
        public ICommand ShowViewBCommand { get; private set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            ShowViewACommand = new DelegateCommand(ExecuteShowViewA);
            ShowViewBCommand = new DelegateCommand(ExecuteShowViewB);
        }

        private void ExecuteShowViewA()
        {
            _regionManager.RequestNavigate("MainRegion", "ViewA");
        }

        private void ExecuteShowViewB()
        {
            _regionManager.RequestNavigate("MainRegion", "ViewB");
        }
    }
}
