using Projekt.Database.DatabaseModel;
using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Database.DatabaseMapper
{
    public class DatabaseTypeMapper
    {
        private static readonly DatabaseTypeDictionary databaseTypeDictionary = DatabaseTypeDictionary.Instance;
        private static readonly TypeDictionary typeDictionary = TypeDictionary.Instance;

        public static DatabaseTypeModel EmitDBType(TypeMetadata model)
        {
            return new DatabaseTypeMapper().MapToLower(model);
        }
        public static TypeMetadata EmitType(DatabaseTypeModel model)
        {
            return new DatabaseTypeMapper().MapToUpper(model);
        }
        private void FillDatabaseType(TypeMetadata model, DatabaseTypeModel typModel)
        {
            typModel.Name = model.Name;
            typModel.IsExternal = model.IsExternal;
            typModel.IsGeneric = model.IsGeneric;
            typModel.Type = model.Type;
            typModel.NamespaceName = model.NamespaceName;
            typModel.Modifiers = model.Modifiers ?? new TypeModifiers();

            typModel.BaseType = EmitDBType(model.BaseType);
            typModel.DeclaringType = EmitDBType(model.DeclaringType);

            typModel.NestedTypes = model.NestedTypes?.Select(c => EmitDBType(c)).ToList();
            typModel.GenericArguments = model.GenericArguments?.Select(c => EmitDBType(c)).ToList();
            typModel.ImplementedInterfaces = model.ImplementedInterfaces?.Select(c => EmitDBType(c)).ToList();

            typModel.Fields = model.Fields?.Select(c => new DatabaseParameterMapper().MapToLower(c)).ToList();
            typModel.Methods = model.Methods?.Select(m => new DatabaseMethodMapper().MapToLower(m)).ToList();
            typModel.Constructors = model.Constructors?.Select(c => new DatabaseMethodMapper().MapToLower(c)).ToList();
            typModel.Properties = model.Properties?.Select(c => new DatabasePropertyMapper().MapToLower(c)).ToList();
        }

        private void FillType(DatabaseTypeModel model, TypeMetadata typeModel)
        {
            typeModel.Name = model.Name;
            typeModel.IsExternal = model.IsExternal;
            typeModel.IsGeneric = model.IsGeneric;
            typeModel.Type = model.Type;
            typeModel.NamespaceName = model.NamespaceName;
            typeModel.Modifiers = model.Modifiers ?? new TypeModifiers();

            typeModel.BaseType = EmitType((DatabaseTypeModel)model.BaseType);
            typeModel.DeclaringType = EmitType((DatabaseTypeModel)model.DeclaringType);

            typeModel.NestedTypes = model.NestedTypes?.Select(n => EmitType((DatabaseTypeModel)n)).ToList();
            typeModel.GenericArguments = model.GenericArguments?.Select(g => EmitType((DatabaseTypeModel)g)).ToList();
            typeModel.ImplementedInterfaces = model.ImplementedInterfaces?.Select(i => EmitType((DatabaseTypeModel)i)).ToList();

            typeModel.Fields = model.Fields?.Select(g => new DatabaseParameterMapper().MapToUpper((DatabaseParameterModel)g)).ToList();
            typeModel.Methods = model.Methods?.Select(c => new DatabaseMethodMapper().MapToUpper((DatabaseMethodModel)c)).ToList();
            typeModel.Constructors = model.Constructors?.Select(c => new DatabaseMethodMapper().MapToUpper((DatabaseMethodModel)c)).ToList();
            typeModel.Properties = model.Properties?.Select(g => new DatabasePropertyMapper().MapToUpper((DatabasePropertyModel)g)).ToList();
        }

        public TypeMetadata MapToUpper(DatabaseTypeModel model)
        {
            TypeMetadata typeModel = new TypeMetadata();
            if (model == null)
                return null;

            if (!typeDictionary.ContainsKey(model.Name))
            {
                typeDictionary.Add(model.Name, typeModel);
                FillType(model, typeModel);
            }
            return typeDictionary[model.Name];

        }

        public DatabaseTypeModel MapToLower(TypeMetadata model)
        {
            DatabaseTypeModel typeModel = new DatabaseTypeModel();
            if (model == null)
                return null;
            if (!databaseTypeDictionary.ContainsKey(model.Name))
            {
                databaseTypeDictionary.Add(model.Name, typeModel);
                FillDatabaseType(model, typeModel);
            }
            return databaseTypeDictionary[model.Name];
        }
    }
}
