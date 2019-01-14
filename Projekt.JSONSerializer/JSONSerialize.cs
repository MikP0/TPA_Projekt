using Newtonsoft.Json;
using Projekt.JSONSerializer.Model;
using Projekt.Model;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace Projekt.JSONSerializer
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class JSONSerialize : IDataRepositoryService
    {
        public void Save(AssemblyModel _object, string path)
        {

            JSONAssemblyModel assembly = (JSONAssemblyModel)_object;
            string name = JsonConvert.SerializeObject(assembly, Formatting.Indented,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.Write(name);
            }

        }

        public AssemblyModel Read(string path)
        {
            JSONAssemblyModel model;
            if (!File.Exists(path))
                throw new ArgumentException("File not exist");
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(path, true))
            {
                var reader = file.ReadToEnd();
                model = JsonConvert.DeserializeObject<JSONAssemblyModel>(reader,
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }

            return model;
        }
    }
}
