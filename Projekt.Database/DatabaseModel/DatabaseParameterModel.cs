using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.DatabaseModel
{
    [Table("ParameterModel")]
    public class DatabaseParameterModel
    {
        public DatabaseParameterModel()
        {
            MethodParameters = new HashSet<DatabaseMethodModel>();
            TypeFields = new HashSet<DatabaseTypeModel>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public DatabaseTypeModel Type { get; set; }
        public virtual ICollection<DatabaseMethodModel> MethodParameters { get; set; }
        public virtual ICollection<DatabaseTypeModel> TypeFields { get; set; }
    }
}
