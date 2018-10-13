using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Data;

namespace Projekt.UnitTest.DataTest
{
    [TestClass]
    public class CUnitTest
    {
        [TestMethod]
        public void TestCConstructor()
        {
            String _FieldString = "C1";
            int _FieldInt = 1;
            C c = new C(_FieldString, _FieldInt, null);
            Assert.AreEqual(c._FieldString, _FieldString);
            Assert.AreEqual(c._FieldInt, _FieldInt);
            Assert.IsNull(c._refToA);
        }

        [DataTestMethod]
        [DataRow("C1")]
        [DataRow("C2")]
        public void TestCFieldString(String FieldString)
        {
            C c = new C(" ", 1, null);
            c._FieldString = FieldString;
            Assert.AreEqual(c._FieldString, FieldString);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void TestCFieldInt(int FieldInt)
        {
            C c = new C("C1", 0, null);
            c._FieldInt = FieldInt;
            Assert.AreEqual(c._FieldInt, FieldInt);
        }

        [TestMethod]
        public void TestCToAReference()
        {
            C c = new C("C1", 0, null);
            A a = new A("A", 2, null);
            c._refToA = a;
            Assert.AreEqual(c._refToA, a);
        }

        [DataTestMethod]
        [DataRow("Kotlecik", 2)]
        [DataRow("Ziemniaczki", 3)]
        public void TestAToString(String text, int num)
        {
            C c = new C(text, num, null);
            Assert.IsTrue(c.ToString().Contains(text));
            Assert.IsTrue(c.ToString().Contains(num.ToString()));
        }
    }
}
