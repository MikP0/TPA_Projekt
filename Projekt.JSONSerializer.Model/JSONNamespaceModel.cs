using Projekt.Model;
using System.Collections.Generic;

namespace Projekt.JSONSerializer.Model
{
    public class JSONNamespaceModel : NamespaceModel
    {
        public override string Name { get; set; }

        public new List<JSONTypeModel> Types { get; set; }
    }
}
