using Projekt.CommonInterfaces;
using Projekt.Model;
using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Database.DatabaseModel
{
    public class DatabaseTypeModel : IDatabaseMapper<TypeMetadata, DatabaseTypeModel>
    {
        private static readonly TypeDictionary typeDictionaryInstance = TypeDictionary.Instance;
        private static readonly DatabaseTypeDictionary databaseTypeDictionaryInstance = DatabaseTypeDictionary.Instance;

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
        public static DatabaseTypeModel EmitDatabaseType(TypeMetadata model)
        {
            return new DatabaseTypeModel().MapToLower(model);
        }

        public static TypeMetadata EmitType(DatabaseTypeModel model)
        {
            return new DatabaseTypeModel().MapToUpper(model);
        }
        private void FillDatabaseType(TypeMetadata model)
        {
            Name = model.Name;
            IsExternal = model.IsExternal;
            IsGeneric = model.IsGeneric;
            Type = model.Type;
            NamespaceName = model.NamespaceName;
            Modifiers = model.Modifiers ?? new Tuple4<AccessLevel, SealedEnum, AbstractEnum, StaticEnum>();

            BaseType = EmitDatabaseType(model.BaseType);
            DeclaringType = EmitDatabaseType(model.DeclaringType);

            NestedTypes = model.NestedTypes?.Select(c => EmitDatabaseType(c)).ToList();
            GenericArguments = model.GenericArguments?.Select(c => EmitDatabaseType(c)).ToList();
            ImplementedInterfaces = model.ImplementedInterfaces?.Select(c => EmitDatabaseType(c)).ToList();

            Fields = model.Fields?.Select(c => new DatabaseParameterModel().MapToLower(c)).ToList();
            Methods = model.Methods?.Select(m => new DatabaseMethodModel().MapToLower(m)).ToList();
            Constructors = model.Constructors?.Select(c => new DatabaseMethodModel().MapToLower(c)).ToList();
            Properties = model.Properties?.Select(c => new DatabasePropertyModel().MapToLower(c)).ToList();
        }
        private void FillType(DatabaseTypeModel model, TypeMetadata typeModel)
        {
            typeModel.Name = model.Name;
            typeModel.IsExternal = model.IsExternal;
            typeModel.IsGeneric = model.IsGeneric;
            typeModel.Type = model.Type;
            typeModel.NamespaceName = model.NamespaceName;
            typeModel.Modifiers = model.Modifiers ?? new Tuple4<AccessLevel, SealedEnum, AbstractEnum, StaticEnum>();

            typeModel.BaseType = EmitType(model.BaseType);
            typeModel.DeclaringType = EmitType(model.DeclaringType);

            typeModel.NestedTypes = model.NestedTypes?.Select(EmitType).ToList();
            typeModel.GenericArguments = model.GenericArguments?.Select(EmitType).ToList();
            typeModel.ImplementedInterfaces = model.ImplementedInterfaces?.Select(EmitType).ToList();

            typeModel.Fields = model.Fields?.Select(g => g.MapToUpper(g)).ToList();
            typeModel.Methods = model.Methods?.Select(c => c.MapToUpper(c)).ToList();
            typeModel.Constructors = model.Constructors?.Select(c => c.MapToUpper(c)).ToList();
            typeModel.Properties = model.Properties?.Select(g => g.MapToUpper(g)).ToList();
        }
        public TypeMetadata MapToUpper(DatabaseTypeModel model)
        {
            TypeMetadata typeMetadata = new TypeMetadata();
            if (model == null)
                return null;

            if (!typeDictionaryInstance.ContainsKey(model.Name))
            {
                typeDictionaryInstance.Add(model.Name, typeMetadata);
                FillType(model, typeMetadata);
            }
            return typeDictionaryInstance[model.Name];
        }
        public DatabaseTypeModel MapToLower(TypeMetadata model)
        {
            if (model == null)
                return null;
            if(!databaseTypeDictionaryInstance.ContainsKey(model.Name))
            {
                databaseTypeDictionaryInstance.Add(model.Name, this);
                FillDatabaseType(model);
            }
            return databaseTypeDictionaryInstance[model.Name];
        }
    }
}
