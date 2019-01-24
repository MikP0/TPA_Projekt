using System.ComponentModel.Composition;

namespace Projekt.ViewModel
{
    [InheritedExport(typeof(ISaveFilePathService))]
    public interface ISaveFilePathService
    {
        string FilePath(string defaultPath);
    }
}
