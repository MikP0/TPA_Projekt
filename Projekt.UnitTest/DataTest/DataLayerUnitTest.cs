using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Data;

namespace Projekt.UnitTest.DataTest
{
    [TestClass]
    public class DataLayerUnitTest
    {
        [TestMethod]
        public void TestDataLayerConstructor()
        {
            A a = new A("A1", 1, null);
            B b = new B("B1", 2, null);
            C c = new C("C1", 3, null);
            a._refToB = b;
            b._refToC = c;
            c._refToA = a;
            DataLayer dataLayer = new DataLayer(a, b, c);
            Assert.IsNotNull(dataLayer._A);
            Assert.IsNotNull(dataLayer._B);
            Assert.IsNotNull(dataLayer._C);
        }
    }
}
