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
    public class YAMLMethodModel : MethodModel
    {
        [YamlMember]
        public override string Name { get; set; }

        [YamlMember]
        public new List<YAMLTypeModel> GenericArguments { get; set; }

        [YamlMember]
        public override Projekt.Model.MethodModifiers Modifiers { get; set; }

        [YamlMember]
        public new YAMLTypeModel ReturnType { get; set; }

        [YamlMember]
        public override bool Extension { get; set; }

        [YamlMember]
        public new List<YAMLParameterModel> Parameters { get; set; }
    }
}
