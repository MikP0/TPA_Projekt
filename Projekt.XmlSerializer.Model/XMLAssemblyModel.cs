using Projekt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml;

namespace Projekt.XmlSerializer.Model
{
    [DataContract(IsReference = true)]
    [Export(typeof(AssemblyModel))]
    public class XMLAssemblyModel : AssemblyModel
    {
        [DataMember]
        public override string Name { get; set; }
        [DataMember]
        public new List<XMLNamespaceModel> NamespaceModels { get; set; }
    }
}
