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
        public void Save(AssemblyModel _object)
        {

            JSONAssemblyModel assembly = (JSONAssemblyModel)_object;
            string name = JsonConvert.SerializeObject(assembly, Formatting.Indented,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            
            if (string.IsNullOrEmpty(Properties.Settings.Default.ReadFileName))
                throw new ArgumentException("Variable ReadFileName in application settings is empty");
            using (StreamWriter file = new StreamWriter(Properties.Settings.Default.ReadFileName, true))
            {
                file.Write(name);
            }

        }

        public AssemblyModel Read()
        {
            JSONAssemblyModel model;
            if (string.IsNullOrEmpty(Properties.Settings.Default.ReadFileName))
                throw new ArgumentException("Variable ReadFileName in application settings is empty");
            if (!File.Exists(Properties.Settings.Default.ReadFileName))
                throw new ArgumentException("File not exist");
            using (System.IO.StreamReader file =
                new System.IO.StreamReader(Properties.Settings.Default.ReadFileName, true))
            {
                var reader = file.ReadToEnd();
                model = JsonConvert.DeserializeObject<JSONAssemblyModel>(reader,
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }

            return model;
        }
    }
}
