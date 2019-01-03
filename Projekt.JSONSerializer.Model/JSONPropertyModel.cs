using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.JSONSerializer.Model
{
    public class JSONPropertyModel : PropertyModel
    {
        public override string Name { get; set; }

        public new JSONTypeModel Type { get; set; }
    }
}
