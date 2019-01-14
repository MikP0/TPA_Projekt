using Projekt.Logic.Model;
using System.Collections.ObjectModel;


namespace Projekt.ViewModel
{
    public class ParameterTreeItem : TreeViewItem
    {
        public ParameterMetadata ParameterMetadata { get; set; }
        public ParameterTreeItem(ParameterMetadata parameterMetadata)
        {
            ParameterMetadata = parameterMetadata;
        }
        protected override void BuildTreeView(ObservableCollection<TreeViewItem> children)
        {
            if (ParameterMetadata.TypeMetadata != null)
            {
                children.Add(new TypeTreeItem(ParameterMetadata.TypeMetadata));
            }
        }
        public override string ToString()
        {
            return ParameterMetadata.TypeMetadata.Name + " " + ParameterMetadata.Name;
        }
    }
}
