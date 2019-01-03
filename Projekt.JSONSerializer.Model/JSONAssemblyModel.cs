using Projekt.Model;
using Projekt.JSONSerializer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml;

namespace Projekt.JSONSerializer.Model
{

    [Export(typeof(AssemblyModel))]
    public class JSONAssemblyModel : AssemblyModel
    {
        public override string Name { get; set; }

        public new List<JSONNamespaceModel> NamespaceModels { get; set; }
    }
}
