using System.Collections.Generic;
using System.Collections.ObjectModel;
using Projekt.Model.Reflection;

namespace Projekt.ViewModel
{
    public class AssemblyTreeItem :  TreeViewItem
    {
        public AssemblyMetadata Assembly { get; set; }
        public List<NamespaceMetadata> Namespaces { get; set; }
        public AssemblyTreeItem(AssemblyMetadata assembly)
        {
            Assembly = assembly;
            Namespaces = assembly.Namespaces;
        }


        protected override void BuildTreeView(ObservableCollection<TreeViewItem> children)
        {
            if (Namespaces != null)
            {
                foreach (NamespaceMetadata namespaceMetadata in Namespaces)
                {
                    children.Add(new NamespaceTreeItem(namespaceMetadata));
                }
            }
        }

        public override string ToString()
        {
            return Assembly.Name;
        }
    }
}
