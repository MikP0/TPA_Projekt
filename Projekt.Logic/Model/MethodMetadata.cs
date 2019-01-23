using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Projekt.Model;
using Projekt.Model.Enums;

namespace Projekt.Logic.Model
{
    public class MethodMetadata
    {

        #region private
        //vars
        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public List<TypeMetadata> GenericArguments { get; set; }
        public MethodModifiers Modifiers { get; set; }
        public TypeMetadata ReturnType { get; set; }
        public bool Extension { get; set; }
        public List<ParameterMetadata> Parameters{ get; set; }
        //constructor
        public MethodMetadata()
        {

        }
        public MethodMetadata(MethodBase method)
        {
            Name = method.Name;
            GenericArguments = !method.IsGenericMethodDefinition ? null : TypeMetadata.EmitGenericArguments(method.GetGenericArguments()).ToList();
            ReturnType = EmitReturnType(method);
            Parameters = EmitParameters(method.GetParameters()).ToList();
            Modifiers = EmitModifiers(method);
            Extension = EmitExtension(method);
        }
        //methods

        internal static IEnumerable<MethodMetadata> EmitMethods(IEnumerable<MethodBase> methods)
        {
            return from MethodBase _currentMethod in methods
                   where _currentMethod.GetVisible()
                   select new MethodMetadata(_currentMethod);
        }

        private static IEnumerable<ParameterMetadata> EmitParameters(IEnumerable<ParameterInfo> parms)
        {
            return from parm in parms
                   select new ParameterMetadata(parm.Name, TypeMetadata.EmitReference(parm.ParameterType));
        }
        private static TypeMetadata EmitReturnType(MethodBase method)
        {
            MethodInfo methodInfo = method as MethodInfo;
            if (methodInfo == null)
                return null;
            TypeMetadata.StoreType(methodInfo.ReturnType);
            return TypeMetadata.EmitReference(methodInfo.ReturnType);
        }
        private static bool EmitExtension(MethodBase method)
        {
            return method.CustomAttributes.Where(x => x.AttributeType == typeof(ExtensionAttribute)).Count() == 1; //method.IsDefined(typeof(ExtensionAttribute), true);
        }
        private static MethodModifiers EmitModifiers(MethodBase method)
        {
            AccessLevel _access = AccessLevel.Private;
            if (method.IsPublic)
                _access = AccessLevel.Public;
            else if (method.IsFamily)
                _access = AccessLevel.Protected;
            else if (method.IsFamilyAndAssembly)
                _access = AccessLevel.ProtectedInternal;
            AbstractEnum _abstract = AbstractEnum.NotAbstract;
            if (method.IsAbstract)
                _abstract = AbstractEnum.Abstract;
            StaticEnum _static = StaticEnum.NotStatic;
            if (method.IsStatic)
                _static = StaticEnum.Static;
            VirtualEnum _virtual = VirtualEnum.NotVirtual;
            if (method.IsVirtual)
                _virtual = VirtualEnum.Virtual;

            return new MethodModifiers()
            {
                AbstractEnum = _abstract,
                StaticEnum = _static,
                VirtualEnum = _virtual,
                AccessLevel = _access
            };
        }
        public override string ToString()
        {
            string type = String.Empty;
            type += Modifiers.AccessLevel.ToString().ToLower() + " ";
            type += Modifiers.AbstractEnum == AbstractEnum.Abstract ? AbstractEnum.Abstract.ToString().ToLower() + " " : String.Empty;
            type += Modifiers.StaticEnum == StaticEnum.Static ? StaticEnum.Static.ToString().ToLower() + " " : String.Empty;
            type += Modifiers.VirtualEnum == VirtualEnum.Virtual ? VirtualEnum.Virtual.ToString().ToLower() + " " : String.Empty;
            type += ReturnType != null ? ReturnType.Name + " " : String.Empty;
            type += Name;
            type += Extension ? " :Extension method" : String.Empty;
            return type;
        }
        #endregion

    }
}
