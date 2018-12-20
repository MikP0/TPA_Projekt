using Projekt.Model;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.Model
{
    [Table("TypeModel")]
    public class DatabaseTypeModel : TypeModel
    {
        public DatabaseTypeModel()
        {
            MethodGenericArguments = new HashSet<DatabaseMethodModel>();
            TypeGenericArguments = new HashSet<DatabaseTypeModel>();
            TypeImplementedInterfaces = new HashSet<DatabaseTypeModel>();
            TypeNestedTypes = new HashSet<DatabaseTypeModel>();
            Constructors = new List<DatabaseMethodModel>();
            Fields = new List<DatabaseParameterModel>();
            GenericArguments = new List<DatabaseTypeModel>();
            ImplementedInterfaces = new List<DatabaseTypeModel>();
            Methods = new List<DatabaseMethodModel>();
            NestedTypes = new List<DatabaseTypeModel>();
            Properties = new List<DatabasePropertyModel>();

        }
        [Key, StringLength(150)]
        public override string Name { get; set; }
        public override string AssemblyName { get; set; }
        public override bool IsExternal { get; set; }
        public override bool IsGeneric { get; set; }
        public new DatabaseTypeModel BaseType { get; set; }
        public override TypeEnum Type { get; set; }
        public new DatabaseTypeModel DeclaringType { get; set; }
        public override TypeModifiers Modifiers { get; set; }
        public int? NamespaceId { get; set; }
        public new List<DatabaseMethodModel> Constructors { get; set; }
        public new List<DatabaseParameterModel> Fields { get; set; }
        public new List<DatabaseTypeModel> GenericArguments { get; set; }
        public new List<DatabaseTypeModel> ImplementedInterfaces { get; set; }
        public new List<DatabaseMethodModel> Methods { get; set; }
        public new List<DatabaseTypeModel> NestedTypes { get; set; }
        public new List<DatabasePropertyModel> Properties { get; set; }

        [InverseProperty("BaseType")]
        public virtual ICollection<DatabaseTypeModel> TypeBaseTypes { get; set; }

        [InverseProperty("DeclaringType")]
        public virtual ICollection<DatabaseTypeModel> TypeDeclaringTypes { get; set; }

        public virtual ICollection<DatabaseMethodModel> MethodGenericArguments { get; set; }

        public virtual ICollection<DatabaseTypeModel> TypeGenericArguments { get; set; }

        public virtual ICollection<DatabaseTypeModel> TypeImplementedInterfaces { get; set; }

        public virtual ICollection<DatabaseTypeModel> TypeNestedTypes { get; set; }
    }
}
