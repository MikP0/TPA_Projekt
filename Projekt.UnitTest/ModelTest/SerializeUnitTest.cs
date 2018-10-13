using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Data;
using Projekt.Model;

namespace Projekt.UnitTest.ModelTest
{
    [TestClass]
    public class SerializeUnitTest
    {
        [TestMethod]
        public void TestASerialization()
        {
            A newA = new A("A", 1, null);
            string path = "file.xml";
            string content = "";
            Serialize.XmlSerialize<A>(newA, path);
            try
            {
                content = File.ReadAllText(path);
            }
            catch (Exception e) {
                Trace.WriteLine(e.Message);
            }
            StringAssert.Contains(content, "A");
            StringAssert.Contains(content, "1");
        }

        [TestMethod]
        public void TestBSerialization()
        {
            B newB = new B("B", 2, null);
            string path = "file.xml";
            Serialize.XmlSerialize<B>(newB, path);
            string content = "";
            try
            {
                content = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            StringAssert.Contains(content, "B");
            StringAssert.Contains(content, "2");
        }

        [TestMethod]
        public void TestCSerialization()
        {
            C newC = new C("A", 1, null);
            string path = "file.xml";
            string content = "";
            Serialize.XmlSerialize<C>(newC, path);
            try
            {
                content = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            StringAssert.Contains(content, "C");
            StringAssert.Contains(content, "3");
        }
    }
}
