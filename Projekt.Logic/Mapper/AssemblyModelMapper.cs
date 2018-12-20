using Projekt.Model;
using Projekt.Model.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Logic.Mapper
{
    public class AssemblyModelMapper
    {
        public static AssemblyMetadata MapUp(AssemblyModel model)
        {
            AssemblyMetadata assemblyModel = new AssemblyMetadata();
            Type type = model.GetType();
            assemblyModel.Name = model.Name;
            PropertyInfo namespaceModelsProperty = type.GetProperty("NamespaceModels",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            List<NamespaceModel> namespaceModels = (List<NamespaceModel>)HelperClass.ConvertList(typeof(NamespaceModel), (IList)namespaceModelsProperty?.GetValue(model));
            if (namespaceModels != null)
                assemblyModel.Namespaces = namespaceModels.Select(n => new NamespaceModelMapper().MapUp(n)).ToList();
            return assemblyModel;
        }

        public static AssemblyModel MapDown(AssemblyMetadata model, Type assemblyModelType)
        {
            object assemblyModel = Activator.CreateInstance(assemblyModelType);
            PropertyInfo nameProperty = assemblyModelType.GetProperty("Name");
            PropertyInfo namespaceModelsProperty = assemblyModelType.GetProperty("NamespaceModels",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            nameProperty?.SetValue(assemblyModel, model.Name);
            namespaceModelsProperty?.SetValue(
                assemblyModel,
                HelperClass.ConvertList(namespaceModelsProperty.PropertyType.GetGenericArguments()[0],
                    model.Namespaces.Select(n => new NamespaceModelMapper().MapDown(n, namespaceModelsProperty.PropertyType.GetGenericArguments()[0])).ToList()));
            return (AssemblyModel)assemblyModel;
        }

    }
}
