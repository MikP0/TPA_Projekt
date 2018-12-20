//using Projekt.Model.Reflection;
//using Projekt.XmlSerializer.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Projekt.XmlSerializer.XMLMapper
//{
//    public class XMLPropertyMapper
//    {
//        public PropertyMetadata MapToUpper(XMLPropertyModel model)
//    {
//        PropertyMetadata propertyMetadata = new PropertyMetadata();
//        propertyMetadata.Name = model.Name;
//        if (model.Type != null)
//            propertyMetadata.Type = XMLTypeMapper.EmitType((XMLTypeModel)model.Type);
//        return propertyMetadata;
//    }

//    public XMLPropertyModel MapToLower(PropertyMetadata model)
//    {
//        XMLPropertyModel propertyModel = new XMLPropertyModel();
//        propertyModel.Name = model.Name;
//        if (model.Type != null)
//            propertyModel.Type = XMLTypeMapper.EmitXMLType(model.Type);
//        return propertyModel;
//    }
//    }
//}
