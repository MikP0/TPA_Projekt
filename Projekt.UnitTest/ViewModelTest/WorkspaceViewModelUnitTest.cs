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
            workspaceViewModel workspaceViewModel = new workspaceViewModel();
            Assert.IsNotNull(workspaceViewModel.HierarchicalAreas);
            Assert.IsNotNull(workspaceViewModel.ReadDataCommand);
            Assert.IsNotNull(workspaceViewModel.SaveDataCommand);
            Assert.IsFalse(String.IsNullOrEmpty(workspaceViewModel.ButtonSave));
        }

        [TestMethod]
        public void TestChangeButtonSave()
        {
            workspaceViewModel workspaceViewModel = new workspaceViewModel();
            Assert.IsTrue(workspaceViewModel.SaveDataCommand.CanExecute(null));
        }

        [TestMethod]
        public void TestChangeButtonRead()
        {
            workspaceViewModel workspaceViewModel = new workspaceViewModel();
            Assert.IsTrue(workspaceViewModel.ReadDataCommand.CanExecute(null));
        }
    }
}
