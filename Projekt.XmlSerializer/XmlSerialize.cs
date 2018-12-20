using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;
using Projekt.Model;
using Projekt.XmlSerializer.Model;

namespace Projekt.XmlSerializer
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class XmlSerialize : IDataRepositoryService
    {

        public void Save(AssemblyModel _object, string path)
        {
            XMLAssemblyModel assembly = (XMLAssemblyModel)_object;
            DataContractSerializer dataContractSerializer =
                new DataContractSerializer(typeof(XMLAssemblyModel));

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                dataContractSerializer.WriteObject(fileStream, assembly);
            }
        }

        public AssemblyModel Read(string path)
        {
            XMLAssemblyModel model;
            if (!File.Exists(path))
                throw new ArgumentException("File not exist");
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(XMLAssemblyModel));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                model = (XMLAssemblyModel)dataContractSerializer.ReadObject(fileStream);
            }

            return model;
        }
    }
}
