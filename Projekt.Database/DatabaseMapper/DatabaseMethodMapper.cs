using Projekt.Database.DatabaseModel;
using Projekt.Model.Reflection;
using System.Linq;

namespace Projekt.Database.DatabaseMapper
{
    public class DatabaseMethodMapper
    {
        public MethodMetadata MapToUpper(DatabaseMethodModel model)
        {
            MethodMetadata methodModel = new MethodMetadata();
            methodModel.Name = model.Name;
            methodModel.Extension = model.Extension;
            if (model.GenericArguments != null)
                methodModel.GenericArguments = model.GenericArguments.Select(g => DatabaseTypeMapper.EmitType((DatabaseTypeModel)g)).ToList();
            methodModel.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodModel.Parameters = model.Parameters.Select(p => new DatabaseParameterMapper().MapToUpper((DatabaseParameterModel)p)).ToList();
            if (model.ReturnType != null)
                methodModel.ReturnType = DatabaseTypeMapper.EmitType((DatabaseTypeModel)model.ReturnType);
            return methodModel;
        }
        public DatabaseMethodModel MapToLower(MethodMetadata model)
        {
            DatabaseMethodModel methodModel = new DatabaseMethodModel();
            methodModel.Name = model.Name;
            methodModel.Extension = model.Extension;
            if (model.GenericArguments != null)
                methodModel.GenericArguments = model.GenericArguments.Select(t => DatabaseTypeMapper.EmitDBType(t)).ToList();
            methodModel.Modifiers = model.Modifiers;
            if (model.Parameters != null)
                methodModel.Parameters = model.Parameters.Select(p => new DatabaseParameterMapper().MapToLower(p)).ToList();
            if (model.ReturnType != null)
                methodModel.ReturnType = DatabaseTypeMapper.EmitDBType(model.ReturnType);
            return methodModel;
        }
    }
}
