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
            return MethodMetadata.ToString();
        }
    }
}
