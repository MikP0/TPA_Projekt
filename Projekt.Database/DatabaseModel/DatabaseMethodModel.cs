using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.DatabaseModel
{
    [Table("MethodModel")]
    public class DatabaseMethodModel
    {
        public DatabaseMethodModel()
        {
            GenericArguments = new HashSet<DatabaseTypeModel>();
            Parameters = new HashSet<DatabaseParameterModel>();
            TypeConstructors = new HashSet<DatabaseTypeModel>();
            TypeMethods = new HashSet<DatabaseTypeModel>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public bool Extension { get; set; }
        public MethodModifiers Modifiers { get; set; }

        public virtual DatabaseTypeModel ReturnType { get; set; }
        public virtual ICollection<DatabaseTypeModel> GenericArguments { get; set; }
        public virtual ICollection<DatabaseParameterModel> Parameters { get; set; }
        public virtual ICollection<DatabaseTypeModel> TypeConstructors { get; set; }
        public virtual ICollection<DatabaseTypeModel> TypeMethods { get; set; }
    }
}
