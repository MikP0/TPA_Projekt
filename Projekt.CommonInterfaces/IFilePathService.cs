using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.CommonInterfaces
{
    public interface IFilePathService
    {
        string FilePath(string defaultPath);
    }
}
