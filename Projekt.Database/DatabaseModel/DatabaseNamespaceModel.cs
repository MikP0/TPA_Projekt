using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.DatabaseModel 
{
    [Table("NamespaceModel")]
    public class DatabaseNamespaceModel
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        public List<DatabaseTypeModel> Types { get; set; }
    }
}
