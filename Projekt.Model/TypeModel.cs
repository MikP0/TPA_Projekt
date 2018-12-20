using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    [DataContract(IsReference = true)]
    public abstract class TypeModel
    {
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual string AssemblyName { get; set; }
        [DataMember]
        public virtual bool IsExternal { get; set; }
        [DataMember]
        public virtual bool IsGeneric { get; set; }
        public virtual TypeModel BaseType { get; set; }
        public virtual List<TypeModel> GenericArguments { get; set; }
        [DataMember]
        public virtual TypeModifiers Modifiers { get; set; }
        [DataMember]
        public virtual TypeEnum Type { get; set; }
        public virtual List<TypeModel> ImplementedInterfaces { get; set; }
        public virtual List<TypeModel> NestedTypes { get; set; }
        public virtual List<PropertyModel> Properties { get; set; }
        public virtual TypeModel DeclaringType { get; set; }
        public virtual List<MethodModel> Methods { get; set; }
        public virtual List<MethodModel> Constructors { get; set; }
        public virtual List<ParameterModel> Fields { get; set; }
    }
}
