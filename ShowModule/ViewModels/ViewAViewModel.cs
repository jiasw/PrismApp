using Prism.Application.Contract;
using Prism.Commands;
using Prism.Mvvm;
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

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        public DelegateCommand<string> ShowMessageCommand { get; private set; }

        public ViewAViewModel(IShowData showData)
        {
            Message = "View A from your Prism Module";
            this.showData = showData;
            Message = showData.ShowDataMsg();
        }
    }
}
