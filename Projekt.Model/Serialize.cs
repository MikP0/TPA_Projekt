using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Projekt.Model
{
    public static class Serialize
    {
        public static void XmlSerialize<T>(T obj, string sourcePath)
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = " ",
                NewLineChars = "\r\n"
            };

            using (XmlWriter w = XmlWriter.Create(sourcePath, settings))
            {
                serializer.WriteObject(w, obj);
            }
        }
    }
}
