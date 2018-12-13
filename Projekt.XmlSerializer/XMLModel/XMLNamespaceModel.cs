using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.XMLModel
{
    [DataContract(IsReference = true)]
    public class XMLNamespaceModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<XMLTypeModel> Types { get; set; }
    }
}
