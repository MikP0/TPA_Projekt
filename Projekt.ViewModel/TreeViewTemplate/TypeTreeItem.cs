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

            return TypeData.ToString();
        }
    }
}
