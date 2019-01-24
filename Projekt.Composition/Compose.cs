using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace Projekt.Composition
{
    public sealed class Compose
    {
        private static readonly Lazy<Compose> compose = new Lazy<Compose>(() => new Compose());
        public static Compose Instance { get { return compose.Value; } }
        public AggregateCatalog Catalog { get; private set; }    
        public CompositionContainer Container { get; private set; }
        public void Setup()
        {
            Catalog = new AggregateCatalog();
            Container  = new CompositionContainer(Catalog);
        }
        public void AddLocalAssemblyToCatalog(string assembly)
        {
            DirectoryCatalog localCatalog = new DirectoryCatalog(".", assembly);
            Catalog.Catalogs.Add(localCatalog);
        }
        public void AddProjectAssemblyToCatalog(string assembly)
        {
            DirectoryCatalog projectCatalog = new DirectoryCatalog(GetSolutionPath(assembly), assembly);
            Catalog.Catalogs.Add(projectCatalog);
        }
        public void AddExternalAssemblyToCatalog(string path, string assembly)
        {
            DirectoryCatalog externalCatalog = new DirectoryCatalog(path, assembly);
            Catalog.Catalogs.Add(externalCatalog);
        }
        private Compose()
        {

        }
        private string GetSolutionPath(string LibraryName)
        {
            int index = LibraryName.LastIndexOf(".");
            string LibraryNameWithout = LibraryName.Substring(0, index);
            string AssemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string SolutionDir = AssemblyDir.Substring(0, AssemblyDir.LastIndexOf("Projekt_Ver_2_0"));
            return (SolutionDir + LibraryNameWithout + "\\bin\\Debug");
        }
    }
}