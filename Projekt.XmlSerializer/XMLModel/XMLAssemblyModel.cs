using Projekt.CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.XMLModel
{
    [DataContract]
    public class XMLAssemblyModel : IAssemblyModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<XMLNamespaceModel> NamespaceModels { get; set; }
    }
}
