using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Database.DatabaseModel
{
    [Table("AssemblyModel")]
    public class DatabaseAssemblyModel : IDatabaseMapper<AssemblyMetadata, DatabaseAssemblyModel>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public List<DatabaseNamespaceModel> NamespaceModels { get; set; }

        public AssemblyMetadata MapToUpper(DatabaseAssemblyModel model)
        {
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata();
            assemblyMetadata.Name = model.Name;
            assemblyMetadata.Namespaces = model.NamespaceModels?.Select(t => new DatabaseNamespaceModel().MapToUpper(t)).ToList();
            return assemblyMetadata;
        }
        public DatabaseAssemblyModel MapToLower(AssemblyMetadata model)
        {
            Name = model.Name;
            NamespaceModels = model.Namespaces?.Select(t => new DatabaseNamespaceModel().MapToLower(t)).ToList();
            return this;
        }
    }
}
