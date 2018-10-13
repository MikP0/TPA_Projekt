using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Data;

namespace Projekt.UnitTest.DataTest
{
    [TestClass]
    public class BUnitTest
    {
        [TestMethod]
        public void TestBConstructor()
        {
            String _FieldString = "B1";
            int _FieldInt = 1;
            B b = new B(_FieldString, _FieldInt, null);
            Assert.AreEqual(b._FieldString, _FieldString);
            Assert.AreEqual(b._FieldInt, _FieldInt);
            Assert.IsNull(b._refToC);
        }

        [DataTestMethod]
        [DataRow("B1")]
        [DataRow("B2")]
        public void TestBFieldString(String FieldString)
        {
            B b = new B(" ", 1, null);
            b._FieldString = FieldString;
            Assert.AreEqual(b._FieldString, FieldString);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void TestBFieldInt(int FieldInt)
        {
            B b = new B("B1", 0, null);
            b._FieldInt = FieldInt;
            Assert.AreEqual(b._FieldInt, FieldInt);
        }

        [TestMethod]
        public void TestBToCReference()
        {
            B b = new B("B1", 0, null);
            C c = new C("C", 2, null);
            b._refToC = c;
            Assert.AreEqual(b._refToC, c);
        }

        [DataTestMethod]
        [DataRow("Kotlecik", 2)]
        [DataRow("Ziemniaczki", 3)]
        public void TestBToString(String text, int num)
        {
            B b = new B(text, num, null);
            Assert.IsTrue(b.ToString().Contains(text));
            Assert.IsTrue(b.ToString().Contains(num.ToString()));
        }
    }
}
