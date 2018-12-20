using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Projekt.Composition.UnitTest
{
    [TestClass]
    public class ComposeTest
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
