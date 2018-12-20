using Projekt.Model;
using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLMethodModel : MethodModel
    {
        [DataMember]
        public override string Name { get; set; }

        [DataMember]
        public new List<XMLTypeModel> GenericArguments { get; set; }

        [DataMember]
        public override Projekt.Model.MethodModifiers Modifiers { get; set; }

        [DataMember]
        public new XMLTypeModel ReturnType { get; set; }

        [DataMember]
        public override bool Extension { get; set; }

        [DataMember]
        public new List<XMLParameterModel> Parameters { get; set; }
    }
}
