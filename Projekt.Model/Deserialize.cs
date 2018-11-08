using System.Runtime.Serialization;
using System.Xml;

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