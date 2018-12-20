using Projekt.CommonInterfaces;
using Projekt.Composition;
using Projekt.Database;
using Projekt.Model;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Projekt.Reflection
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ReflectionService : IReflectionService
    {
        public ReflectionService()
        {
            DataRepository = Compose.Instance.Container.GetExportedValue<IDataRepositoryService>();
            Mapper = Compose.Instance.Container.GetExportedValue<IModelMapper>();
        }

        public IDataRepositoryService DataRepository { get; set; }
        public IModelMapper Mapper { get; set; }

        public void Save(AssemblyMetadata model, string path)
        {
            DataRepository.Save(Mapper.MapToLower(model), path);
        }

        public AssemblyMetadata Read(string path)
        {
            return Mapper.MapToUpper(DataRepository.Read(path));
        }
    }
}
