using System.ComponentModel.Composition;

namespace Projekt.CommonInterfaces
{
    [InheritedExport(typeof(IDataRepositoryService))]
    public interface IDataRepositoryService
    {
        void Save(IAssemblyModel _object, string path);
        IAssemblyModel Read(string path);
    }
}
