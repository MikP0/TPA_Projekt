using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Database.DatabaseModel
{
    public sealed class DatabaseTypeDictionary : Dictionary<string, DatabaseTypeModel>
    {
        private static readonly Lazy<DatabaseTypeDictionary> lazy = new Lazy<DatabaseTypeDictionary>(() => new DatabaseTypeDictionary());
        public static DatabaseTypeDictionary Instance { get { return lazy.Value; } }

        private DatabaseTypeDictionary()
        {
        }
    }
}