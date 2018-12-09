using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Database.DatabaseModel;
using Projekt.Model;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Projekt.UnitTest.DatabaseTest
{
    [TestClass]
    public class DatabaseCreationUnitTest
    {
        private Reflector reflector { get; set; }
        [TestInitialize]
        public void Setup()
        {
            string testDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionDir = testDir.Substring(0, testDir.LastIndexOf("Projekt.UnitTest"));
            string PathToExampleDll = solutionDir + "Projekt.Example.dll";

            Assembly assembly = Assembly.LoadFile(PathToExampleDll);

            reflector = new Reflector();
            reflector.Reflect(assembly);
        }
        [TestMethod]
        public void CreateDatabaseAssemblyModel()
        {
            DatabaseAssemblyModel databaseAssemblyModel = new DatabaseAssemblyModel().MapToLower(reflector.AssemblyModel);

            Assert.IsNotNull(databaseAssemblyModel.Id);
            Assert.IsNotNull(databaseAssemblyModel.Name);
            Assert.IsNotNull(databaseAssemblyModel.NamespaceModels);
        }
        [TestMethod]
        public void CreateDatabaseNamespaceModel()
        {
            DatabaseNamespaceModel databaseNamespaceModel = new DatabaseNamespaceModel().MapToLower(reflector.AssemblyModel.Namespaces.FirstOrDefault());

            Assert.IsNotNull(databaseNamespaceModel.Id);
            Assert.IsNotNull(databaseNamespaceModel.Name);
            Assert.IsNotNull(databaseNamespaceModel.Types);
        }
        [TestMethod]
        public void CreateDatabaseTypeModel()
        {
            DatabaseTypeModel databaseTypeModel = new DatabaseTypeModel().MapToLower(reflector.AssemblyModel.Namespaces.FirstOrDefault().Types.FirstOrDefault());

            Assert.IsNotNull(databaseTypeModel.Constructors);
            Assert.IsNotNull(databaseTypeModel.Fields);
            Assert.IsNotNull(databaseTypeModel.Name);
            Assert.IsNotNull(databaseTypeModel.Type);
        }
        [TestMethod]
        public void CreateDatabaseMethodModel()
        {
            DatabaseMethodModel databaseMethodModel = new DatabaseMethodModel().MapToLower(reflector.AssemblyModel.Namespaces.FirstOrDefault().Types.FirstOrDefault().Methods.FirstOrDefault());

            Assert.IsNotNull(databaseMethodModel.Id);
            Assert.IsNotNull(databaseMethodModel.Name);
            Assert.IsNotNull(databaseMethodModel.Parameters);
            Assert.IsNotNull(databaseMethodModel.ReturnType);
        }
        [TestMethod]
        public void CreateDatabasePropertyModel()
        {
            DatabasePropertyModel databasePropertyModel = new DatabasePropertyModel().MapToLower(reflector.AssemblyModel.Namespaces.FirstOrDefault().Types.FirstOrDefault().Properties.FirstOrDefault());

            Assert.IsNotNull(databasePropertyModel.Id);
            Assert.IsNotNull(databasePropertyModel.Name);
            Assert.IsNotNull(databasePropertyModel.Type);
            Assert.IsNotNull(databasePropertyModel.TypeProperties);
        }
    }
}
