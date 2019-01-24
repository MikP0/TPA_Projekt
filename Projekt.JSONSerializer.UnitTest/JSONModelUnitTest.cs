using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.JSONSerializer.Model;
using Projekt.Logic.Mapper;
using Projekt.Logic.Model;
using Projekt.Model;

namespace Projekt.JSONSerializer.UnitTest
{
    [TestClass]
    public class JSONModelUnitTest
    {
        private AssemblyModel assemblyModel;

        [TestInitialize]
        public void Setup()
        {
            string testDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionDir = testDir.Substring(0, testDir.LastIndexOf("Projekt.JSONSerializer.UnitTest"));
            string PathToExampleDll = solutionDir + "Projekt.TestDLL\\TPA.ApplicationArchitecture.dll";

            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(Assembly.ReflectionOnlyLoadFrom(PathToExampleDll));

            JSONAssemblyModel jsonAssemblyModel = new JSONAssemblyModel();
            assemblyModel = AssemblyModelMapper.MapDown(assemblyMetadata, jsonAssemblyModel);
        }

        [TestMethod]
        public void CheckJSONAssemblyModel()
        {
            JSONSerialize jsonSerialize = new JSONSerialize();

            if (File.Exists(JSONSerializer.Properties.Settings.Default.SaveFileName))
            {
                File.Delete(JSONSerializer.Properties.Settings.Default.SaveFileName);
            }

            jsonSerialize.Save(assemblyModel);
            AssemblyModel newAssemblyModel = jsonSerialize.Read();

            Assert.IsTrue(newAssemblyModel.Name.Equals(assemblyModel.Name));
        }
    }
}
