using System.ComponentModel.Composition;
using System.Windows;
using Projekt.CommonInterfaces;
using Projekt.Composition;
using Projekt.Model;

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
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.ViewModel.dll");
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.Logic.dll");
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.Model.dll");
            Compose.Instance.AddLocalAssemblyToCatalog(Projekt_Ver_2_0.Properties.Settings.Default.DatabaseService);
            Compose.Instance.AddLocalAssemblyToCatalog(Projekt_Ver_2_0.Properties.Settings.Default.DatabaseModel);
            Compose.Instance.AddLocalAssemblyToCatalog(Projekt_Ver_2_0.Properties.Settings.Default.LoggerService);
            Compose compose = Compose.Instance;
            Compose.Instance.Container.ComposeExportedValue<IOpenFilePathService>(new GraphicalOpenFilePathService());
            Compose.Instance.Container.ComposeExportedValue<ISaveFilePathService>(new GraphicalSaveFilePathService());
        }
    }
}
