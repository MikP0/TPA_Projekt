using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Database.Model;
using Moq;
using Projekt.Logic.Mapper;
using System.Linq;
using Projekt.Logic.Model;
using Projekt.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Projekt.Database.UnitTest
{
    [TestClass]
    public class DatabaseModelUnitTest
    {
        private List<DatabaseAssemblyModel> assemblyMetadatas { get; set; }
        [TestInitialize]
        public void Setup()
        {
            assemblyMetadatas = new List<DatabaseAssemblyModel>();
            string testDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionDir = testDir.Substring(0, testDir.LastIndexOf("Projekt.Database.UnitTest"));
            string PathToExampleDll = solutionDir + "Projekt.TestDLL\\TPA.ApplicationArchitecture.dll";

            DatabaseService databaseService = new DatabaseService();
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata(Assembly.ReflectionOnlyLoadFrom(PathToExampleDll));

            DatabaseAssemblyModel databaseAssemblyModel = new DatabaseAssemblyModel();
            AssemblyModel model = AssemblyModelMapper.MapDown(assemblyMetadata, databaseAssemblyModel);
            assemblyMetadatas.Add(databaseAssemblyModel);
        }
        [TestMethod]
        public void CheckDatabaseAssemblyModel()
        {
            Mock<DatabaseContext> mockContext = new Mock<DatabaseContext>();
            var assemblyMetadataDbSet = assemblyMetadatas.GetQueryableMockDbSet();

            foreach (DatabaseAssemblyModel assemblyMetadata in assemblyMetadatas)
            {
                assemblyMetadataDbSet.Add(assemblyMetadata);
            }

            mockContext.Setup(context => context.AssemblyModel).Returns(assemblyMetadataDbSet);

            DatabaseContext dbContext = mockContext.Object;
            DbSet<DatabaseAssemblyModel> assemblyData = dbContext.AssemblyModel;

            Assert.AreEqual(1, assemblyData.Count());
        }
    }
}
