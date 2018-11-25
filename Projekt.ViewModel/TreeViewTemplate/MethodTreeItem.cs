using Projekt.Model.Reflection;
using System;
using System.Collections.ObjectModel;


namespace Projekt.ViewModel
{
    public class MethodTreeItem : TreeViewItem
    {
        public MethodMetadata MethodMetadata { get; set; }
        public MethodTreeItem(MethodMetadata methodModel) 
        {
            MethodMetadata = methodModel;
        }


        protected override void BuildTreeView(ObservableCollection<TreeViewItem> children)
        {

            if (MethodMetadata.GenericArguments != null)
            {
                foreach (TypeMetadata genericArgument in MethodMetadata.GenericArguments)
                {
                    children.Add(new TypeTreeItem(genericArgument));
                }
            }

            if (MethodMetadata.Parameters != null)
            {
                foreach (ParameterMetadata parameter in MethodMetadata.Parameters)
                {
                    children.Add(new ParameterTreeItem(parameter));
                }
            }

            if (MethodMetadata.ReturnType != null)
            {
                children.Add(new TypeTreeItem(MethodMetadata.ReturnType));
            }
        }
        public override string ToString()
        {
            string type = String.Empty;
            type += MethodMetadata.Modifiers.Item1.ToString().ToLower() + " ";
            type += MethodMetadata.Modifiers.Item2 == AbstractEnum.Abstract ? AbstractEnum.Abstract.ToString().ToLower() + " " : String.Empty;
            type += MethodMetadata.Modifiers.Item3 == StaticEnum.Static ? StaticEnum.Static.ToString().ToLower() + " " : String.Empty;
            type += MethodMetadata.Modifiers.Item4 == VirtualEnum.Virtual ? VirtualEnum.Virtual.ToString().ToLower() + " " : String.Empty;
            type += MethodMetadata.ReturnType != null ? MethodMetadata.ReturnType.Name +" " : String.Empty;
            type += MethodMetadata.Name;
            type += MethodMetadata.Extension ? " :Extension method" : String.Empty;
            return type;
        }
    }
}
