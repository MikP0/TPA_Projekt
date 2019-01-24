using System.ComponentModel.Composition;

namespace Projekt.ViewModel
{
    [InheritedExport(typeof(IOpenFilePathService))]
    public interface IOpenFilePathService
    {
        string FilePath(string defaultPath);
    }
}
