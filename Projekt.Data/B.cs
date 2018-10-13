using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data
{
    [DataContract(IsReference = true)]
    public class B
    {
        public B() { }

        [DataMember]
        public string _FieldString { get; set; }
        [DataMember]
        public int _FieldInt { get; set; }
        [DataMember]
        public C _refToC { get; set; }
        public B(string FieldString, int FieldInt, C refToC)
        {
            this._FieldString = FieldString;
            this._FieldInt = FieldInt;
            this._refToC = refToC;
        }
        public override string ToString()
        {
            return _FieldString + " " + _FieldInt;
        }
    }
}
