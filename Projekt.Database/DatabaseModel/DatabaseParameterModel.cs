using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Database.DatabaseModel
{
    public class DatabaseParameterModel : IDatabaseMapper<ParameterMetadata, DatabaseParameterModel>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public DatabaseTypeModel Type { get; set; }
        public virtual ICollection<DatabaseMethodModel> MethodParameters { get; set; }
        public virtual ICollection<DatabaseTypeModel> TypeFields { get; set; }

        public DatabaseParameterModel()
        {
            MethodParameters = new HashSet<DatabaseMethodModel>();
            TypeFields = new HashSet<DatabaseTypeModel>();
        }
        public ParameterMetadata MapToUpper(DatabaseParameterModel model)
        {
            ParameterMetadata parameterMetadata = new ParameterMetadata();
            parameterMetadata.Name = model.Name;
            parameterMetadata.TypeMetadata = DatabaseTypeModel.EmitType(model.Type);
            return parameterMetadata;
        }
        public DatabaseParameterModel MapToLower(ParameterMetadata model)
        {
            Name = model.Name;
            Type = DatabaseTypeModel.EmitDatabaseType(model.TypeMetadata);
            return this;
        }
    }
}
