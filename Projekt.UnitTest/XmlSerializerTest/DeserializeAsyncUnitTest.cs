using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.XmlSerializer;

namespace Projekt.UnitTest.XmlSerializerTest
{
    [TestClass]
    public class DeserializeAsyncUnitTest
    {
        [TestMethod]
        public void TestAsyncDeserialization()
        {
            XmlSerialize xmlSerialize = new XmlSerialize();
            xmlSerialize.SaveAsync(xmlSerialize, "plik.xml");

            XmlSerialize deserialized = xmlSerialize.ReadAsync<XmlSerialize>("plik.xml");

            Assert.IsNotNull(deserialized);
        }
        public void TestAsyncDeserializationContent()
        {
            XmlSerialize xmlSerialize = new XmlSerialize();
            xmlSerialize.SaveAsync(xmlSerialize, "plik.xml");

            var deserialized = xmlSerialize.ReadAsync<XmlSerialize>("plik.xml");

            Assert.AreEqual(xmlSerialize.GetHashCode(), deserialized.GetHashCode());
        }
    }
}
