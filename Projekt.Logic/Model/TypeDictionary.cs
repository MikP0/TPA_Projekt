using System;
using System.Collections.Generic;

namespace Projekt.Logic.Model
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
