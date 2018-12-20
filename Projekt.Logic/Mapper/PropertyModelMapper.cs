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
    public class PropertyModelMapper
    {
        public PropertyMetadata MapUp(PropertyModel model)
        {
            PropertyMetadata PropertyMetadata = new PropertyMetadata();
            PropertyMetadata.Name = model.Name;
            Type type = model.GetType();
            PropertyInfo typeProperty = type.GetProperty("Type",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            TypeModel typeModel = (TypeModel)typeProperty?.GetValue(model);

            if (typeModel != null)
                PropertyMetadata.Type = TypeModelMapper.EmitType(typeModel);

            return PropertyMetadata;
        }

        public PropertyModel MapDown(PropertyMetadata model, Type PropertyMetadataType)
        {
            object PropertyMetadata = Activator.CreateInstance(PropertyMetadataType);
            PropertyInfo nameProperty = PropertyMetadataType.GetProperty("Name");
            PropertyInfo typeProperty = PropertyMetadataType.GetProperty("Type",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            nameProperty?.SetValue(PropertyMetadata, model.Name);

            if (model.Type != null)
                typeProperty?.SetValue(PropertyMetadata,
                    typeProperty.PropertyType.Cast(TypeModelMapper.EmitBaseType(model.Type, typeProperty.PropertyType)));

            return (PropertyModel)PropertyMetadata;
        }


    }
}
