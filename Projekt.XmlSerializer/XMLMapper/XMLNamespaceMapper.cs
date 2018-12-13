using Projekt.Model.Reflection;
using Projekt.XmlSerializer.XMLModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.XMLMapper
{
    public class XMLNamespaceMapper
    {
        public NamespaceMetadata MapToUpper(XMLNamespaceModel model)
        {
            NamespaceMetadata namespaceMetadata = new NamespaceMetadata();
            namespaceMetadata.Name = model.Name;
            if (model.Types != null)
                namespaceMetadata.Types = model.Types.Select(n => XMLTypeMapper.EmitType((XMLTypeModel)n)).ToList();
            return namespaceMetadata;
        }

        public XMLNamespaceModel MapToLower(NamespaceMetadata model)
        {
            XMLNamespaceModel namespaceModel = new XMLNamespaceModel();
            namespaceModel.Name = model.Name;
            if (model.Types != null)
                namespaceModel.Types = model.Types.Select(t => new XMLTypeMapper().MapToLower(t)).ToList();
            return namespaceModel;
        }
    }
}
