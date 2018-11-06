using Ninject;
using Projekt.ViewModel;

namespace Projekt.IoC
{
    public static class ServicesRegister
    {
        // Kernel initialization
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }

        private static void BindViewModels()
        {
            Kernel.Bind<WorkspaceViewModel>().To<WorkspaceViewModel>();
        }
        // Get implementation for specified type
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
