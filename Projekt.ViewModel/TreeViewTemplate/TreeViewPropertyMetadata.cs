using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModel.TreeViewTemplate
{
    class TreeViewPropertyMetadata : TreeViewNode, IBuildable
    {
        public PropertyMetadata Data { get; set; }

        public TreeViewPropertyMetadata(PropertyMetadata propertyMetadata) : base(propertyMetadata.Name)
        {
            Data = propertyMetadata;
        }


        public override string ToString()
        {
            string name = " ";
            if(Data.Type != null)
            {
                name += Data.Type.Name;
            }
            name += (" " + Name);
            return name;
        }

        public void Build(ObservableCollection<TreeViewItem> children)
        {
            if(Data.Type != null)
            {
                Add(Data.Type, children);
            }
        }
    }
}
