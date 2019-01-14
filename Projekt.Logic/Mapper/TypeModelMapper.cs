using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Projekt.Logic.Model;
using Projekt.Model;

namespace Projekt.Logic.Mapper
{
    public class TypeModelMapper
    {
        public static Dictionary<string, TypeModel> BaseTypes = new Dictionary<string, TypeModel>();
        public static Dictionary<string, TypeMetadata> Types = new Dictionary<string, TypeMetadata>();

        public static TypeModel EmitBaseType(TypeMetadata model, Type type)
        {
            return new TypeModelMapper().MapDown(model, type);
        }

        public static TypeMetadata EmitType(TypeModel model)
        {
            return new TypeModelMapper().MapUp(model);
        }

        private void FillBaseType(TypeMetadata model, TypeModel typModel)
        {
            Type typeModelType = typModel.GetType();

            typeModelType.GetProperty("Name")?.SetValue(typModel, model.Name);
            typeModelType.GetProperty("IsExternal")?.SetValue(typModel, model.IsExternal);
            typeModelType.GetProperty("IsGeneric")?.SetValue(typModel, model.IsGeneric);
            typeModelType.GetProperty("Type")?.SetValue(typModel, model.Type);
            typeModelType.GetProperty("AssemblyName")?.SetValue(typModel, model.Name);
            typeModelType.GetProperty("Modifiers")?.SetValue(typModel, model.Modifiers ?? new TypeModifiers());

            if (model.BaseType != null)
            {
                typeModelType.GetProperty("BaseType",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    ?.SetValue(typModel, typeModelType.Cast(EmitBaseType(model.BaseType, typeModelType)));
            }

            if (model.DeclaringType != null)
            {
                typeModelType.GetProperty("DeclaringType",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    ?.SetValue(typModel, typeModelType.Cast(EmitBaseType(model.DeclaringType, typeModelType)));
            }

            if (model.NestedTypes != null)
            {
                PropertyInfo nestedTypesProperty = typeModelType.GetProperty("NestedTypes",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                nestedTypesProperty?.SetValue(typModel,
                    HelperClass.ConvertList(typeModelType,
                        model.NestedTypes?.Select(c => EmitBaseType(c, typeModelType)).ToList()));
            }

            if (model.GenericArguments != null)
            {
                PropertyInfo genericArgumentsProperty = typeModelType.GetProperty("GenericArguments",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                genericArgumentsProperty?.SetValue(typModel,
                    HelperClass.ConvertList(typeModelType,
                        model.GenericArguments?.Select(c => EmitBaseType(c, typeModelType)).ToList()));
            }

            if (model.ImplementedInterfaces != null)
            {
                PropertyInfo implementedInterfacesProperty = typeModelType.GetProperty("ImplementedInterfaces",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                implementedInterfacesProperty?.SetValue(typModel,
                    HelperClass.ConvertList(typeModelType,
                        model.ImplementedInterfaces?.Select(c => EmitBaseType(c, typeModelType)).ToList()));
            }

            if (model.Fields != null)
            {
                PropertyInfo fieldsProperty = typeModelType.GetProperty("Fields",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                fieldsProperty?.SetValue(typModel,
                    HelperClass.ConvertList(fieldsProperty.PropertyType.GetGenericArguments()[0],
                        model.Fields?.Select(c =>
                            new ParameterModelMapper().MapDown(c,
                                fieldsProperty?.PropertyType.GetGenericArguments()[0])).ToList()));
            }

            if (model.Methods != null)
            {
                PropertyInfo methodsProperty = typeModelType.GetProperty("Methods",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                methodsProperty?.SetValue(typModel,
                    HelperClass.ConvertList(methodsProperty.PropertyType.GetGenericArguments()[0],
                        model.Methods?.Select(m =>
                                new MethodModelMapper().MapDown(m,
                                    methodsProperty?.PropertyType.GetGenericArguments()[0]))
                            .ToList()));
            }

            if (model.Constructors != null)
            {
                PropertyInfo constructorsProperty = typeModelType.GetProperty("Constructors",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                constructorsProperty?.SetValue(typModel,
                    HelperClass.ConvertList(constructorsProperty.PropertyType.GetGenericArguments()[0],
                        model.Constructors?.Select(c =>
                            new MethodModelMapper().MapDown(c,
                                constructorsProperty?.PropertyType.GetGenericArguments()[0])).ToList()));
            }

            if (model.Properties != null)
            {
                PropertyInfo propertiesProperty = typeModelType.GetProperty("Properties",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                propertiesProperty?.SetValue(typModel,
                    HelperClass.ConvertList(propertiesProperty.PropertyType.GetGenericArguments()[0],
                        model.Properties?.Select(c =>
                            new PropertyModelMapper().MapDown(c,
                                propertiesProperty?.PropertyType.GetGenericArguments()[0])).ToList()));
            }
        }

        private void FillType(TypeModel model, TypeMetadata TypeMetadata)
        {
            TypeMetadata.Name = model.Name;
            TypeMetadata.IsExternal = model.IsExternal;
            TypeMetadata.IsGeneric = model.IsGeneric;
            TypeMetadata.Type = model.Type;
            TypeMetadata.Name = model.AssemblyName;
            TypeMetadata.Modifiers = model.Modifiers ?? new TypeModifiers();

            Type type = model.GetType();
            PropertyInfo baseTypeProperty = type.GetProperty("BaseType",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            TypeModel baseType = (TypeModel)baseTypeProperty?.GetValue(model);
            TypeMetadata.BaseType = EmitType(baseType);

            PropertyInfo declaringTypeProperty = type.GetProperty("DeclaringType",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            TypeModel declaringType = (TypeModel)declaringTypeProperty?.GetValue(model);
            TypeMetadata.DeclaringType = EmitType(declaringType);

            PropertyInfo nestedTypesProperty = type.GetProperty("NestedTypes",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (nestedTypesProperty?.GetValue(model) != null)
            {
                List<TypeModel> nestedTypes = (List<TypeModel>)HelperClass.ConvertList(typeof(TypeModel),
                    (IList)nestedTypesProperty?.GetValue(model));
                TypeMetadata.NestedTypes = nestedTypes?.Select(n => EmitType(n)).ToList();
            }

            PropertyInfo genericArgumentsProperty = type.GetProperty("GenericArguments",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (genericArgumentsProperty?.GetValue(model) != null)
            {
                List<TypeModel> genericArguments =
                    (List<TypeModel>)HelperClass.ConvertList(typeof(TypeModel),
                        (IList)genericArgumentsProperty?.GetValue(model));
                TypeMetadata.GenericArguments = genericArguments?.Select(g => EmitType(g)).ToList();
            }

            PropertyInfo implementedInterfacesProperty = type.GetProperty("ImplementedInterfaces",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (implementedInterfacesProperty?.GetValue(model) != null)
            {
                List<TypeModel> implementedInterfaces =
                    (List<TypeModel>)HelperClass.ConvertList(typeof(TypeModel),
                        (IList)implementedInterfacesProperty?.GetValue(model));
                TypeMetadata.ImplementedInterfaces =
                    implementedInterfaces?.Select(i => EmitType(i)).ToList();
            }

            PropertyInfo fieldsProperty = type.GetProperty("Fields",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (fieldsProperty?.GetValue(model) != null)
            {
                List<ParameterModel> fields =
                    (List<ParameterModel>)HelperClass.ConvertList(typeof(ParameterModel),
                        (IList)fieldsProperty?.GetValue(model));
                TypeMetadata.Fields = fields?.Select(g => new ParameterModelMapper().MapUp(g))
                    .ToList();
            }

            PropertyInfo methodsProperty = type.GetProperty("Methods",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (methodsProperty?.GetValue(model) != null)
            {
                List<MethodModel> methods = (List<MethodModel>)HelperClass.ConvertList(typeof(MethodModel),
                    (IList)methodsProperty?.GetValue(model));
                TypeMetadata.Methods = methods?.Select(c => new MethodModelMapper().MapUp(c)).ToList();
            }

            PropertyInfo constructorsProperty = type.GetProperty("Constructors",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (constructorsProperty?.GetValue(model) != null)
            {
                List<MethodModel> constructors =
                    (List<MethodModel>)HelperClass.ConvertList(typeof(MethodModel),
                        (IList)constructorsProperty?.GetValue(model));
                TypeMetadata.Constructors = constructors?.Select(c => new MethodModelMapper().MapUp(c))
                    .ToList();
            }

            PropertyInfo propertiesProperty = type.GetProperty("Properties",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (propertiesProperty?.GetValue(model) != null)
            {
                List<PropertyModel> properties =
                    (List<PropertyModel>)HelperClass.ConvertList(typeof(PropertyModel),
                        (IList)propertiesProperty?.GetValue(model));
                TypeMetadata.Properties = properties?.Select(g => new PropertyModelMapper().MapUp(g))
                    .ToList();
            }
        }


        #region IModelMapper

        public TypeMetadata MapUp(TypeModel model)
        {
            TypeMetadata TypeMetadata = new TypeMetadata();
            if (model == null)
                return null;

            if (!Types.ContainsKey(model.Name))
            {
                Types.Add(model.Name, TypeMetadata);
                FillType(model, TypeMetadata);
            }
            return Types[model.Name];

        }

        public TypeModel MapDown(TypeMetadata model, Type typeModelType)
        {

            object TypeMetadata = Activator.CreateInstance(typeModelType);
            if (model == null)
                return null;
            if (!BaseTypes.ContainsKey(model.Name))
            {
                BaseTypes.Add(model.Name, (TypeModel)TypeMetadata);
                FillBaseType(model, (TypeModel)TypeMetadata);
            }
            return BaseTypes[model.Name];
        }

        #endregion


    }
}
