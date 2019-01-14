using Projekt.Logic.Model;
using System.Collections.ObjectModel;

namespace Projekt.ViewModel
{
    public class PropertyTreeItem : TreeViewItem
    {
        public PropertyMetadata PropertyModel { get; set; }
        public PropertyTreeItem(PropertyMetadata type)
        {
            PropertyModel = type;
        }


        protected override void BuildTreeView(ObservableCollection<TreeViewItem> children)
        {
            if (PropertyModel.Type != null)
            {
                children.Add(new TypeTreeItem(PropertyModel.Type));
            }
        }
        public override string ToString()
        {
            return PropertyModel.Type.Name + " " + PropertyModel.Name;


        }
    }
}
