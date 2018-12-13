using Projekt.CommonInterfaces;
using Projekt.Database.DatabaseModel;
using Projekt.Model;
using Projekt.Model.Reflection;
using System.ComponentModel.Composition;
using System.Linq;

namespace Projekt.Database.DatabaseMapper
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DatabaseAssemblyMapper : IModelMapper
    {
        public IAssemblyModel MapToLower(AssemblyMetadata model)
        {
            DatabaseAssemblyModel assemblyModel = new DatabaseAssemblyModel();
            assemblyModel.Name = model.Name;
            if (model.Namespaces != null)
                assemblyModel.NamespaceModels = model.Namespaces.Select(n => new DatabaseNamespaceMapper().MapToLower(n)).ToList();
            return assemblyModel;
        }

        public AssemblyMetadata MapToUpper(IAssemblyModel model)
        {
            AssemblyMetadata assemblyModel = new AssemblyMetadata();
            assemblyModel.Name = model.Name;
            if (((DatabaseAssemblyModel)model).NamespaceModels != null)
                assemblyModel.Namespaces = ((DatabaseAssemblyModel)model).NamespaceModels.Select(n => new DatabaseNamespaceMapper().MapToUpper(n)).ToList();
            return assemblyModel;
        }
    }
}
