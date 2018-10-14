using log4net;
using Projekt.Model.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public class Reflector
    {

        private static readonly ILog logger = LogManager.GetLogger("ModelLogger");

        public AssemblyMetadata AssemblyModel { get; private set; }
        public Assembly Assembly { get; private set; }

        public void Reflect(string assemblyFile)
        {
            if (logger.IsInfoEnabled)
                logger.Info("Loading assembly info from file");
            Assembly = Assembly.LoadFrom(assemblyFile);
            AssemblyModel = new AssemblyMetadata(Assembly);
        }

        public void Reflect(Assembly assembly)
        {
            if (logger.IsInfoEnabled)
                logger.Info("Loading assembly info from assembly object");
            this.Assembly = assembly;
            AssemblyModel = new AssemblyMetadata(assembly);
        }
    }
}
