using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModel.TreeViewTemplate
{
    public class TreeViewAssemblyMetadata : TreeViewNode, IBuildable
    {
        public List<NamespaceMetadata> Namespaces { get; private set; }

        public void Add(List<NamespaceMetadata> source, ObservableCollection<TreeViewItem> destination)
        {
            foreach (NamespaceMetadata @namespace in source)
            {
                TreeViewNamespaceMetadata temp = new TreeViewNamespaceMetadata(@namespace);
                destination.Add(new TreeViewItem { Name = temp.ToString(), HierarchyReference = temp });
            }
        }

        public TreeViewAssemblyMetadata(AssemblyMetadata assemblyMetadata) : base(assemblyMetadata.Name)
        {
            Namespaces = assemblyMetadata.Namespaces;
        }

        public void Build(ObservableCollection<TreeViewItem> children)
        {
            if (Namespaces != null)
            {
                Add(Namespaces, children);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
