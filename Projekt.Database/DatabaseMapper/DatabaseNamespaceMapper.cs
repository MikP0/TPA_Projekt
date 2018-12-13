using Projekt.Database.DatabaseModel;
using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Database.DatabaseMapper
{
    public class DatabaseNamespaceMapper
    {
        public NamespaceMetadata MapToUpper(DatabaseNamespaceModel model)
        {
            NamespaceMetadata namespaceModel = new NamespaceMetadata();
            namespaceModel.Name = model.Name;
            if (model.Types != null)
                namespaceModel.Types = model.Types.Select(n => DatabaseTypeMapper.EmitType((DatabaseTypeModel)n)).ToList();
            return namespaceModel;
        }
        public DatabaseNamespaceModel MapToLower(NamespaceMetadata model)
        {
            DatabaseNamespaceModel namespaceModel = new DatabaseNamespaceModel();
            namespaceModel.Name = model.Name;
            if (model.Types != null)
                namespaceModel.Types = model.Types.Select(t => new DatabaseTypeMapper().MapToLower(t)).ToList();
            return namespaceModel;
        }
    }
}
