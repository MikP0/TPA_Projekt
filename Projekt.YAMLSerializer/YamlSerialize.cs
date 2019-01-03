using Projekt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Projekt.YAMLSerializer
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class YamlSerialize : IDataRepositoryService
    {
        public AssemblyModel Read(string path)
        {
            throw new NotImplementedException();

        }

        public void Save(AssemblyModel _object, string path)
        {
            var serializer = new Serializer();

            using (TextWriter writer = File.CreateText(path))
            {
                serializer.Serialize(writer, _object);
            }            
        }
    }
}
