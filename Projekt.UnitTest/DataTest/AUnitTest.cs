using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Data;

namespace Projekt.UnitTest.DataTest
{
    [TestClass]
    public class AUnitTest
    {
        [TestMethod]
        public void TestAConstructor()
        {
            String _FieldString = "A1";
            int _FieldInt = 1;
            A a = new A(_FieldString, _FieldInt, null);
            Assert.AreEqual(a._FieldString, _FieldString);
            Assert.AreEqual(a._FieldInt, _FieldInt);
            Assert.IsNull(a._refToB);
        }

        [DataTestMethod]
        [DataRow("A1")]
        [DataRow("A2")]
        public void TestAFieldString(String FieldString)
        {
            A a = new A(" ", 1, null);
            a._FieldString = FieldString;
            Assert.AreEqual(a._FieldString, FieldString);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void TestAFieldInt(int FieldInt)
        {
            A a = new A("A1", 0, null);
            a._FieldInt = FieldInt;
            Assert.AreEqual(a._FieldInt, FieldInt);
        }

        [TestMethod]
        public void TestAToBReference()
        {
            A a = new A("A1", 0, null);
            B b = new B("B", 2, null);
            a._refToB = b;
            Assert.AreEqual(a._refToB, b);
        }

        [DataTestMethod]
        [DataRow("Kotlecik", 2)]
        [DataRow("Ziemniaczki", 3)]
        public void TestAToString(String text, int num)
        {
            A a = new A(text, num, null);
            Assert.IsTrue(a.ToString().Contains(text));
            Assert.IsTrue(a.ToString().Contains(num.ToString()));
        }
    }
}
