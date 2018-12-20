﻿using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.XmlSerializer.Model
{
    [DataContract(IsReference = true)]
    public class XMLPropertyModel : PropertyModel
    {
        [DataMember]
        public override string Name { get; set; }

        [DataMember]
        public new XMLTypeModel Type { get; set; }
    }
}