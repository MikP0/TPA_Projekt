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
    public class NamespaceModelMapper
    {
        public NamespaceMetadata MapUp(NamespaceModel model)
        {

            NamespaceMetadata NamespaceMetadata = new NamespaceMetadata();
            NamespaceMetadata.Name = model.Name;
            Type type = model.GetType();
            PropertyInfo typesProperty = type.GetProperty("Types",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            List<TypeModel> types = (List<TypeModel>)HelperClass.ConvertList(typeof(TypeModel), (IList)typesProperty?.GetValue(model));
            if (types != null)
                NamespaceMetadata.Types = types.Select(n => TypeModelMapper.EmitType(n)).ToList();
            return NamespaceMetadata;
        }

        public NamespaceModel MapDown(NamespaceMetadata model, Type NamespaceMetadataType)
        {
            object NamespaceMetadata = Activator.CreateInstance(NamespaceMetadataType);
            PropertyInfo nameProperty = NamespaceMetadataType.GetProperty("Name");
            PropertyInfo NamespaceMetadatasProperty = NamespaceMetadataType.GetProperty("Types",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            nameProperty?.SetValue(NamespaceMetadata, model.Name);
            NamespaceMetadatasProperty?.SetValue(NamespaceMetadata,
                HelperClass.ConvertList(NamespaceMetadatasProperty.PropertyType.GetGenericArguments()[0],
                    model.Types.Select(t => new TypeModelMapper().MapDown(t, NamespaceMetadatasProperty.PropertyType.GetGenericArguments()[0])).ToList()));

            return (NamespaceModel)NamespaceMetadata;
        }
    }
}
