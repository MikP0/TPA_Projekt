using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Projekt.Model;
using Projekt.Logic.Model;

namespace Projekt.Logic.Mapper
{
    public class MethodModelMapper
    {
        public MethodMetadata MapUp(MethodModel model)
        {
            MethodMetadata MethodMetadata = new MethodMetadata();
            MethodMetadata.Name = model.Name;
            MethodMetadata.Extension = model.Extension;
            Type type = model.GetType();
            PropertyInfo genericArgumentsProperty = type.GetProperty("GenericArguments",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (genericArgumentsProperty?.GetValue(model) != null)
            {
                List<TypeModel> genericArguments =
                    (List<TypeModel>)HelperClass.ConvertList(typeof(TypeModel),
                        (IList)genericArgumentsProperty?.GetValue(model));
                MethodMetadata.GenericArguments =
                    genericArguments.Select(g => TypeModelMapper.EmitType(g)).ToList();
            }

            MethodMetadata.Modifiers = model.Modifiers;

            PropertyInfo parametersProperty = type.GetProperty("Parameters",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (parametersProperty?.GetValue(model) != null)
            {
                List<ParameterModel> parameters =
                    (List<ParameterModel>)HelperClass.ConvertList(typeof(ParameterModel),
                        (IList)parametersProperty?.GetValue(model));

                MethodMetadata.Parameters = parameters
                    .Select(p => new ParameterModelMapper().MapUp(p)).ToList();
            }

            PropertyInfo returnTypeProperty = type.GetProperty("ReturnType",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            TypeModel returnType = (TypeModel)returnTypeProperty?.GetValue(model);
            if (returnType != null)
                MethodMetadata.ReturnType = TypeModelMapper.EmitType(returnType);
            return MethodMetadata;
        }

        public MethodModel MapDown(MethodMetadata model, Type MethodMetadataType)
        {
            object MethodMetadata = Activator.CreateInstance(MethodMetadataType);
            PropertyInfo nameProperty = MethodMetadataType.GetProperty("Name");
            PropertyInfo extensionProperty = MethodMetadataType.GetProperty("Extension");
            PropertyInfo genericArgumentsProperty = MethodMetadataType.GetProperty("GenericArguments",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            PropertyInfo modifiersProperty = MethodMetadataType.GetProperty("Modifiers");
            PropertyInfo parametersProperty = MethodMetadataType.GetProperty("Parameters",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            PropertyInfo returnTypeProperty = MethodMetadataType.GetProperty("ReturnType",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            nameProperty?.SetValue(MethodMetadata, model.Name);
            extensionProperty?.SetValue(MethodMetadata, model.Extension);
            if (model.GenericArguments != null)
                genericArgumentsProperty?.SetValue(MethodMetadata,
                    HelperClass.ConvertList(genericArgumentsProperty.PropertyType.GetGenericArguments()[0],
                        model.GenericArguments.Select(t => TypeModelMapper.EmitBaseType(t, genericArgumentsProperty.PropertyType.GetGenericArguments()[0])).ToList()));
            modifiersProperty?.SetValue(MethodMetadata, model.Modifiers);
            if (model.Parameters != null)
                parametersProperty?.SetValue(MethodMetadata,
                    HelperClass.ConvertList(parametersProperty.PropertyType.GetGenericArguments()[0],
                        model.Parameters.Select(p => new ParameterModelMapper().MapDown(p, parametersProperty.PropertyType.GetGenericArguments()[0])).ToList()));
            if (model.ReturnType != null)
                returnTypeProperty?.SetValue(MethodMetadata,
                    returnTypeProperty.PropertyType.Cast(TypeModelMapper.EmitBaseType(model.ReturnType, returnTypeProperty.PropertyType)));

            return (MethodModel)MethodMetadata;
        }
    }
}
