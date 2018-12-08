using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Projekt.Database.DatabaseModel 
{
    public class DatabaseNamespaceModel : IDatabaseMapper<NamespaceMetadata, DatabaseNamespaceModel>
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        public List<DatabaseTypeModel> Types { get; set; }
        public NamespaceMetadata MapToUpper(DatabaseNamespaceModel model)
        {
            NamespaceMetadata namespaceMetadata = new NamespaceMetadata();
            namespaceMetadata.Name = model.Name;
            namespaceMetadata.Types = model.Types?.Select(c => DatabaseTypeModel.EmitType(c)).ToList();
            return namespaceMetadata;
        }

        public DatabaseNamespaceModel MapToLower(NamespaceMetadata model)
        {
            Name = model.Name;
            Types = model.Types?.Select(t => new DatabaseTypeModel().MapToLower(t)).ToList();
            return this;
        }
    }
}
