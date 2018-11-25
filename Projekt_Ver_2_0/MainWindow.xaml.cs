using Projekt.CommonInterfaces;
using Projekt.Composition;
using Projekt.ViewModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;

namespace Projekt_Ver_2_0
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Compose.Instance.Container.GetExportedValue<WorkspaceViewModel>();
        }
    }
}
