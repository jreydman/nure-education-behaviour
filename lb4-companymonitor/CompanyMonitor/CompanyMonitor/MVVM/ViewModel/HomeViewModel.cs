using CompanyMonitor.Core;
using CompanyMonitor.Utilities;

namespace CompanyMonitor.MVVM.ViewModel
{
    internal class HomeViewModel
    {
        public RelayCommand CloseWindowCommand { get; set; }
        
        public HomeViewModel()
        {
            CloseWindowCommand = new RelayCommand(o =>
            {
                if (o is IClosable window)
                    window.Close();
            });
        }
    }
}
