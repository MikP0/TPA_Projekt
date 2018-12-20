using Projekt.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.Model
{
    [Table("MethodModel")]
    public class DatabaseMethodModel : MethodModel
    {
        public DatabaseMethodModel()
        {
            GenericArguments = new List<DatabaseTypeModel>();
            Parameters = new List<DatabaseParameterModel>();
            TypeConstructors = new List<DatabaseTypeModel>();
            TypeMethods = new List<DatabaseTypeModel>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public override string Name { get; set; }

        public override bool Extension { get; set; }
        public override MethodModifiers Modifiers { get; set; }
        public new DatabaseTypeModel ReturnType { get; set; }
        public new List<DatabaseTypeModel> GenericArguments { get; set; }
        public new List<DatabaseParameterModel> Parameters { get; set; }
        public virtual ICollection<DatabaseTypeModel> TypeConstructors { get; set; }
        public virtual ICollection<DatabaseTypeModel> TypeMethods { get; set; }
    }
}
