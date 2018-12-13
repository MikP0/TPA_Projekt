using Projekt.Model.Reflection;
using Projekt.XmlSerializer.XMLModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.XMLMapper
{
    public class XMLMethodMapper
    {

        public MethodMetadata MapToUpper(XMLMethodModel model)
        {
            MethodMetadata methodMetadata = new MethodMetadata();
            methodMetadata.Name = model.Name;
            methodMetadata.Extension = model.Extension;
            if (model.GenericArguments != null)
                methodMetadata.GenericArguments = model.GenericArguments.Select(g => XMLTypeMapper.EmitType((XMLTypeModel)g)).ToList();
            methodMetadata.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodMetadata.Parameters = model.Parameters.Select(p => new XMLParameterMapper().MapToUpper((XMLParameterModel)p)).ToList();
            if (model.ReturnType != null)
                methodMetadata.ReturnType = XMLTypeMapper.EmitType((XMLTypeModel)model.ReturnType);
            return methodMetadata;
        }

        public XMLMethodModel MapToLower(MethodMetadata model)
        {
            XMLMethodModel methodModel = new XMLMethodModel();
            methodModel.Name = model.Name;
            methodModel.Extension = model.Extension;
            if (model.GenericArguments != null)
                methodModel.GenericArguments = model.GenericArguments.Select(t => XMLTypeMapper.EmitXMLType(t)).ToList();
            methodModel.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodModel.Parameters = model.Parameters.Select(p => new XMLParameterMapper().MapToLower(p)).ToList();
            if (model.ReturnType != null)
                methodModel.ReturnType = XMLTypeMapper.EmitXMLType(model.ReturnType);
            return methodModel;
        }
    }
}
