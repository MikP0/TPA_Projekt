using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Model;
using Projekt.Model.Reflection;

namespace Projekt.UnitTest.ModelTest
{
    [TestClass]
    public class AssemblyMetadataTest
    {
        [TestMethod]
        public void TestDeserializationAndReflectionTypes()
        {
            AssemblyMetadata assemblyMetadata1;
            AssemblyMetadata assemblyMetadata2;
            string path1 = "C:\\Users\\mpopi\\source\\repos\\Projekt_v2\\Projekt.Data\\bin\\Debug\\test.xml";
            assemblyMetadata1 = Deserialize.XmlDeserialize<AssemblyMetadata>(path1);

            string path2 = "C:\\Users\\mpopi\\source\\repos\\Projekt_v2\\Projekt.Data\\bin\\Debug\\Projekt.Data.dll";
            assemblyMetadata2 = new AssemblyMetadata(Assembly.LoadFrom(path2));

            

            Assert.AreEqual(assemblyMetadata1.Namespaces[0].Types.Count, assemblyMetadata2.Namespaces[0].Types.Count);
        }
    }
}
