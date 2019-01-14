using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Logic.Model;
using Projekt.Model;
using System.Reflection;

namespace Projekt.Logic.UnitTest
{
    [TestClass]
    public class ReflectionUnitTest
    {
        [TestMethod]
        public void ReflectionInitTest()
        {
            Assembly assembly = Assembly.Load("Projekt.Logic");
            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);
            Assert.IsNotNull(reflector);
        }
        [TestMethod]
        public void ReflectionAssemblyMetadataTest()
        {
            Assembly assembly = Assembly.Load("Projekt.Logic");
            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);
            StringAssert.Contains("Projekt.Logic.dll", reflector.AssemblyModel.Name);
            StringAssert.Contains("Projekt.Logic.dll", reflector.AssemblyModel.ToString());
        }
        [TestMethod]
        public void ReflectionNamespaceMetadataTest()
        {
            Assembly assembly = Assembly.Load("Projekt.Logic");
            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);
            Assert.IsNotNull(reflector.AssemblyModel.Namespaces);
        }
        [TestMethod]
        public void ReflectionTypeMetadataTest()
        {
            Assembly assembly = Assembly.Load("Projekt.Logic");
            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);
            Assert.IsNotNull(reflector.AssemblyModel);
            foreach (NamespaceMetadata namespaceMetadata in reflector.AssemblyModel.Namespaces)
            {
                foreach (TypeMetadata typeMetadata in namespaceMetadata.Types)
                {
                    Assert.IsNotNull(typeMetadata.Name);
                }
            }
        }
    }
}
