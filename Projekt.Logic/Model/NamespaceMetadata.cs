using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt.Logic.Model
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
