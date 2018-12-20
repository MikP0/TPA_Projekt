using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.Database;

namespace Projekt.Database.UnitTest
{
    [TestClass]
    public class DatabaseUnitTest
    {
        [TestMethod]
        public void Create()
        {
            DatabaseService databaseService = new DatabaseService();

            Assert.IsNotNull(databaseService);
        }
    }
}
