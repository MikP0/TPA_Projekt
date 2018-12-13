using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
namespace Projekt.Model
{
    public interface IModelMapper
    {
        AssemblyMetadata MapToUpper(IAssemblyModel model);
        IAssemblyModel MapToLower(AssemblyMetadata model);
    }
}
