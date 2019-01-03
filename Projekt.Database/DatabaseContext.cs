using Projekt.Database.Model;
using System.Data.Entity;

namespace Projekt.Database
{
    public class DatabaseContext : DbContext
    {
        private const string connectionString = @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Projekt.Database.DatabaseContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        public DatabaseContext() : base(connectionString)
        {

        }
        public virtual DbSet<DatabaseAssemblyModel> AssemblyModel { get; set; }
        public virtual DbSet<DatabaseMethodModel> MethodModel { get; set; }
        public virtual DbSet<DatabaseNamespaceModel> NamespaceModel { get; set; }
        public virtual DbSet<DatabaseParameterModel> ParameterModel { get; set; }
        public virtual DbSet<DatabasePropertyModel> PropertyModel { get; set; }
        public virtual DbSet<DatabaseTypeModel> TypeModel { get; set; }
        public virtual DbSet<DatabaseLogModel> Log { get; set; }
    }
}
