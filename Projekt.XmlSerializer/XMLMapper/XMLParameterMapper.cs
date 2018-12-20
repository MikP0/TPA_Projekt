//using Projekt.Model.Reflection;
//using Projekt.XmlSerializer.Model;

//namespace Projekt.XmlSerializer.XMLMapper
//{
//    public class XMLParameterMapper
//    {
//        public ParameterMetadata MapToUpper(XMLParameterModel model)
//        {
//            ParameterMetadata parameterMetadata = new ParameterMetadata();
//            parameterMetadata.Name = model.Name;
//            if (model.Type != null)
//                parameterMetadata.TypeMetadata = XMLTypeMapper.EmitType((XMLTypeModel)model.Type);
//            return parameterMetadata;
//        }

//        public XMLParameterModel MapToLower(ParameterMetadata model)
//        {
//            XMLParameterModel parameterModel = new XMLParameterModel();
//            parameterModel.Name = model.Name;
//            if (model.TypeMetadata != null)
//                parameterModel.Type = XMLTypeMapper.EmitXMLType(model.TypeMetadata);
//            return parameterModel;
//        }
//    }
//}
