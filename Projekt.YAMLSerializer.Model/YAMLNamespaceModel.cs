using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.YAMLSerializer.Model
{
    public class YAMLNamespaceModel : NamespaceModel
    {
        public override string Name { get; set; }

        public new List<YAMLTypeModel> Types { get; set; }
    }
}
