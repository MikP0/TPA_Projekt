using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.CommonInterfaces;
using Projekt.Fillers;
using Projekt.ViewModel;


namespace Projekt.UnitTest.ViewModelTest
{
    [TestClass]
    public class WorkspaceViewModelUnitTest
    {
        [TestMethod]
        public void TestWVMConstructor()
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            Assert.IsNotNull(workspaceViewModel.HierarchicalAreas);
            Assert.IsNotNull(workspaceViewModel.ReadDataCommand);
            Assert.IsNotNull(workspaceViewModel.SaveDataCommand);
            Assert.IsFalse(String.IsNullOrEmpty(workspaceViewModel.ButtonSave));
        }

        [TestMethod]
        public void TestChangeButtonSave()
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            Assert.IsTrue(workspaceViewModel.SaveDataCommand.CanExecute(null));
        }

        [TestMethod]
        public void TestChangeButtonRead()
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            Assert.IsTrue(workspaceViewModel.ReadDataCommand.CanExecute(null));
        }
        [TestMethod]
        public void TestReadFileName()
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            Assert.AreEqual<String>(workspaceViewModel.ReadFileName, "Nie wybrano pliku");
        }
        [TestMethod]
        public void TestReadFileNameChange()
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            workspaceViewModel.ReadFileName = "C:\\model.dll";
            Assert.AreEqual<String>(workspaceViewModel.ReadFileName, "C:\\model.dll");
        }
        [TestMethod]
        public void TestSaveFileName()
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            Assert.AreEqual<String>(workspaceViewModel.SaveFileName, "Nie wybrano pliku");
        }
        [TestMethod]
        public void TestSaveFileNameChange()
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            workspaceViewModel.SaveFileName = "C:\\plik";
            Assert.AreEqual<String>(workspaceViewModel.SaveFileName, "C:\\plik");
        }
    }
}
