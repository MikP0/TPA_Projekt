using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    [DataContract(IsReference = true)]
    public abstract class MethodModel
    {
        [DataMember]
        public virtual string Name { get; set; }
        public virtual List<TypeModel> GenericArguments { get; set; }
        [DataMember]
        public virtual MethodModifiers Modifiers { get; set; }
        public virtual TypeModel ReturnType { get; set; }
        [DataMember]
        public virtual bool Extension { get; set; }
        public virtual List<ParameterModel> Parameters { get; set; }
    }
}
