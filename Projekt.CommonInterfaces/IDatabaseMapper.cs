using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.CommonInterfaces
{
    public interface IDatabaseMapper<TUpper, TLower>
    {
        TUpper MapToUpper(TLower model);
        TLower MapToLower(TUpper model);
    }
}
