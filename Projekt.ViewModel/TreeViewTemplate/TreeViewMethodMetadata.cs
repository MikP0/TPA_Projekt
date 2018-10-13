using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModel.TreeViewTemplate
{
    public class TreeViewMethodMetadata : TreeViewNode, IBuildable
    {
        public MethodMetadata Method { get; private set; }

        public TreeViewMethodMetadata(MethodMetadata methodMetadata) : base(methodMetadata.Name)
        {
            Method = methodMetadata;
        }

        private string GetVirtual(VirtualEnum virtualEnum)
        {
            return virtualEnum == VirtualEnum.Virtual ? "virtual" : "";
        }

        private string GetStatic(StaticEnum staticEnum)
        {
            return staticEnum == StaticEnum.Static ? "static" : "";
        }

        public void Build(ObservableCollection<TreeViewItem> children)
        {
            if (Method.GenericArguments != null)
            {
                Add(Method.GenericArguments, children);
            }
            if (Method.Parameters != null)
            {
                Add(Method.Parameters, children);
            }
            if (Method.ReturnType != null)
            {
                Add(Method.ReturnType, children);
            }
        }

        public override string ToString()
        {

            string name = "";
            if (Method.Modifiers != null)
            {
                string temp;
                temp = GetAccessLevel(Method.Modifiers.Item1);
                name += AddSpace(temp);
                temp = GetAbstract(Method.Modifiers.Item2);
                name += AddSpace(temp);
                temp = GetStatic(Method.Modifiers.Item3);
                name += AddSpace(temp);
                temp = GetVirtual(Method.Modifiers.Item4);
                name += AddSpace(temp);
            }
            name += ((Method.ReturnType != null) ? Method.ReturnType.Name : "") + " " + Method.Name + "()";
            return name;
        }
    }
}
