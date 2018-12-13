using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.XMLModel
{
    [DataContract(IsReference = true)]
    public class XMLPropertyModel
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public XMLTypeModel Type { get; set; }
    }
}
