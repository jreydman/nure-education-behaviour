using System.Windows;
using System.Windows.Input;

using CompanyMonitor.Utilities;
using CompanyMonitor.MVVM.ViewModel;

namespace CompanyMonitor
{
    public partial class MainWindow : Window, IClosable
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
