﻿using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.YAMLSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLNamespaceModel : NamespaceModel
    {
        [DataMember]
        public override string Name { get; set; }

        [DataMember]
        public new List<XMLTypeModel> Types { get; set; }
    }
}
