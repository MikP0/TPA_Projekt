using System.ComponentModel.Composition;

namespace Projekt.CommonInterfaces
{
    [InheritedExport(typeof(IDataRepositoryService))]
    public interface IDataRepositoryService
    {
        void Save<T>(T _object, string path);
        T Read<T>(string path);
    }
}
