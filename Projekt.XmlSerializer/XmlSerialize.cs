using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Projekt.CommonInterfaces;

namespace Projekt.XmlSerializer
{
    /*[PartCreationPolicy(CreationPolicy.NonShared)]
    public class XmlSerialize : IDataRepositoryService
    {

        //private readonly ILog logger = LogManager.GetLogger("ModelLogger");
        private readonly CustomLogger customLogger = new CustomLogger();

        public void Save(IAssemblyModel obj, string sourcePath)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = " ",
                NewLineChars = "\r\n"
            };
            try
            {
                customLogger.Info("Trying to create XmlWriter");

                using (XmlWriter w = XmlWriter.Create(sourcePath, settings))
                {
                    serializer.WriteObject(w, obj);
                }
            }
            catch (ArgumentException e)
            {
                if (sourcePath == null || sourcePath.Length == 0)
                    customLogger.Error("Error occured when creating XmlWriter! SourcePath is not specified\n" + e);
                if (settings == null)
                    customLogger.Error("Error occured when creating XmlWriter! Settings not specified\n" + e);
            }
        }
        public void SaveAsync(IAssemblyModel obj, string sourcePath)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = " ",
                NewLineChars = "\r\n",
                Async = true
            };
            try
            {
                customLogger.Info("Trying to create XmlWriter");

                using (XmlWriter w = XmlWriter.Create(sourcePath, settings))
                {
                    serializer.WriteObject(w, obj);
                }
            }
            catch (ArgumentException e)
            {
                if (sourcePath == null || sourcePath.Length == 0)
                    customLogger.Error("Error occured when creating XmlWriter! SourcePath is not specified\n" + e);
                if (settings == null)
                    customLogger.Error("Error occured when creating XmlWriter! Settings not specified\n" + e);
            }
        }
        public IAssemblyModel Read(string sourcePath)
        {
            using (XmlReader reader = XmlReader.Create(sourcePath))
            {
                DataContractSerializer deserializer = new DataContractSerializer(typeof(IAssemblyModel));
                return (IAssemblyModel)deserializer.ReadObject(reader);
            }
        }
        public IAssemblyModel ReadAsync(string sourcePath)
        {
            XmlReaderSettings settings = new XmlReaderSettings
            {
                Async = true
            };
            using (XmlReader reader = XmlReader.Create(sourcePath, settings))
            {
                DataContractSerializer deserializer = new DataContractSerializer(typeof(IAssemblyModel));
                return (IAssemblyModel)deserializer.ReadObject(reader);
            }
        }
    }*/
}
