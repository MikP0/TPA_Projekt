using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Projekt.ViewModel
{
    public class NamespaceTreeItem : TreeViewItem
    {
        public NamespaceMetadata NamespaceModel { get; set; }
        public List<TypeMetadata> Types { get; set; }
        public NamespaceTreeItem(NamespaceMetadata namespaceModel)
        {
            NamespaceModel = namespaceModel;
            Types = namespaceModel.Types;
        }

        protected override void BuildTreeView(ObservableCollection<TreeViewItem> children)
        {
            if (Types != null)
            {
                foreach (TypeMetadata typeModel in Types)
                {
                    children.Add(new TypeTreeItem(typeModel));
                }
            }
        }
        public override string ToString()
        {
            return NamespaceModel.Name;
        }
    }
}
