using Projekt.Model;
using Projekt.Model.Enums;
using System.Collections.Generic;

namespace Projekt.JSONSerializer.Model
{

    public class JSONTypeModel : TypeModel
    {
        public override string Name { get; set; }

        public override string AssemblyName { get; set; }

        public override bool IsExternal { get; set; }

        public override bool IsGeneric { get; set; }

        public new JSONTypeModel BaseType { get; set; }

        public new List<JSONTypeModel> GenericArguments { get; set; }

        public override TypeModifiers Modifiers { get; set; }

        public override TypeEnum Type { get; set; }

        public new List<JSONTypeModel> ImplementedInterfaces { get; set; }

        public new List<JSONTypeModel> NestedTypes { get; set; }

        public new List<JSONPropertyModel> Properties { get; set; }

        public new JSONTypeModel DeclaringType { get; set; }

        public new List<JSONMethodModel> Methods { get; set; }

        public new List<JSONMethodModel> Constructors { get; set; }

        public new List<JSONParameterModel> Fields { get; set; }
    }
}
