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
            DirectoryCatalog localCatalog = new DirectoryCatalog(".", "Projekt.*");
            Catalog.Catalogs.Add(localCatalog);
            Container  = new CompositionContainer(Catalog);
        }
        private Compose()
        {

        }
    }
}