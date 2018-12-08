using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Projekt.Database.DatabaseModel
{
    public class DatabaseMethodModel : IDatabaseMapper<MethodMetadata, DatabaseMethodModel>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public bool Extension { get; set; }
        public Tuple4<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum> Modifiers { get; set; }

        public virtual DatabaseTypeModel ReturnType { get; set; }
        public virtual ICollection<DatabaseTypeModel> GenericArguments { get; set; }
        public virtual ICollection<DatabaseParameterModel> Parameters { get; set; }
        public virtual ICollection<DatabaseTypeModel> TypeConstructors { get; set; }
        public virtual ICollection<DatabaseTypeModel> TypeMethods { get; set; }
        public DatabaseMethodModel()
        {
            GenericArguments = new HashSet<DatabaseTypeModel>();
            Parameters = new HashSet<DatabaseParameterModel>();
            TypeConstructors = new HashSet<DatabaseTypeModel>();
            TypeMethods = new HashSet<DatabaseTypeModel>();
        }

        public MethodMetadata MapToUpper(DatabaseMethodModel model)
        {
            MethodMetadata methodMetadata = new MethodMetadata();
            methodMetadata.Name = model.Name;
            methodMetadata.Extension = model.Extension;
            methodMetadata.GenericArguments = model.GenericArguments?.Select(c => DatabaseTypeModel.EmitType(c)).ToList();
            methodMetadata.Modifiers = model.Modifiers ?? new Tuple4<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>();
            methodMetadata.Parameters = model.Parameters?.Select(p => p.MapToUpper(p)).ToList();
            methodMetadata.ReturnType = DatabaseTypeModel.EmitType(model.ReturnType);
            return methodMetadata;
        }

        public DatabaseMethodModel MapToLower(MethodMetadata model)
        {
            Name = model.Name;
            Extension = model.Extension;
            GenericArguments = model.GenericArguments?.Select(c => DatabaseTypeModel.EmitDatabaseType(c)).ToList();
            Modifiers = model.Modifiers ?? new Tuple4<AccessLevel, AbstractEnum, StaticEnum, VirtualEnum>();
            Parameters = model.Parameters?.Select(p => new DatabaseParameterModel().MapToLower(p)).ToList();
            ReturnType = DatabaseTypeModel.EmitDatabaseType(model.ReturnType);
            return this;
        }
    }
}
