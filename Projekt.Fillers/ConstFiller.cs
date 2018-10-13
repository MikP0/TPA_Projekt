using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.CommonInterfaces;
using Projekt.Data;

namespace Projekt.Fillers
{
    public class ConstFiller : IDataFiller
    {
        A constA;
        B constB;
        C constC;
        public DataLayerExternalSource Fill()
        {
            DataLayerExternalSource dataLayerExternalSource = new DataLayerExternalSource();
            InitializeDataLists();
            dataLayerExternalSource._A = constA;
            dataLayerExternalSource._B = constB;
            dataLayerExternalSource._C = constC;
            return dataLayerExternalSource;
        }
        internal void InitializeDataLists()
        {
            constA = new A("A", 1, null);
            constB = new B("B", 2, null);
            constC = new C("C", 3, null);

            constA._refToB = constB;
            constB._refToC = constC;
            constC._refToA = constA;
        }
    }
}
