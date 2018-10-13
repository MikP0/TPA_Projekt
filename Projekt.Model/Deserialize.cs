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
    public static class Deserialize
    {
        public static T XmlDeserialize<T>(string sourcePath)
        {

            using (XmlReader reader = XmlReader.Create(sourcePath))
            {
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                return (T)deserializer.ReadObject(reader);
                
            }
        }
    }
}