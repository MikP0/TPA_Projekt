using Projekt.Model;
using Projekt.YAMLSerializer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml;

namespace Projekt.YamlSerializer.Model
{

    [Export(typeof(AssemblyModel))]
    public class YAMLAssemblyModel : AssemblyModel
    {

        public override string Name { get; set; }

        public new List<YAMLNamespaceModel> NamespaceModels { get; set; }
    }
}
