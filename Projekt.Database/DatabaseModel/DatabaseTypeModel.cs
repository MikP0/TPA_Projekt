using Projekt.Model;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Database.DatabaseModel
{
    [Table("TypeModel")]
    public class DatabaseTypeModel
    {
        public DatabaseTypeModel()
        {
            MethodGenericArguments = new HashSet<DatabaseMethodModel>();
            Constructors = new HashSet<DatabaseMethodModel>();
            Fields = new HashSet<DatabaseParameterModel>();
            TypeGenericArguments = new HashSet<DatabaseTypeModel>();
            GenericArguments = new HashSet<DatabaseTypeModel>();
            TypeImplementedInterfaces = new HashSet<DatabaseTypeModel>();
            ImplementedInterfaces = new HashSet<DatabaseTypeModel>();
            Methods = new HashSet<DatabaseMethodModel>();
            TypeNestedTypes = new HashSet<DatabaseTypeModel>();
            NestedTypes = new HashSet<DatabaseTypeModel>();
            Properties = new HashSet<DatabasePropertyModel>();
        }
        [Key, StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string NamespaceName { get; set; }
        public bool IsExternal { get; set; }
        public bool IsGeneric { get; set; }
        public DatabaseTypeModel BaseType { get; set; }
        public TypeEnum Type { get; set; }
        public DatabaseTypeModel DeclaringType { get; set; }
        public Tuple4<AccessLevel, SealedEnum, AbstractEnum, StaticEnum> Modifiers { get; set; }
        public int? NamespaceId { get; set; }
        public virtual ICollection<DatabaseMethodModel> Constructors { get; set; }

        public virtual ICollection<DatabaseParameterModel> Fields { get; set; }

        public virtual ICollection<DatabaseTypeModel> GenericArguments { get; set; }

        public virtual ICollection<DatabaseTypeModel> ImplementedInterfaces { get; set; }

        public virtual ICollection<DatabaseMethodModel> Methods { get; set; }

        public virtual ICollection<DatabaseTypeModel> NestedTypes { get; set; }

        public virtual ICollection<DatabasePropertyModel> Properties { get; set; }

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
