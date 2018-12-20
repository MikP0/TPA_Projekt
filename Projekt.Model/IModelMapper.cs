﻿using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.ComponentModel.Composition;

namespace Projekt.Model
{
    [InheritedExport(typeof(IModelMapper))]
    public interface IModelMapper
    {
        AssemblyMetadata MapToUpper(AssemblyModel model);
        AssemblyModel MapToLower(AssemblyMetadata model);
    }
}
