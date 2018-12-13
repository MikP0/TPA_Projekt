using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.XMLModel
{
    [DataContract(IsReference = true)]
    public class XMLMethodModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<XMLTypeModel> GenericArguments { get; set; }

        [DataMember]
        public MethodModifiers Modifiers { get; set; }

        [DataMember]
        public XMLTypeModel ReturnType { get; set; }

        [DataMember]
        public bool Extension { get; set; }

        [DataMember]
        public List<XMLParameterModel> Parameters { get; set; }
    }
}
