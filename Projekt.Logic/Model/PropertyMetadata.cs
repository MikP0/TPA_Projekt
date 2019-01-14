using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Logic.Model
{
    public class PropertyMetadata
    {

        public static IEnumerable<PropertyMetadata> EmitProperties(IEnumerable<PropertyInfo> props)
        {
            return from prop in props
                   where prop.GetGetMethod().GetVisible() || prop.GetSetMethod().GetVisible()
                   select new PropertyMetadata(prop.Name, TypeMetadata.EmitReference(prop.PropertyType));
        }

        #region private
        private string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value;  }
        }
        private TypeMetadata m_TypeMetadata;
        public TypeMetadata Type
        {
            get { return m_TypeMetadata; }
            set { m_TypeMetadata = value; }
        }
        public PropertyMetadata()
        {

        }
        public PropertyMetadata(string propertyName, TypeMetadata propertyType)
        {
            m_Name = propertyName;
            m_TypeMetadata = propertyType;
        }
        #endregion

    }
}
