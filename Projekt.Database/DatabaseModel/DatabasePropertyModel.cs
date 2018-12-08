using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Database.DatabaseModel
{
    public class DatabasePropertyModel : IDatabaseMapper<PropertyMetadata, DatabasePropertyModel>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public DatabaseTypeModel Type { get; set; }

        public virtual ICollection<DatabaseTypeModel> TypeProperties { get; set; }
        public DatabasePropertyModel()
        {
            TypeProperties = new HashSet<DatabaseTypeModel>();
        }
        public PropertyMetadata MapToUpper(DatabasePropertyModel model)
        {
            PropertyMetadata propertyMetadata = new PropertyMetadata();
            propertyMetadata.Name = model.Name;
            propertyMetadata.Type = DatabaseTypeModel.EmitType(model.Type);
            return propertyMetadata;
        }
        public DatabasePropertyModel MapToLower(PropertyMetadata model)
        {
            Name = model.Name;
            Type = DatabaseTypeModel.EmitDatabaseType(model.Type);
            return this;
        }
    }
}
