//using Projekt.Model.Reflection;
//using Projekt.XmlSerializer.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Projekt.XmlSerializer.XMLMapper
//{
//    public class XMLTypeMapper
//    {
//        public static Dictionary<string, XMLTypeModel> XMLTypes = new Dictionary<string, XMLTypeModel>();
//        public static Dictionary<string, TypeMetadata> Types = new Dictionary<string, TypeMetadata>();

//        public static XMLTypeModel EmitXMLType(TypeMetadata model)
//        {
//            return new XMLTypeMapper().MapToLower(model);
//        }

//        public static TypeMetadata EmitType(XMLTypeModel model)
//        {
//            return new XMLTypeMapper().MapToUpper(model);
//        }

//        private void FillXMLType(TypeMetadata model, XMLTypeModel typModel)
//        {
//            typModel.Name = model.Name;
//            typModel.IsExternal = model.IsExternal;
//            typModel.IsGeneric = model.IsGeneric;
//            typModel.Type = model.Type;
//            typModel.AssemblyName = model.Name;
//            //new Tuple4<AccessLevel, SealedEnum, AbstractEnum, StaticEnum>
//            typModel.Modifiers = model.Modifiers ?? new TypeModifiers();

//            typModel.BaseType = EmitXMLType(model.BaseType);
//            typModel.DeclaringType = EmitXMLType(model.DeclaringType);

//            typModel.NestedTypes = model.NestedTypes?.Select(c => EmitXMLType(c)).ToList();
//            typModel.GenericArguments = model.GenericArguments?.Select(c => EmitXMLType(c)).ToList();
//            typModel.ImplementedInterfaces = model.ImplementedInterfaces?.Select(c => EmitXMLType(c)).ToList();

//            typModel.Fields = model.Fields?.Select(c => new XMLParameterMapper().MapToLower(c)).ToList();
//            typModel.Methods = model.Methods?.Select(m => new XMLMethodMapper().MapToLower(m)).ToList();
//            typModel.Constructors = model.Constructors?.Select(c => new XMLMethodMapper().MapToLower(c)).ToList();
//            typModel.Properties = model.Properties?.Select(c => new XMLPropertyMapper().MapToLower(c)).ToList();
//        }

//        private void FillType(XMLTypeModel model, TypeMetadata typeModel)
//        {
//            typeModel.Name = model.Name;
//            typeModel.IsExternal = model.IsExternal;
//            typeModel.IsGeneric = model.IsGeneric;
//            typeModel.Type = model.Type;
//            typeModel.Name = model.AssemblyName;
//            typeModel.Modifiers = model.Modifiers ?? new TypeModifiers();

//            typeModel.BaseType = EmitType((XMLTypeModel)model.BaseType);
//            typeModel.DeclaringType = EmitType((XMLTypeModel)model.DeclaringType);

//            typeModel.NestedTypes = model.NestedTypes?.Select(n => EmitType((XMLTypeModel)n)).ToList();
//            typeModel.GenericArguments = model.GenericArguments?.Select(g => EmitType((XMLTypeModel)g)).ToList();
//            typeModel.ImplementedInterfaces = model.ImplementedInterfaces?.Select(i => EmitType((XMLTypeModel)i)).ToList();

//            typeModel.Fields = model.Fields?.Select(g => new XMLParameterMapper().MapToUpper((XMLParameterModel)g)).ToList();
//            typeModel.Methods = model.Methods?.Select(c => new XMLMethodMapper().MapToUpper((XMLMethodModel)c)).ToList();
//            typeModel.Constructors = model.Constructors?.Select(c => new XMLMethodMapper().MapToUpper((XMLMethodModel)c)).ToList();
//            typeModel.Properties = model.Properties?.Select(g => new XMLPropertyMapper().MapToUpper((XMLPropertyModel)g)).ToList();
//        }


//        #region IModelMapper

//        public TypeMetadata MapToUpper(XMLTypeModel model)
//        {
//            TypeMetadata typeMetadata = new TypeMetadata();
//            if (model == null)
//                return null;

//            if (!Types.ContainsKey(model.Name))
//            {
//                Types.Add(model.Name, typeMetadata);
//                FillType(model, typeMetadata);
//            }
//            return Types[model.Name];

//        }

//        public XMLTypeModel MapToLower(TypeMetadata model)
//        {
//            XMLTypeModel typeModel = new XMLTypeModel();
//            if (model == null)
//                return null;
//            if (!XMLTypes.ContainsKey(model.Name))
//            {
//                XMLTypes.Add(model.Name, typeModel);
//                FillXMLType(model, typeModel);
//            }
//            return XMLTypes[model.Name];
//        }

//        #endregion
//    }
//}
