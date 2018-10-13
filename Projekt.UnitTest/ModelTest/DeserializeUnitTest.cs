using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Data;
using Projekt.Model;

namespace Projekt.UnitTest.ModelTest
{
    [TestClass]
    public class DeserializeUnitTest
    {
        [TestMethod]
        public void TestDeserialization()
        {
            A newA = new A("A", 1, null);
            Serialize.XmlSerialize<A>(newA, "plik.xml");

            A deserializedA = Deserialize.XmlDeserialize<A>("plik.xml");
            Assert.AreEqual(newA._FieldInt, deserializedA._FieldInt);
            Assert.AreEqual(newA._FieldString, deserializedA._FieldString);
            Assert.AreEqual(newA._refToB, deserializedA._refToB);
        }
    }
}
