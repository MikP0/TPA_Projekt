using log4net;
using Projekt.CommonInterfaces;
using System;
using System.ComponentModel.Composition;
using System.Runtime.Serialization;
using System.Xml;

namespace Projekt.Model
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class XmlSerialize : IDataRepositoryService
    {

        private readonly ILog logger = LogManager.GetLogger("ModelLogger");
        private readonly CustomLogger customLogger = new CustomLogger();

        public void Save<T>(T obj, string sourcePath)
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
        public T Read<T>(string sourcePath)
        {
            using (XmlReader reader = XmlReader.Create(sourcePath))
            {
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                return (T)deserializer.ReadObject(reader);
            }
        }
    }
}
