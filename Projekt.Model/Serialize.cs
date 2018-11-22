using log4net;
using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Projekt.Model
{
    public static class Serialize
    {

        private static readonly ILog logger = LogManager.GetLogger("ModelLogger");
        private static readonly CustomLogger customLogger = new CustomLogger();

        public static void XmlSerialize<T>(T obj, string sourcePath)
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
    }
}
