using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModel.TreeViewTemplate
{
    public abstract class TreeViewNode
    {
        public string Name { get; protected set; }

        public TreeViewNode(string name)
        {
            Name = name;
        }

        public string GetAccessLevel(AccessLevel accessLevel)
        {
            return accessLevel.ToString();
        }

        public string GetAbstract(AbstractEnum abstractEnum)
        {
            if(abstractEnum == AbstractEnum.Abstract)
            {
                return "Abstract";
            }
            else
            {
                return "";
            }
        }

        public string AddSpace(string spc)
        {
            return spc += spc.Length == 0 ? "" : " ";
        }

        public void Add(List<PropertyMetadata> source, ObservableCollection<TreeViewItem> destination)
        {
            foreach (PropertyMetadata property in source)
            {
                TreeViewPropertyMetadata temp = new TreeViewPropertyMetadata(property);
                destination.Add(new TreeViewItem { Name = temp.ToString(), HierarchyReference = temp });
            }
        }

        public void Add(List<TypeMetadata> source, ObservableCollection<TreeViewItem> destination)
        {
            foreach (TypeMetadata type in source)
            {
                TreeViewTypeMetadata temp = new TreeViewTypeMetadata(TypeMetadata.typeDictionary[type.Name]);
                destination.Add(new TreeViewItem { Name = temp.ToString(), HierarchyReference = temp });
            }
        }

        public void Add(List<MethodMetadata> source, ObservableCollection<TreeViewItem> destination)
        {
            foreach (MethodMetadata method in source)
            {
                TreeViewMethodMetadata temp = new TreeViewMethodMetadata(method);
                destination.Add(new TreeViewItem { Name = temp.ToString(), HierarchyReference = temp });
            }
        }

        public void Add(List<NamespaceMetadata> source, ObservableCollection<TreeViewItem> destination)
        {
            foreach (NamespaceMetadata @namespace in source)
            {
                TreeViewNamespaceMetadata temp = new TreeViewNamespaceMetadata(@namespace);
                destination.Add(new TreeViewItem { Name = temp.ToString(), HierarchyReference = temp });
            }
        }

        public void Add(List<ParameterMetadata> source, ObservableCollection<TreeViewItem> destination)
        {
            foreach (ParameterMetadata parameter in source)
            {
                TreeViewParameterMetadata temp = new TreeViewParameterMetadata(parameter);
                destination.Add(new TreeViewItem { Name = temp.ToString(), HierarchyReference = temp });
            }
        }

        public void Add(TypeMetadata source, ObservableCollection<TreeViewItem> destination)
        {
            TreeViewTypeMetadata temp = new TreeViewTypeMetadata(TypeMetadata.typeDictionary[source.Name]);
            destination.Add(new TreeViewItem { Name = temp.ToString(), HierarchyReference = temp });
        }
    }
}
