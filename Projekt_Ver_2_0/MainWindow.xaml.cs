using Projekt.CommonInterfaces;
using Projekt.IoC;
using Projekt.ViewModel;
using System.Windows;

namespace Projekt_Ver_2_0
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ServicesRegister.Get<WorkspaceViewModel>();
        }
    }
}
