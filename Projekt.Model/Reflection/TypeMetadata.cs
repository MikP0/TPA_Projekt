﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Reflection
{
    [DataContract]
    public class TypeMetadata
    {
        #region fields
        [DataMember]
        private static readonly TypeDictionary dictionaryInstance = TypeDictionary.Instance; 
        [DataMember]
        public string NamespaceName { get; set; }
        [DataMember]
        public TypeMetadata BaseType { get; set; }
        [DataMember]
        public List<TypeMetadata> GenericArguments { get; set; }
        [DataMember]
        public Tuple4<AccessLevel, SealedEnum, AbstractEnum, StaticEnum> Modifiers { get; set; }
        [DataMember]
        public bool IsGeneric { get; set; }
        [DataMember]
        public bool IsExternal { get; set; } = true;
        [DataMember]
        public TypeEnum Type { get; set; }
        [DataMember]
        public List<Attribute> Attributes;
        [DataMember]
        public List<TypeMetadata> ImplementedInterfaces { get; set; }
        [DataMember]
        public List<TypeMetadata> NestedTypes { get; set; }
        [DataMember]
        public List<PropertyMetadata> Properties { get; set; }
        [DataMember]
        public TypeMetadata DeclaringType { get; set; }
        [DataMember]
        public List<MethodMetadata> Methods { get; set; }
        [DataMember]
        public List<MethodMetadata> Constructors { get; set; }
        [DataMember]
        public List<ParameterMetadata> Fields { get; set; }

        #endregion


        #region constructors

        public TypeMetadata()
        {

        }

        public TypeMetadata(string typeName, string namespaceName)
        {
            Name = typeName;
            NamespaceName = namespaceName;
        }

        private TypeMetadata(string typeName, string namespaceName, IEnumerable<TypeMetadata> genericArguments) : this(typeName, namespaceName)
        {
            GenericArguments = genericArguments.ToList();
        }

        public TypeMetadata(Type type)
        {
            Name = type.Name;

            CreateDictionary();

            DeclaringType = EmitDeclaringType(type.DeclaringType);
            Constructors = MethodMetadata.EmitMethods(type.GetConstructors()).ToList();
            Methods = MethodMetadata.EmitMethods(type.GetMethods()).ToList();
            NestedTypes = EmitNestedTypes(type.GetNestedTypes()).ToList();
            ImplementedInterfaces = EmitImplements(type.GetInterfaces()).ToList();
            GenericArguments = !type.IsGenericTypeDefinition ? null : TypeMetadata.EmitGenericArguments(type.GetGenericArguments()).ToList();
            Modifiers = EmitModifiers(type);
            BaseType = EmitExtends(type.BaseType);
            Properties = PropertyMetadata.EmitProperties(type.GetProperties()).ToList();
            Type = GetTypeKind(type);
            //m_Attributes = type.GetCustomAttributes(false).Cast<Attribute>().ToList();
            Fields = EmitFields(type.GetFields()).ToList();
        }

        #endregion

        #region internals
        //vars
        [DataMember]
        private string m_typeName;
        [DataMember]
        public string Name
        {
            get { return m_typeName; }
            set { m_typeName = value; }
        }
        #endregion


        #region methods

        public static void StoreType(Type type)
        {
            if (!dictionaryInstance.ContainsKey(type.Name))
            {
                new TypeMetadata(type);
            }
        }

        public static TypeMetadata EmitReference(Type type)
        {
            if (!type.IsGenericType)
                return new TypeMetadata(type.Name, type.GetNamespace());
            else
                return new TypeMetadata(type.Name, type.GetNamespace(), EmitGenericArguments(type.GetGenericArguments()));
        }

        public static IEnumerable<TypeMetadata> EmitGenericArguments(IEnumerable<Type> arguments)
        {
            foreach (Type type in arguments)
            {
                StoreType(type);
            }
            return from Type _argument in arguments select EmitReference(_argument);
        }

        private static IEnumerable<ParameterMetadata> EmitFields(IEnumerable<FieldInfo> fieldInfo)
        {
            List<ParameterMetadata> parameters = new List<ParameterMetadata>();
            foreach (FieldInfo field in fieldInfo)
            {
                StoreType(field.FieldType);
                parameters.Add(new ParameterMetadata(field.Name, TypeMetadata.EmitReference(field.FieldType)));
            }
            return parameters;
        }

        private TypeMetadata EmitDeclaringType(Type declaringType)
        {
            if (declaringType == null)
                return null;
            StoreType(declaringType);
            return EmitReference(declaringType);
        }

        private IEnumerable<TypeMetadata> EmitNestedTypes(IEnumerable<Type> nestedTypes)
        {
            foreach (Type type in nestedTypes)
            {
                StoreType(type);
            }

            return from _type in nestedTypes
                   where _type.GetVisible()
                   select new TypeMetadata(_type);
        }
        private IEnumerable<TypeMetadata> EmitImplements(IEnumerable<Type> interfaces)
        {
            foreach (Type @interface in interfaces)
            {
                StoreType(@interface);
            }

            return from currentInterface in interfaces
                   select EmitReference(currentInterface);
        }

        private static TypeEnum GetTypeKind(Type type)
        {
            return type.IsEnum ? TypeEnum.Enum :
                   type.IsValueType ? TypeEnum.Struct :
                   type.IsInterface ? TypeEnum.Interface :
                   TypeEnum.Class;
        }

        static Tuple4<AccessLevel, SealedEnum, AbstractEnum, StaticEnum> EmitModifiers(Type type)
        {
            AccessLevel _access = AccessLevel.Private;
            if (type.IsPublic)
                _access = AccessLevel.Public;
            else if (type.IsNestedPublic)
                _access = AccessLevel.Public;
            else if (type.IsNestedFamily)
                _access = AccessLevel.Protected;
            else if (type.IsNestedFamANDAssem)
                _access = AccessLevel.ProtectedInternal;
            SealedEnum _sealed = SealedEnum.NotSealed;
            if (type.IsSealed) _sealed = SealedEnum.Sealed;
            AbstractEnum _abstract = AbstractEnum.NotAbstract;
            StaticEnum _static = StaticEnum.NotStatic;
            if (type.IsAbstract) {
                _abstract = AbstractEnum.Abstract;
                _static = StaticEnum.Static;
            }
                
            return new Tuple<AccessLevel, SealedEnum, AbstractEnum, StaticEnum>(_access, _sealed, _abstract, _static);
        }

        private static TypeMetadata EmitExtends(Type baseType)
        {
            if (baseType == null || baseType == typeof(Object) || baseType == typeof(ValueType) || baseType == typeof(Enum))
                return null;
            StoreType(baseType);
            return EmitReference(baseType);
        }

        public void CreateDictionary()
        {
            if (dictionaryInstance.ContainsKey(Name) == false)
            {
                dictionaryInstance.Add(Name, this);
            }
        }
        #endregion

    }
}
