﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Projekt.Logic.Model
{
    public class AssemblyMetadata
    {
        public AssemblyMetadata()
        {

        }

        public AssemblyMetadata(Assembly assembly)
        {
            Name = assembly.ManifestModule.Name;
            Type[] types = assembly.GetTypes();
            Namespaces = types.GroupBy(t => t.Namespace).OrderBy(t => t.Key)
                .Select(t => new NamespaceMetadata(t.Key, t.ToList())).ToList();
        }

        public string Name { get; set; }

        public List<NamespaceMetadata> Namespaces { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
