using Projekt.Database.Model;
using System.Data.Entity;

namespace Projekt.Database
{
    public class DatabaseContext : DbContext
    {
        private const string connectionString = @"Server=tcp:mikpo.database.windows.net,1433;Initial Catalog=TPADB;Persist Security Info=True;User ID=mikpo@mikpo.database.windows.net;Password=MikSzym123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
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
