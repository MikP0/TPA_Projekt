using System.ComponentModel.Composition;

namespace Projekt.Model
{
    [InheritedExport(typeof(IDataRepositoryService))]
    public interface IDataRepositoryService
    {
        void Save(AssemblyModel _object, string path);
        AssemblyModel Read(string path);
        string RepositoryServiceType { get; }
    }
}
