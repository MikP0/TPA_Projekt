using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModel.TreeViewTemplate
{
    public class TreeViewParameterMetadata : TreeViewNode, IBuildable
    {
        public ParameterMetadata ParameterData { get; private set; }

        public TreeViewParameterMetadata(ParameterMetadata parameterMetadata) : base(parameterMetadata.Name)
        {
            ParameterData = parameterMetadata;
        }

        public void Build(ObservableCollection<TreeViewItem> children)
        {
            if (ParameterData.TypeMetadata != null)
            {
                Add(ParameterData.TypeMetadata, children);
            }
        }

        public override string ToString()
        {
            string name = "";
            if (ParameterData.TypeMetadata != null)
            {
                name = ParameterData.TypeMetadata.Name + " ";
            }
            name += ParameterData.Name;
            return name;
        }
    }
}
