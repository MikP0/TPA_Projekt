using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.ComponentModel.Composition;

namespace Projekt.Model
{
    [InheritedExport(typeof(IReflectionService))]
    public interface IReflectionService
    {
        IDataRepositoryService DataRepository { get; set; }
        IModelMapper Mapper { get; set; }
        void Save(AssemblyMetadata model, string path);
        AssemblyMetadata Read(string path);
    }
}
