using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Projekt.Logic.Model;
using Projekt.Model;

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

        public static AssemblyModel MapDown(AssemblyMetadata model, AssemblyModel assemblyModelType)
        {
            AssemblyModel assemblyModel = assemblyModelType;// Activator.CreateInstance(assemblyModelType);
            PropertyInfo nameProperty = assemblyModelType.GetType().GetProperty("Name");
            PropertyInfo namespaceModelsProperty = assemblyModelType.GetType().GetProperty("NamespaceModels",
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
