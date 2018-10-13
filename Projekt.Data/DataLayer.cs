using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Data
{
    public class DataLayer 
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
        public DataLayer(DataLayerExternalSource dataLayerExternalSource)
        {
            if (dataLayerExternalSource == null)
                throw new ArgumentNullException("dataLayerExternalSource", "The external source of data turned out to be null");
            _A = dataLayerExternalSource._A;
            _B = dataLayerExternalSource._B;
            _C = dataLayerExternalSource._C;
        }
        public DataLayer(A _A, B _B, C _C)
        {
            if (_A == null || _B == null || _C == null)
                throw new ArgumentNullException("A, B or C", "The external source of data turned out to be null");
            this._A = _A;
            this._B = _B;
            this._C = _C;
        }
        public DataLayer()
        {

        }
    }
}
