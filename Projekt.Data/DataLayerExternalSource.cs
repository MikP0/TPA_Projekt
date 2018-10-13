using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data
{
    [DataContract]
    public class DataLayerExternalSource
    {
        [DataMember]
        public A _A
        {
            get;
            set;
        }
        [DataMember]
        public B _B
        {
            get;
            set;
        }
        [DataMember]
        public C _C
        {
            get;
            set;
        }
    }
}
