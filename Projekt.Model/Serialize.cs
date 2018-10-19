using log4net;
using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Projekt.Model
{
    public static class Serialize
    {

        private static readonly ILog logger = LogManager.GetLogger("ModelLogger");

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
                if (logger.IsInfoEnabled)
                    logger.Info("Trying to create XmlWriter");

                using (XmlWriter w = XmlWriter.Create(sourcePath, settings))
                {
                    serializer.WriteObject(w, obj);
                }
            }
            catch (ArgumentException e)
            {
                if (logger.IsErrorEnabled)
                {
                    if(sourcePath == null || sourcePath.Length == 0)
                        logger.Error("Error occured when creating XmlWriter! SourcePath is not specified\n" + e);
                    if (settings == null)
                        logger.Error("Error occured when creating XmlWriter! Settings not specified\n" + e);
                }
            }
        }
    }
}
