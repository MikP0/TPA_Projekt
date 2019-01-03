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

    public class YAMLTypeModel : TypeModel
    {

        public override string Name { get; set; }

        public override string AssemblyName { get; set; }

        public override bool IsExternal { get; set; }

        public override bool IsGeneric { get; set; }
    
        public new YAMLTypeModel BaseType { get; set; }
      
        public new List<YAMLTypeModel> GenericArguments { get; set; }
     
        public override TypeModifiers Modifiers { get; set; }
        
        public override TypeEnum Type { get; set; }
   
        public new List<YAMLTypeModel> ImplementedInterfaces { get; set; }
      
        public new List<YAMLTypeModel> NestedTypes { get; set; }
   
        public new List<YAMLPropertyModel> Properties { get; set; }

        
        public new YAMLTypeModel DeclaringType { get; set; }

        
        public new List<YAMLMethodModel> Methods { get; set; }

        
        public new List<YAMLMethodModel> Constructors { get; set; }

        
        public new List<YAMLParameterModel> Fields { get; set; }
    }
}
