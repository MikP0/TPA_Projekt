using System;
using System.Collections.ObjectModel;
using Projekt.Model;
using Projekt.CommonInterfaces;
using Projekt.Model.Reflection;
using System.Reflection;
using System.Windows;
using log4net;
using System.ComponentModel.Composition;
using Projekt.ViewModel;
using Projekt.Composition;
using Projekt.Logic;

namespace Projekt.ViewModel
{
    [Export(typeof(WorkspaceViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class WorkspaceViewModel : ViewModelBase
    {

        public ObservableCollection<TreeViewItem> HierarchicalAreas { get; set; }

        private Visibility visibilityRead = Visibility.Hidden;
        private Visibility visibilitySave = Visibility.Hidden;

        [Import(typeof(IOpenFilePathService))]
        IOpenFilePathService _openFilePathService { get; set; }
        [Import(typeof(ISaveFilePathService))]
        ISaveFilePathService _saveFilePathService { get; set; }
        [Import(typeof(ReflectionService))]
        ReflectionService _reflectionService { get; set; }
        [Import(typeof(ILoggerService))]
        ILoggerService _logger { get; set; }
        private AssemblyMetadata assemblyMetadata;
        private AssemblyTreeItem treeViewAssemblyMetadata;

        [ImportingConstructor]
        public WorkspaceViewModel()
        {
            HierarchicalAreas = new ObservableCollection<TreeViewItem>();
            SaveDataCommand = new RelayCommand(param => ChangeButtonSave());
            ReadDataCommand = new RelayCommand(param => ChangeButtonRead());
            LoadFromFileDataCommand = new RelayCommand(param => ChangeButtonLoadFromFile());
            if (_logger != null)
                _logger.Log("WorkspaceViewModel created", LogLevel.INFO);
        }
        public void InjectOpenFilePathService(IOpenFilePathService openFilePathService)
        {
            _openFilePathService = openFilePathService;
        }
        public void InjectSaveFilePathService(ISaveFilePathService saveFilePathService)
        {
            _saveFilePathService = saveFilePathService;
        }
        public Visibility ChangeControlButtonReadVisibility
        {
            get { return visibilityRead; }
            set
            {
                if(_logger != null)
                    _logger.Log("Setting ReadButton visibility", LogLevel.INFO);
                visibilityRead = value;
                OnPropertyChanged();
            }
        }

        public Visibility ChangeControlButtonSaveVisibility
        {
            get { return visibilitySave; }
            set
            {
                if (_logger != null)
                    _logger.Log("Setting SaveButton visibility", LogLevel.INFO);
                visibilitySave = value;
                OnPropertyChanged();
            }
        }

        private void TreeViewLoaded()
        {
            TreeViewItem rootItem = treeViewAssemblyMetadata;
            HierarchicalAreas.Add(rootItem);
            if (_logger != null)
                _logger.Log("Treeview loaded", LogLevel.INFO);
        }

        private void SaveToXmlFile()
        {
            if (_logger != null)
                _logger.Log("Trying to save to XML", LogLevel.INFO);
            _reflectionService.Save(assemblyMetadata, SaveFileName);
        }

        public RelayCommand SaveDataCommand
        {
            get;
            private set;
        }
        public RelayCommand ReadDataCommand
        {
            get;
            private set;
        }
        public RelayCommand LoadFromFileDataCommand
        {
            get;
            private set;
        }

        #region ButtonSave
        public void ChangeButtonSave()
        {
            if (_logger != null)
                _logger.Log("Saving started", LogLevel.INFO);
            ButtonSave = "Save Clicked";
            _SaveFileName = _saveFilePathService.FilePath("");
            SaveToXmlFile();
        }
        private string _ButtonSave;
        public String ButtonSave
        {
            get { return _ButtonSave ?? (_ButtonSave = "Save"); }
            set
            {
                if (_logger != null)
                    _logger.Log("Changing status of ButtonSave property", LogLevel.INFO);
                _ButtonSave = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ButtonRead
        public void ChangeButtonRead()
        {
            if (_logger != null)
                _logger.Log("Read Button clicked", LogLevel.INFO);
            _ReadFileName = _openFilePathService.FilePath("");
            ButtonRead = "Read Clicked";

            if (ReadFileName.Contains(".dll"))
            {
                if (_logger != null)
                    _logger.Log("Trying to read .dll file", LogLevel.INFO);
                assemblyMetadata = new AssemblyMetadata(Assembly.LoadFrom(ReadFileName));
            }
            else if (ReadFileName.Contains(".xml"))
            {
                if (_logger != null)
                    _logger.Log("Trying to read .xml file", LogLevel.INFO);
                assemblyMetadata = _reflectionService.Read(ReadFileName);
                foreach (NamespaceMetadata n in assemblyMetadata.Namespaces)
                {
                    foreach (TypeMetadata type in n.Types)
                    {
                        type.CreateDictionary();
                    }
                }
            }
            else
            {
                if (_logger != null) { 
                _logger.Log("Error reading file: " + ReadFileName, LogLevel.ERROR);
                _logger.Log("File type not supported!", LogLevel.ERROR);
                }
                return;
            }

            if (_logger != null)
                _logger.Log("Creating tree view assembly metadata", LogLevel.INFO);
            treeViewAssemblyMetadata = new AssemblyTreeItem(assemblyMetadata);
            TreeViewLoaded();
            ChangeControlButtonSaveVisibility = Visibility.Visible;
            if (_logger != null)
                _logger.Log("Save button set to visible",LogLevel.DEBUG);
        }
        private string _ButtonRead;
        public String ButtonRead
        {
            get { return _ButtonRead ?? (_ButtonRead = "Read"); }
            set
            {
                if (_logger != null)
                    _logger.Log("Changing status of ButtonRead property", LogLevel.INFO);
                _ButtonRead = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ButtonLoadFromFile
        public void ChangeButtonLoadFromFile()
        {
            ButtonLoadFromFile = "Loaded from file";
            if (_logger != null)
                _logger.Log("LoadFromFile invoked", LogLevel.INFO);

            ChangeControlButtonReadVisibility = Visibility.Visible;
            if (_logger != null)
                _logger.Log("Read button is now visible", LogLevel.INFO);
        }
        private String _ButtonLoadFromFile;
        public String ButtonLoadFromFile
        {
            get { return _ButtonLoadFromFile ?? (_ButtonLoadFromFile = "Load from file"); }
            set
            {
                if (_logger != null)
                    _logger.Log("Changing status of ButtonLoadFromFile property", LogLevel.INFO);
                _ButtonLoadFromFile = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ReadFileName;
        private String _ReadFileName;
        public String ReadFileName
        {
            get { return _ReadFileName ?? (_ReadFileName = "Nie wybrano pliku"); }
            set
            {
                if (_logger != null)
                    _logger.Log("Changing status of FileName property", LogLevel.INFO);
                _ReadFileName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region SaveFileName;
        private String _SaveFileName;
        public String SaveFileName
        {
            get { return _SaveFileName ?? (_SaveFileName = "Nie wybrano pliku"); }
            set
            {
                if (_logger != null)
                    _logger.Log("Changing status of FileName property", LogLevel.INFO);
                _SaveFileName = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
