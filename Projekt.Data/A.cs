using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data
{
    [DataContract(IsReference = true)]
    public class A
    {
        public A() { }

        [DataMember]
        public string _FieldString { get; set; }
        [DataMember]
        public int _FieldInt { get; set; }
        [DataMember]
        public B _refToB { get; set; }

        public A(string FieldString, int FieldInt, B refToB)
        {
            _FieldString = FieldString;
            _FieldInt = FieldInt;
            _refToB = refToB;
        }

        public override string ToString()
        {
            return _FieldString + " " + _FieldInt;
        }
    }
}
