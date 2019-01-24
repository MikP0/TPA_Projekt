using Projekt.Composition;
using Projekt.Logic.Mapper;
using Projekt.Model;
using Projekt.Logic.Model;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Projekt.Logic
{
    [Export(typeof(ReflectionService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ReflectionService 
    {
        [Import(typeof(IDataRepositoryService))]
        public IDataRepositoryService DataRepository { get; set; }
        [Import(typeof(AssemblyModel))]
        public AssemblyModel assemblyModel { get; set; }

        public void Save(AssemblyMetadata model)
        {
            DataRepository.Save(AssemblyModelMapper.MapDown(model, assemblyModel));
        }

        public AssemblyMetadata Read()
        {
            return AssemblyModelMapper.MapUp(DataRepository.Read());
        }
    }
}
