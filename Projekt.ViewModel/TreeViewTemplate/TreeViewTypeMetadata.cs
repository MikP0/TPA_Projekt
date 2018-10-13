using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModel.TreeViewTemplate
{
    public class TreeViewTypeMetadata : TreeViewNode, IBuildable
    {
        public TypeMetadata Data { get; private set; }

        public TreeViewTypeMetadata(TypeMetadata typeMetadata) : base(typeMetadata.Name)
        {
            Data = typeMetadata;
        }

        public void Build(ObservableCollection<TreeViewItem> children)
        {
            if (Data.BaseType != null)
            {
                Add(Data.BaseType, children);
            }
            if (Data.DeclaringType != null)
            {
                Add(Data.DeclaringType, children);
            }
            if (Data.Properties != null)
            {
                Add(Data.Properties, children);
            }
            if (Data.Fields != null)
            {
                Add(Data.Fields, children);
            }
            if (Data.GenericArguments != null)
            {
                Add(Data.GenericArguments, children);
            }
            if (Data.ImplementedInterfaces != null)
            {
                Add(Data.ImplementedInterfaces, children);
            }
            if (Data.NestedTypes != null)
            {
                Add(Data.NestedTypes, children);
            }
            if (Data.Methods != null)
            {
                Add(Data.Methods, children);
            }
            if (Data.Constructors != null)
            {
                Add(Data.Constructors, children);
            }
        }

        private string GetSealed(SealedEnum sealedEnum)
        {
            return sealedEnum == SealedEnum.Sealed ? "sealed" : "";
        }

        private string GetTypeKind(TypeMetadata.TypeKind typeKind)
        {
            return typeKind.ToString();
        }

        public override string ToString()
        {
            string name = "";
            if (Data.Modifiers != null)
            {
                string temp;
                temp = GetAccessLevel(Data.Modifiers.Item1);
                name += AddSpace(temp);
                temp = GetSealed(Data.Modifiers.Item2);
                name += AddSpace(temp);
                temp = GetAbstract(Data.Modifiers.Item3);
                name += AddSpace(temp);
            }

            name += GetTypeKind(Data.Type);
            name += " ";
            name += Data.Name;

            return name;
        }

    }
}
