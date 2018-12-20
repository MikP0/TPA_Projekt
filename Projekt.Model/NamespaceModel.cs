using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public abstract class NamespaceModel
    {
        public virtual string Name { get; set; }
        public virtual List<TypeModel> Types { get; set; }
    }
}
