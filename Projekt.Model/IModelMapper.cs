using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.ComponentModel.Composition;

namespace Projekt.Model
{
    [InheritedExport(typeof(IModelMapper))]
    public interface IModelMapper
    {
        AssemblyMetadata MapToUpper(IAssemblyModel model);
        IAssemblyModel MapToLower(AssemblyMetadata model);
    }
}
