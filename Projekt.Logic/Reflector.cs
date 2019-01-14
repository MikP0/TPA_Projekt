using Projekt.Logic.Model;
using System.Reflection;

namespace Projekt.Logic
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
