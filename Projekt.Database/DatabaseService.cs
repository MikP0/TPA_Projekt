using Projekt.CommonInterfaces;
using System.ComponentModel.Composition;
using Microsoft.EntityFrameworkCore;
using Projekt.Database.DatabaseModel;
using Projekt.Model.Reflection;
using System.Linq;

namespace Projekt.Database
{
    /*[PartCreationPolicy(CreationPolicy.NonShared)]
    class DatabaseService : IDataRepositoryService
    {
        public void Save<T>(T _object, string path)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                DatabaseAssemblyModel assemblyModel = new DatabaseAssemblyModel().MapToLower(_object);
                context.AssemblyModel.Add(assemblyModel);
                context.SaveChanges();
            }
        }
        public T Read<T>(string path)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.ParameterModel
                    .Include(p => p.Type)
                    .Include(p => p.TypeFields)
                    .Include(p => p.MethodParameters)
                    .Load();
                context.TypeModel
                    .Include(t => t.Constructors)
                    .Include(t => t.BaseType)
                    .Include(t => t.DeclaringType)
                    .Include(t => t.Fields)
                    .Include(t => t.ImplementedInterfaces)
                    .Include(t => t.GenericArguments)
                    .Include(t => t.Methods)
                    .Include(t => t.NestedTypes)
                    .Include(t => t.Properties)
                    .Include(t => t.TypeGenericArguments)
                    .Include(t => t.TypeImplementedInterfaces)
                    .Include(t => t.TypeNestedTypes)
                    .Include(t => t.MethodGenericArguments)
                    .Load();
                context.MethodModel
                    .Include(m => m.GenericArguments)
                    .Include(m => m.Parameters)
                    .Include(m => m.ReturnType)
                    .Include(m => m.TypeConstructors)
                    .Include(m => m.TypeMethods)
                    .Load();
                context.PropertyModel
                    .Include(p => p.Type)
                    .Include(p => p.TypeProperties)
                    .Load();
                context.NamespaceModel
                    .Include(n => n.Types)
                    .Load();

                DatabaseAssemblyModel databaseAssemblyModel = context.AssemblyModel.Include(a => a.NamespaceModels).ToList()[0];
                return databaseAssemblyModel?.MapToUpper(databaseAssemblyModel);
            }
        }
    }*/
}
