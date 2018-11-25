using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projekt.ViewModel;
using Projekt.Cmd;


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
        /*[DataTestMethod]
        [DataRow("C:\\plik")]
        [DataRow("C:\\file")]
        [DataRow("C:\\tiedosto")]
        public void TestIOpenFilePathServiceInjection(String filePath)
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            //workspaceViewModel.InjectOpenFilePathService(CommandLineOpenFilePathService.Create(filePath));
            workspaceViewModel.ReadDataCommand.Execute(null);
            Assert.AreEqual<String>(filePath, workspaceViewModel.ReadFileName);
        }
        [DataTestMethod]
        [DataRow("C:\\plik")]
        [DataRow("C:\\file")]
        [DataRow("C:\\tiedosto")]
        public void TestISaveFilePathServiceInjection(String filePath)
        {
            WorkspaceViewModel workspaceViewModel = new WorkspaceViewModel();
            //workspaceViewModel.InjectSaveFilePathService(CommandLineSaveFilePathService.Create(filePath));
            Assert.IsTrue(workspaceViewModel.SaveDataCommand.CanExecute(null)); // Zmienić to później
        }*/
    }
}
