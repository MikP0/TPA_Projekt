using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data
{
    [DataContract(IsReference = true)]
    public class C
    {
        public C() { }

        [DataMember]
        public string _FieldString { get; set; }
        [DataMember]
        public int _FieldInt { get; set; }
        [DataMember]
        public A _refToA { get; set; }
        public C(string FieldString, int FieldInt, A refToA)
        {
            this._FieldString = FieldString;
            this._FieldInt = FieldInt;
            this._refToA = refToA;
        }
        public override string ToString()
        {
            return _FieldString + " " + _FieldInt;
        }
    }
}
