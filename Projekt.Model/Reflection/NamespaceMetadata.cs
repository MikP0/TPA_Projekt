using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Reflection
{
    public class NamespaceMetadata
    {
        public NamespaceMetadata()
        {

        }
        internal NamespaceMetadata(string name, List<Type> types)
        {
            m_Name = name;
            Types = (from type in types orderby type.Name select new TypeMetadata(type)).ToList();
        }

        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        public List<TypeMetadata> Types { get; set; }

    }
}
