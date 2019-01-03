using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Projekt.YAMLSerializer.Model
{
    public class YAMLParameterModel : ParameterModel
    {
        [YamlMember]
        public override string Name { get; set; }

        [YamlMember]
        public new YAMLTypeModel Type { get; set; }

    }
}
