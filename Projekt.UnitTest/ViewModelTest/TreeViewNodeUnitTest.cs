using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.ViewModel;
using Projekt.Model.Reflection;
using Projekt.ViewModel.TreeViewTemplate;

namespace Projekt.UnitTest.ViewModelTest
{
    [TestClass]
    public class TreeViewNodeUnitTest
    {
        [TestMethod]
        public void TestTVParameterMetadata()
        {
            TypeMetadata typeMetadata = new TypeMetadata("Int", "TestNamespace");
            TreeViewTypeMetadata treeViewTypeMetadata = new TreeViewTypeMetadata(typeMetadata);
            ParameterMetadata parameterMetadata = new ParameterMetadata("Parameter", typeMetadata);
            TreeViewParameterMetadata treeViewParameterMetadata = new TreeViewParameterMetadata(parameterMetadata);
            Assert.AreEqual(typeMetadata, parameterMetadata.TypeMetadata);
            Assert.AreEqual("Parameter", parameterMetadata.Name);
            Assert.AreEqual(parameterMetadata, treeViewParameterMetadata.ParameterData);
        }

        [TestMethod]
        public void TestTVPropertyMetadata()
        {
            TypeMetadata typeMetadata = new TypeMetadata("Int", "TestNamespace");
            TreeViewTypeMetadata treeViewTypeMetadata = new TreeViewTypeMetadata(typeMetadata);
            PropertyMetadata propertyMetadata = new PropertyMetadata("Name", typeMetadata);
            TreeViewPropertyMetadata treeViewPropertyMetadata = new TreeViewPropertyMetadata(propertyMetadata);
            Assert.AreEqual(typeMetadata, propertyMetadata.Type);
            Assert.AreEqual("Name", propertyMetadata.Name);
            Assert.AreEqual(propertyMetadata, treeViewPropertyMetadata.Data);

        }

        [TestMethod]
        public void TestTVTypeMetadata()
        {
            TypeMetadata typeMetadata = new TypeMetadata("Int", "TestNamespace");
            TreeViewTypeMetadata treeViewTypeMetadata = new TreeViewTypeMetadata(typeMetadata);
            Assert.AreEqual(typeMetadata, treeViewTypeMetadata.Data);
            Assert.AreEqual("Int", treeViewTypeMetadata.Name);
        }

        [TestMethod]
        public void TestChildrenNodesInitStatus()
        {
            TreeViewItem treeViewNodeObject = new TreeViewItem();
            Assert.IsNotNull(treeViewNodeObject.Children);
            Assert.IsFalse(treeViewNodeObject.IsExpanded);
        }
    }
}
