using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModel.TreeViewTemplate
{
    public class TreeViewNamespaceMetadata : TreeViewNode, IBuildable
    {
        public List<TypeMetadata> Types { get; set; }

        public TreeViewNamespaceMetadata(NamespaceMetadata namespaceMetadata) : base(namespaceMetadata.Name)
        {
            Types = namespaceMetadata.Types;
        }

        public void Build(ObservableCollection<TreeViewItem> children)
        {
            if (Types != null)
            {
                Add(Types, children);
            }
        }

        

        public override string ToString()
        {
            return Name;
        }
    }
}
