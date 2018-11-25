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

            Assert.AreEqual(1, Compose.Instance.Container.GetExportedValues<WorkspaceViewModel>().Count());
            Assert.IsNotNull(Compose.Instance.Container.GetExportedValues<WorkspaceViewModel>());
            Assert.IsNotNull(Compose.Instance.Container.GetExportedValue<WorkspaceViewModel>());
        }
    }
}
