using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Composition;
using Projekt.ViewModel;
using System.Linq;

namespace Projekt.UnitTest.CompositionTest
{
    [TestClass]
    public class CompositionTest
    {
        [TestMethod]
        public void TestWorkspaceViewModelExport()
        {
            Compose.Instance.Setup();
            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.*");
            Assert.IsNotNull(Compose.Instance.Container.GetExportedValue<WorkspaceViewModel>());
        }
    }
}
