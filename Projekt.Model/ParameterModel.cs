using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public abstract class ParameterModel
    {
        public virtual string Name { get; set; }
        public virtual TypeModel Type { get; set; }
    }
}
