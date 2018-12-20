using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public abstract class MethodModel
    {
        public virtual string Name { get; set; }
        public virtual List<TypeModel> GenericArguments { get; set; }
        public virtual MethodModifiers Modifiers { get; set; }
        public virtual TypeModel ReturnType { get; set; }
        public virtual bool Extension { get; set; }
        public virtual List<ParameterModel> Parameters { get; set; }
    }
}
