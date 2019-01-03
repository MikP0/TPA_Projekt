using Projekt.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.Model
{
    [Table("PropertyModel")]
    public class DatabasePropertyModel : PropertyModel
    {
        public DatabasePropertyModel()
        {
            TypeProperties = new HashSet<DatabaseTypeModel>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public override string Name { get; set; }

        public new DatabaseTypeModel Type { get; set; }

        public virtual ICollection<DatabaseTypeModel> TypeProperties { get; set; }
    }
}
