using System.Collections.Generic;
using Projekt.Model.Enums;

namespace Projekt.Model
{
    public abstract class TypeModel
    {

        public virtual string Name { get; set; }

        public virtual string AssemblyName { get; set; }

        public virtual bool IsExternal { get; set; }

        public virtual bool IsGeneric { get; set; }
        public virtual TypeModel BaseType { get; set; }
        public virtual List<TypeModel> GenericArguments { get; set; }

        public virtual TypeModifiers Modifiers { get; set; }

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
