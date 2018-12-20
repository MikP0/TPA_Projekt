using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Projekt.Database.UnitTest
{
    [TestClass]
    public class DatabaseModelUnitTest
    {
        /*private Reflector reflector { get; set; }
        private List<DatabaseAssemblyModel> assemblyMetadatas { get; set; }
        [TestInitialize]
        public void Setup()
        {
            string testDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionDir = testDir.Substring(0, testDir.LastIndexOf("Projekt.UnitTest"));
            string PathToExampleDll = solutionDir + "Projekt.Example.dll";
            assemblyMetadatas = new List<DatabaseAssemblyModel>();

            Assembly assembly = Assembly.LoadFile(PathToExampleDll);

            reflector = new Reflector();
            reflector.Reflect(assembly);

            DatabaseAssemblyModel databaseAssemblyModel = new DatabaseAssemblyModel();
            //databaseAssemblyModel = reflector.AssemblyModel;
            assemblyMetadatas.Add(databaseAssemblyModel);
        }
        [TestMethod]
        public void CheckDatabaseAssemblyModel()
        {
            Mock<DatabaseContext> mockContext = new Mock<DatabaseContext>();
            var assemblyMetadataDbSet = assemblyMetadatas.GetQueryableMockDbSet();

            foreach (var assemblyMetadata in assemblyMetadatas)
            {
                assemblyMetadataDbSet.Add(assemblyMetadata);
            }

            mockContext.Setup(context => context.AssemblyModel).Returns(assemblyMetadataDbSet);

            var dbContext = mockContext.Object;
            var assemblyData = dbContext.AssemblyModel;

            Assert.AreEqual(1, assemblyData.Count());
        }*/
    }
}
