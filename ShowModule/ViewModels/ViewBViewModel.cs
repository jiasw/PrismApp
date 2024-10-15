using Prism.Application.Infrastructure.Event;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowModule.ViewModels
{
    public class ViewBViewModel: BindableBase
    {
        private readonly IEventAggregator ea;
        private string _message="B View";

        public ViewBViewModel(IEventAggregator ea)
        {
            this.ea = ea;
            ea.GetEvent<TickerSymbolSelectedEvent>().Subscribe(ShowNews);
        }

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private void ShowNews(string symbol)
        {
            Message = symbol;
        }
    }
}
