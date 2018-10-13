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
    }
}
