using System.Collections.Generic;
using System.ComponentModel.Composition;
using Projekt.Model;

namespace Projekt.JSONSerializer.Model
{

    [Export(typeof(AssemblyModel))]
    public class JSONAssemblyModel : AssemblyModel
    {
        public override string Name { get; set; }

        public new List<JSONNamespaceModel> NamespaceModels { get; set; }
    }
}
