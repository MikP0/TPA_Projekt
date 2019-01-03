using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.YAMLSerializer.Model
{
    public class YAMLParameterModel : ParameterModel
    {
        public override string Name { get; set; }

        public new YAMLTypeModel Type { get; set; }

    }
}
