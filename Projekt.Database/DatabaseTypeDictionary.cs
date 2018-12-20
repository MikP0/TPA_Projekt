using Projekt.Database.Model;
using System;
using System.Collections.Generic;

namespace Projekt.Database
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
