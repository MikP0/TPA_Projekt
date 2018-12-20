using Projekt.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.Model 
{
    [Table("NamespaceModel")]
    public class DatabaseNamespaceModel : NamespaceModel
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public override string Name { get; set; }
        public new List<DatabaseTypeModel> Types { get; set; }
    }
}
