using System.ComponentModel.Composition;

namespace Projekt.CommonInterfaces
{
    [InheritedExport(typeof(IOpenFilePathService))]
    public interface IOpenFilePathService
    {
        string FilePath(string defaultPath);
    }
}
