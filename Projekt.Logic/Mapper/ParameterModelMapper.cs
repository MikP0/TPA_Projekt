using Projekt.Model;
using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Logic.Mapper
{
    public class ParameterModelMapper
    {
        public ParameterMetadata MapUp(ParameterModel model)
        {
            ParameterMetadata ParameterMetadata = new ParameterMetadata();
            ParameterMetadata.Name = model.Name;
            Type type = model.GetType();
            PropertyInfo typeProperty = type.GetProperty("Type",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            TypeModel typeModel = (TypeModel)typeProperty?.GetValue(model);
            if (typeModel != null)
                ParameterMetadata.TypeMetadata = TypeModelMapper.EmitType(typeModel);
            return ParameterMetadata;
        }

        public ParameterModel MapDown(ParameterMetadata model, Type ParameterMetadataType)
        {
            object ParameterMetadata = Activator.CreateInstance(ParameterMetadataType);
            PropertyInfo nameProperty = ParameterMetadataType.GetProperty("Name");
            PropertyInfo typeProperty = ParameterMetadataType.GetProperty("Type",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            nameProperty?.SetValue(ParameterMetadata, model.Name);
            if (model.TypeMetadata != null)
                typeProperty?.SetValue(ParameterMetadata,
                    typeProperty.PropertyType.Cast(TypeModelMapper.EmitBaseType(model.TypeMetadata, typeProperty.PropertyType)));

            return (ParameterModel)ParameterMetadata;
        }


    }
}
