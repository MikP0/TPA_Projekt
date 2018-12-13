using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.DatabaseModel
{
    [Table("PropertyModel")]
    public class DatabasePropertyModel
    {
        public DatabasePropertyModel()
        {
            TypeProperties = new HashSet<DatabaseTypeModel>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public DatabaseTypeModel Type { get; set; }

        public virtual ICollection<DatabaseTypeModel> TypeProperties { get; set; }
    }
}
