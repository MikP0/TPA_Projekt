using System.ComponentModel.Composition;
using System.Windows;
using Projekt.CommonInterfaces;
using Projekt.Composition;
using Projekt.Model;
using Projekt.Reflection;

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
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.Reflection.dll");
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.Model.dll");
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.XmlSerializer.dll");
            Compose.Instance.Container.ComposeExportedValue<ILoggerService>(new CustomLogger());
            Compose.Instance.Container.ComposeExportedValue<IOpenFilePathService>(new GraphicalOpenFilePathService());
            Compose.Instance.Container.ComposeExportedValue<ISaveFilePathService>(new GraphicalSaveFilePathService());
        }
    }
}
