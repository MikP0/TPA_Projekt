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

        private static readonly TypeDictionary dictionaryInstance = TypeDictionary.Instance;

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


        public void Add(List<TypeMetadata> source, ObservableCollection<TreeViewItem> destination)
        {
            foreach (TypeMetadata type in source)
            {
                TreeViewTypeMetadata temp = new TreeViewTypeMetadata(dictionaryInstance[type.Name]);
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
            TreeViewTypeMetadata temp = new TreeViewTypeMetadata(dictionaryInstance[source.Name]);
            destination.Add(new TreeViewItem { Name = temp.ToString(), HierarchyReference = temp });
        }
    }
}
