using Projekt.CommonInterfaces;
using Projekt.IoC;
using System.Windows;

namespace Projekt_Ver_2_0
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    { 
        private void On_Startup(object sender, StartupEventArgs e)
        {
            ServicesRegister.Setup();
            ServicesRegister.Kernel.Bind<IOpenFilePathService>().ToConstant(new GraphicalOpenFilePathService());
            ServicesRegister.Kernel.Bind<ISaveFilePathService>().ToConstant(new GraphicalSaveFilePathService());
        }
    }
}
