using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.XmlSerializer;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Projekt.UnitTest.XmlSerializerTest
{
    /*[TestClass]
    public class SerializeAsyncUnitTest
    {
        [TestMethod]
        public void TestAsyncSerialization()
        {
            Assembly assembly = Assembly.Load("Projekt.Model");
            XmlSerialize xmlSerialize = new XmlSerialize();
            string path = "file.xml";
            string content = "";

            xmlSerialize.SaveAsync(assembly, path);
            try
            {
                content = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            StringAssert.Contains(content, "Projekt.Model");
            StringAssert.Contains(content, "string");
        }
    }*/
}
