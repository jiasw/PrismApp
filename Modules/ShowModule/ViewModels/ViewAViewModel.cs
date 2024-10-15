using Prism.Application.Contract;
using Prism.Application.Infrastructure.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowModule.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _message;
        private readonly IShowData showData;
        private readonly IEventAggregator _eventAggregator;
        private readonly IRegionManager regionManager;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        public DelegateCommand<string> ShowMessageCommand { get; private set; }

        public ViewAViewModel(IShowData showData, IEventAggregator ea, IRegionManager regionManager)
        {
            Message = "View A from your Prism Module";
            this.showData = showData;
            this._eventAggregator = ea;
            this.regionManager = regionManager;
            Message = showData.ShowDataMsg();
            
        }

        public DelegateCommand PublishMessageCommand => new DelegateCommand(() =>
        {
            _eventAggregator.GetEvent<TickerSymbolSelectedEvent>().Publish("STOCK0");
            regionManager.RequestNavigate("ContentRegion", "ViewB");
        });

        
    }
}
