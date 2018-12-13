using Microsoft.EntityFrameworkCore;
using Projekt.Database.DatabaseModel;

namespace Projekt.Database
{
    public class DatabaseContext : DbContext
    {
        private const string connectionString = @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Projekt.Database.DatabaseContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        public DatabaseContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
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
