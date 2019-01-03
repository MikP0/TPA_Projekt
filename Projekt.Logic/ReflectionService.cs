using Projekt.Composition;
using Projekt.Logic.Mapper;
using Projekt.Model;
using Projekt.Model.Reflection;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Projekt.Logic
{
    [Export(typeof(ReflectionService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ReflectionService 
    {
        public ReflectionService()
        {
            DataRepository = Compose.Instance.Container.GetExportedValue<IDataRepositoryService>();
            assemblyModel = Compose.Instance.Container.GetExportedValue<AssemblyModel>();
        }

        public IDataRepositoryService DataRepository { get; set; }
        public AssemblyModel assemblyModel { get; set; }

        public void Save(AssemblyMetadata model, string path)
        {
            DataRepository.Save(AssemblyModelMapper.MapDown(model, assemblyModel), path);
        }

        public AssemblyMetadata Read(string path)
        {
            return AssemblyModelMapper.MapUp(DataRepository.Read(path));
        }
    }
}
