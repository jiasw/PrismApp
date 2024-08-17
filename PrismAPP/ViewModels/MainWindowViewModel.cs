using Prism.Mvvm;

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

        public MainWindowViewModel()
        {

        }
    }
}
