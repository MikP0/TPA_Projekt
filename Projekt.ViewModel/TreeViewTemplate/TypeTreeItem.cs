using System;
using System.Collections.ObjectModel;
using Projekt.Model;
using Projekt.Model.Reflection;

namespace Projekt.ViewModel
{
    public class TypeTreeItem : TreeViewItem
    {
        public TypeMetadata TypeData { get; set; }
        public TypeTreeItem(TypeMetadata typeModel)
        {
            TypeData = typeModel;
        }

        protected override void BuildTreeView(ObservableCollection<TreeViewItem> children)
        {
            if (TypeData.BaseType != null)
            {
                children.Add(new TypeTreeItem(TypeData.BaseType));
            }
            if (TypeData.DeclaringType != null)
            {
                children.Add(new TypeTreeItem(TypeData.DeclaringType));
            }
            if (TypeData.Properties != null)
            {
                foreach (PropertyMetadata propertyModel in TypeData.Properties)
                {
                    children.Add(new PropertyTreeItem(propertyModel));
                }
            }
            if (TypeData.Fields != null)
            {
                foreach (ParameterMetadata parameterModel in TypeData.Fields)
                {
                    children.Add(new ParameterTreeItem(parameterModel));
                }
            }
            if (TypeData.GenericArguments != null)
            {
                foreach (TypeMetadata typeModel in TypeData.GenericArguments)
                {
                    children.Add(new TypeTreeItem(typeModel));
                }
            }
            if (TypeData.ImplementedInterfaces != null)
            {
                foreach (TypeMetadata typeModel in TypeData.ImplementedInterfaces)
                {
                    children.Add(new TypeTreeItem(typeModel));
                }
            }
            if (TypeData.NestedTypes != null)
            {
                foreach (TypeMetadata typeModel in TypeData.NestedTypes)
                {
                    children.Add(new TypeTreeItem(typeModel));
                }
            }
            if (TypeData.Methods != null)
            {
                foreach (MethodMetadata methodModel in TypeData.Methods)
                {
                    children.Add(new MethodTreeItem(methodModel));
                }
            }
            if (TypeData.Constructors != null)
            {
                foreach (MethodMetadata methodModel in TypeData.Constructors)
                {
                    children.Add(new MethodTreeItem(methodModel));
                }
            }
        }
        public override string ToString()
        {
            string type = String.Empty;
            if (TypeData.Modifiers != null)
            {

                type += TypeData.Modifiers.Item1.ToString().ToLower() + " ";
                type += TypeData.Modifiers.Item2 == SealedEnum.Sealed ? SealedEnum.Sealed.ToString().ToLower() + " " : String.Empty;
                type += TypeData.Modifiers.Item3 == AbstractEnum.Abstract ? AbstractEnum.Abstract.ToString().ToLower() + " " : String.Empty;
                type += TypeData.Modifiers.Item4 == StaticEnum.Static ? StaticEnum.Static.ToString().ToLower() + " " : String.Empty;

            }
            type += TypeData.Type != TypeEnum.None ? TypeData.Type.ToString().ToLower() + " " : String.Empty;
            type += TypeData.Name;
            if (TypeData.IsGeneric)
                type += " - generic type";
            else if (TypeData.IsExternal)
                type += " - external assembly: " + TypeData.NamespaceName;

            return type;
        }
    }
}
