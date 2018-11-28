using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
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
        public void AddExternalAssemblyToCatalog(string path, string assembly)
        {
            DirectoryCatalog externalCatalog = new DirectoryCatalog(path, assembly);
            Catalog.Catalogs.Add(externalCatalog);
        }
        private Compose()
        {

        }
    }
}