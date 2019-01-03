using Projekt.Model;
using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.YAMLSerializer.Model
{
    public class YAMLMethodModel : MethodModel
    {
        public override string Name { get; set; }

        public new List<YAMLTypeModel> GenericArguments { get; set; }

        public override Projekt.Model.MethodModifiers Modifiers { get; set; }

        public new YAMLTypeModel ReturnType { get; set; }

        public override bool Extension { get; set; }

        public new List<YAMLParameterModel> Parameters { get; set; }
    }
}
