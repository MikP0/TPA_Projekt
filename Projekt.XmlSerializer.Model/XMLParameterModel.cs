using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.YAMLSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLParameterModel : ParameterModel
    {
        [DataMember]
        public override string Name { get; set; }

        [DataMember]
        public new XMLTypeModel Type { get; set; }

    }
}
