using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.ViewModel;
using Projekt.Model.Reflection;

namespace Projekt.UnitTest.ViewModelTest
{
    [TestClass]
    public class TreeViewNodeUnitTest
    {
        [TestMethod]
        public void TestTVParameterMetadata()
        {
            TypeMetadata typeMetadata = new TypeMetadata("Int", "TestNamespace");
            TypeTreeItem treeViewTypeMetadata = new TypeTreeItem(typeMetadata);
            ParameterMetadata parameterMetadata = new ParameterMetadata("Parameter", typeMetadata);
            ParameterTreeItem treeViewParameterMetadata = new ParameterTreeItem(parameterMetadata);
            Assert.AreEqual(typeMetadata, parameterMetadata.TypeMetadata);
            Assert.AreEqual("Parameter", parameterMetadata.Name);
            Assert.AreEqual(parameterMetadata, treeViewParameterMetadata.ParameterMetadata);
        }

        [TestMethod]
        public void TestTVPropertyMetadata()
        {
            TypeMetadata typeMetadata = new TypeMetadata("Int", "TestNamespace");
            TypeTreeItem treeViewTypeMetadata = new TypeTreeItem(typeMetadata);
            PropertyMetadata propertyMetadata = new PropertyMetadata("Name", typeMetadata);
            PropertyTreeItem treeViewPropertyMetadata = new PropertyTreeItem(propertyMetadata);
            Assert.AreEqual(typeMetadata, propertyMetadata.Type);
            Assert.AreEqual("Name", propertyMetadata.Name);
            Assert.AreEqual(propertyMetadata, treeViewPropertyMetadata.PropertyModel);

        }

        [TestMethod]
        public void TestTVTypeMetadata()
        {
            TypeMetadata typeMetadata = new TypeMetadata("Int", "TestNamespace");
            TypeTreeItem treeViewTypeMetadata = new TypeTreeItem(typeMetadata);
            Assert.AreEqual(typeMetadata, treeViewTypeMetadata.TypeData);
            StringAssert.Contains(treeViewTypeMetadata.ToString(), "Int");
        }
    }
}
