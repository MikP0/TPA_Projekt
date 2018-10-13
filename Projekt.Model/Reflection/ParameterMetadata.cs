using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Reflection
{
    [DataContract]
    public class ParameterMetadata
    {

        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            m_Name = name;
            TypeMetadata = typeMetadata;
        }

        //private vars
        [DataMember]
        private string m_Name;
        [DataMember]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        [DataMember]
        public TypeMetadata TypeMetadata { get; set; }

    }
}
