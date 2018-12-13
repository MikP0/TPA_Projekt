using Projekt.CommonInterfaces;
using Projekt.Model;
using Projekt.Model.Reflection;
using Projekt.XmlSerializer.XMLModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.XMLMapper
{
    class XMLAssemblyMapper : IModelMapper
    {
        public IAssemblyModel MapToLower(AssemblyMetadata model)
        {
            throw new NotImplementedException();
        }

        public AssemblyMetadata MapToUpper(IAssemblyModel model)
        {
            AssemblyMetadata assemblyMetadata = new AssemblyMetadata();
            assemblyMetadata.Name = model.Name;
            if (((XMLAssemblyModel)model).NamespaceModels != null)
                assemblyMetadata.Namespaces = ((XMLAssemblyModel)model).NamespaceModels.Select(n => new XMLNamespaceMapper().MapToUpper(n)).ToList();
            return assemblyMetadata;
        }
    }
}
