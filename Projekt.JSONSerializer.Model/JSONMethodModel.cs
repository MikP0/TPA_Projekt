using System.Collections.Generic;
using Projekt.Model;

namespace Projekt.JSONSerializer.Model
{
    public class JSONMethodModel : MethodModel
    {
        public override string Name { get; set; }

        public new List<JSONTypeModel> GenericArguments { get; set; }

        public override Projekt.Model.MethodModifiers Modifiers { get; set; }

        public new JSONTypeModel ReturnType { get; set; }

        public override bool Extension { get; set; }

        public new List<JSONParameterModel> Parameters { get; set; }
    }
}
