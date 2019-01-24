using System.ComponentModel.Composition;
using System.Windows;
using Projekt.ViewModel;
using Projekt.Composition;

namespace Projekt_Ver_2_0
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    { 
        private void On_Startup(object sender, StartupEventArgs e)
        {
            Compose.Instance.Setup();
            Compose.Instance.AddProjectAssemblyToCatalog("Projekt.Logic.dll");
            Compose.Instance.AddProjectAssemblyToCatalog(Projekt.ViewModel.Properties.Settings.Default.DatabaseModel);
            Compose.Instance.AddProjectAssemblyToCatalog(Projekt.ViewModel.Properties.Settings.Default.DatabaseService);
            Compose.Instance.AddProjectAssemblyToCatalog(Projekt.ViewModel.Properties.Settings.Default.LoggerService);
            Compose.Instance.Container.ComposeExportedValue<IOpenFilePathService>(new GraphicalOpenFilePathService());
            Compose.Instance.Container.ComposeExportedValue<ISaveFilePathService>(new GraphicalSaveFilePathService());
            Compose.Instance.AddProjectAssemblyToCatalog("Projekt.ViewModel.dll");
        }
    }
}
