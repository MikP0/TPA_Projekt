using System;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Model;

namespace Projekt.UnitTest.ModelTest
{
    [TestClass]
    public class DeserializeUnitTest
    {
        [TestMethod]
        public void TestDeserialization()
        {
            XmlSerialize xmlSerialize = new XmlSerialize();
            xmlSerialize.Serialize(xmlSerialize, "plik.xml");

            XmlSerialize deserialized = xmlSerialize.Deserialize<XmlSerialize>("plik.xml");

            Assert.IsNotNull(deserialized);
        }
        public void TestDeserializationContent()
        {
            XmlSerialize xmlSerialize = new XmlSerialize();
            xmlSerialize.Serialize(xmlSerialize, "plik.xml");

            XmlSerialize deserialized = xmlSerialize.Deserialize<XmlSerialize>("plik.xml");

            Assert.AreEqual(xmlSerialize.GetHashCode(), deserialized.GetHashCode());
        }
    }
}
