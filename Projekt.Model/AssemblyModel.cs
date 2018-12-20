﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public abstract class AssemblyModel
    {
        public virtual string Name { get; set; }
        public virtual List<NamespaceModel> NamespaceModels { get; set; }
    }
}