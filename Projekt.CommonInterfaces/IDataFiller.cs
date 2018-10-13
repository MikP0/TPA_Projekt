using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Data;

namespace Projekt.CommonInterfaces
{
    public interface IDataFiller
    {
        DataLayerExternalSource Fill();
    }
}
