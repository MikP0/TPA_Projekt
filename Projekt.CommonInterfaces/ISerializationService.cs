using System.ComponentModel.Composition;

namespace Projekt.CommonInterfaces
{
    [InheritedExport(typeof(ISerializationService))]
    public interface ISerializationService
    {
        void Serialize<T>(T _object, string path);
        T Deserialize<T>(string path);
    }
}
