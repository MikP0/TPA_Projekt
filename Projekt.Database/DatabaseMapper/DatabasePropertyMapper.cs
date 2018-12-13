using Projekt.Database.DatabaseModel;
using Projekt.Model.Reflection;

namespace Projekt.Database.DatabaseMapper
{
    public class DatabasePropertyMapper
    {
        public PropertyMetadata MapToUpper(DatabasePropertyModel model)
        {
            PropertyMetadata propertyModel = new PropertyMetadata();
            propertyModel.Name = model.Name;
            if (model.Type != null)
                propertyModel.Type = DatabaseTypeMapper.EmitType((DatabaseTypeModel)model.Type);
            return propertyModel;
        }

        public DatabasePropertyModel MapToLower(PropertyMetadata model)
        {
            DatabasePropertyModel propertyModel = new DatabasePropertyModel();
            propertyModel.Name = model.Name;
            if (model.Type != null)
                propertyModel.Type = DatabaseTypeMapper.EmitDBType(model.Type);
            return propertyModel;
        }
    }
}
