using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Reflection
{
    [DataContract]
    public class AssemblyMetadata
    {
        public AssemblyMetadata()
        {

        }
        public AssemblyMetadata(Assembly assembly)
        {
            Name = assembly.ManifestModule.Name;
            Namespaces = (from Type _type in assembly.GetTypes()
                          where _type.GetVisible()
                          group _type by _type.GetNamespace() into _group
                          orderby _group.Key
                          select new NamespaceMetadata(_group.Key, _group.ToList())).ToList();
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<NamespaceMetadata> Namespaces { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
