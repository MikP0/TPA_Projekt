using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model.Reflection
{
    public sealed class TypeDictionary : Dictionary<string, TypeMetadata>
    {
        private static readonly Lazy<TypeDictionary> lazy =
            new Lazy<TypeDictionary>(() => new TypeDictionary());

        public static TypeDictionary Instance { get { return lazy.Value; } }

        private TypeDictionary()
        {
        }
    }
}
