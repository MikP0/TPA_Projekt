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
    public class DatabaseAssemblyModel : IAssemblyModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public List<DatabaseNamespaceModel> NamespaceModels { get; set; }
    }
}
