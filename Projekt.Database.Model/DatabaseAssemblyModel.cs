using Projekt.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.Model
{
    [Table("AssemblyModel")]
    public class DatabaseAssemblyModel : AssemblyModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public override string Name { get; set; }
        public new List<DatabaseNamespaceModel> NamespaceModels { get; set; }
    }
}
