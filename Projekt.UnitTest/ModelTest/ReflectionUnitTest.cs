using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Model;
using Projekt.Model.Reflection;
namespace Projekt.UnitTest.ModelTest
{
    [TestClass]
    public class ReflectionUnitTest
    {
        [TestMethod]
        public void ReflectionInitTest()
        {
            Assembly assembly = Assembly.Load("Projekt.Model");
            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);
            Assert.IsNotNull(reflector);
        }
        [TestMethod]
        public void ReflectionAssemblyMetadataTest()
        {
            Assembly assembly = Assembly.Load("Projekt.Model");
            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);
            StringAssert.Contains("Projekt.Model.dll", reflector.AssemblyModel.Name);
            StringAssert.Contains("Projekt.Model.dll", reflector.AssemblyModel.ToString());
        }
        [TestMethod]
        public void ReflectionNamespaceMetadataTest()
        {
            Assembly assembly = Assembly.Load("Projekt.Model");
            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);
            Assert.IsNotNull(reflector.AssemblyModel.Namespaces);
        }
        [TestMethod]
        public void ReflectionTypeMetadataTest()
        {
            Assembly assembly = Assembly.Load("Projekt.Model");
            Reflector reflector = new Reflector();
            reflector.Reflect(assembly);
            Assert.IsNotNull(reflector.AssemblyModel);
            foreach (NamespaceMetadata namespaceMetadata in reflector.AssemblyModel.Namespaces)
            {
                foreach(TypeMetadata typeMetadata in namespaceMetadata.Types)
                {
                    Trace.WriteLine(typeMetadata.Name);
                    Assert.IsNotNull(typeMetadata.Name);
                }
            }
        }
        
    }
}