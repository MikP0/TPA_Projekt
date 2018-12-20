using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Projekt.Model.UnitTest
{
    [TestClass]
    public class ReflectionExampleDLLUnitTest
    {
        private string PathToExampleDll;
        [TestInitialize()]
        public void Startup()
        {
            string testDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionDir = testDir.Substring(0, testDir.LastIndexOf("Projekt.Model.UnitTest"));
            PathToExampleDll = solutionDir + "Projekt.Example.dll";
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

            StringAssert.Contains("Projekt.Example.dll", reflector.AssemblyModel.Name);
            StringAssert.Contains("Projekt.Example.dll", reflector.AssemblyModel.ToString());
        }
    }
}
