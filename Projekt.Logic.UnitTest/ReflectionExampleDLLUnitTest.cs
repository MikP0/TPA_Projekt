using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Model;

namespace Projekt.Logic.UnitTest
{
    [TestClass]
    public class ReflectionExampleDLLUnitTest
    {
        private string PathToExampleDll;
        [TestInitialize()]
        public void Startup()
        {
            string testDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionDir = testDir.Substring(0, testDir.LastIndexOf("Projekt.Logic.UnitTest"));
            PathToExampleDll = solutionDir + "Projekt.TestDLL\\TPA.ApplicationArchitecture.dll";
        }
        [TestMethod]
        public void ReadExampleDLL()
        {
            Assembly assembly = Assembly.LoadFile(PathToExampleDll);

            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);

            Assert.IsNotNull(reflector);
        }
        [TestMethod]
        public void AssemblyMetadataTest()
        {
            Assembly assembly = Assembly.LoadFile(PathToExampleDll);

            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);

            StringAssert.Contains("TPA.ApplicationArchitecture.dll", reflector.AssemblyModel.Name);
        }
    }
}
