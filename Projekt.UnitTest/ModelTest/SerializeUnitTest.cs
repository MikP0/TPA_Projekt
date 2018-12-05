using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.XmlSerializer;

namespace Projekt.UnitTest.ModelTest
{
    [TestClass]
    public class SerializeUnitTest
    {
        [TestMethod]
        public void TestSerialization()
        {
            Assembly assembly = Assembly.Load("Projekt.Model");
            XmlSerialize xmlSerialize = new XmlSerialize();
            string path = "file.xml";
            string content = "";

            xmlSerialize.Save(assembly, path);
            try
            {
                content = File.ReadAllText(path);
            }
            catch (Exception e) {
                Trace.WriteLine(e.Message);
            }

            StringAssert.Contains(content, "Projekt.Model");
            StringAssert.Contains(content, "string");
        }

    }
}
