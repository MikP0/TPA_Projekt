using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Composition;
using Projekt.ViewModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Projekt.UnitTest.CompositionTest
{
    [TestClass]
    public class CompositionTest
    {
        [TestMethod]
        public void TestAddLocalAssemblyToCatalog()
        {
            Compose.Instance.Setup();

            Compose.Instance.AddLocalAssemblyToCatalog("Projekt.*");

            Assert.IsTrue(Compose.Instance.Catalog.Catalogs.Count > 0);
        }
        [TestMethod]
        public void TestAddExternalAssemblyToCatalog()
        {
            Compose.Instance.Setup();
            string testDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Compose.Instance.AddExternalAssemblyToCatalog(testDir, "Projekt.*");

            Assert.IsTrue(Compose.Instance.Catalog.Catalogs.Count > 0);
        }
    }
}
