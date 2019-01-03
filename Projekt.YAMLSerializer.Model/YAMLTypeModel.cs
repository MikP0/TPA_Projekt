using Projekt.Model;
using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Projekt.YAMLSerializer.Model
{

    public class YAMLTypeModel : TypeModel
    {
        [YamlMember]
        public override string Name { get; set; }

        [YamlMember]
        public override string AssemblyName { get; set; }

        [YamlMember]
        public override bool IsExternal { get; set; }

        [YamlMember]
        public override bool IsGeneric { get; set; }

        [YamlMember]
        public new YAMLTypeModel BaseType { get; set; }

        [YamlMember]
        public new List<YAMLTypeModel> GenericArguments { get; set; }

        [YamlMember]
        public override TypeModifiers Modifiers { get; set; }

        [YamlMember]
        public override TypeEnum Type { get; set; }

        [YamlMember]
        public new List<YAMLTypeModel> ImplementedInterfaces { get; set; }

        [YamlMember]
        public new List<YAMLTypeModel> NestedTypes { get; set; }

        [YamlMember]
        public new List<YAMLPropertyModel> Properties { get; set; }

        [YamlMember]
        public new YAMLTypeModel DeclaringType { get; set; }

        [YamlMember]
        public new List<YAMLMethodModel> Methods { get; set; }

        [YamlMember]
        public new List<YAMLMethodModel> Constructors { get; set; }

        [YamlMember]
        public new List<YAMLParameterModel> Fields { get; set; }
    }
}
