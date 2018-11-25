using System.ComponentModel.Composition;

namespace Projekt.CommonInterfaces
{
    [InheritedExport(typeof(ISaveFilePathService))]
    public interface ISaveFilePathService
    {
        string FilePath(string defaultPath);
    }
}
