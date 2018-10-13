using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public class Reflector
    {

        public AssemblyMetadata AssemblyModel { get; private set; }
        public Assembly Assembly { get; private set; }

        public void Reflect(string assemblyFile)
        {
            Assembly = Assembly.LoadFrom(assemblyFile);
            AssemblyModel = new AssemblyMetadata(Assembly);
        }

        public void Reflect(Assembly assembly)
        {
            this.Assembly = assembly;
            AssemblyModel = new AssemblyMetadata(assembly);
        }
    }
}
