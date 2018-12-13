using Projekt.Database.DatabaseModel;
using Projekt.Model.Reflection;

namespace Projekt.Database.DatabaseMapper
{
    public class DatabaseParameterMapper
    {
        public ParameterMetadata MapToUpper(DatabaseParameterModel model)
        {
            ParameterMetadata parameterModel = new ParameterMetadata();
            parameterModel.Name = model.Name;
            if (model.Type != null)
                parameterModel.TypeMetadata = DatabaseTypeMapper.EmitType((DatabaseTypeModel)model.Type);
            return parameterModel;
        }

        public DatabaseParameterModel MapToLower(ParameterMetadata model)
        {
            DatabaseParameterModel parameterModel = new DatabaseParameterModel();
            parameterModel.Name = model.Name;
            if (model.TypeMetadata != null)
                parameterModel.Type = DatabaseTypeMapper.EmitDBType(model.TypeMetadata);
            return parameterModel;
        }
    }
}
