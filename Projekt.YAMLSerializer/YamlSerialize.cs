using Projekt.Model;
using Projekt.YAMLSerializer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.TypeInspectors;

namespace Projekt.YAMLSerializer
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class YamlSerialize : IDataRepositoryService
    {
        public AssemblyModel Read(string path)
        {
        

            string text = System.IO.File.ReadAllText(path);

            var input = new StringReader(text);
            var deserializer = new DeserializerBuilder().WithNamingConvention(new PascalCaseNamingConvention())
    .WithTypeInspector(inner => inner, s => s.InsteadOf<YamlAttributesTypeInspector>())
    .WithTypeInspector(
        inner => new YamlAttributesTypeInspector(inner),
        s => s.Before<NamingConventionTypeInspector>()
    )
    .Build();

            YAMLAssemblyModel assemblyModel = deserializer.Deserialize<YAMLAssemblyModel>(input);

            return assemblyModel;
        }

        public void Save(AssemblyModel _object, string path)
        {
            
            var serializer = new SerializerBuilder().WithNamingConvention(new PascalCaseNamingConvention())
    .WithTypeInspector(inner => inner, s => s.InsteadOf<YamlAttributesTypeInspector>())
    .WithTypeInspector(
        inner => new YamlAttributesTypeInspector(inner),
        s => s.Before<NamingConventionTypeInspector>()
    ).Build();
            var yaml = serializer.Serialize(_object);

            if (!File.Exists(path))
            {
                File.WriteAllText(path, yaml);
            }
        }
    }
}
