using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel.Composition;
using Projekt.Logic;
using Projekt.Composition;
using Projekt.Logic.Model;

namespace Projekt.ViewModel
{
    [Export(typeof(WorkspaceViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class WorkspaceViewModel : ViewModelBase
    {

        public ObservableCollection<TreeViewItem> HierarchicalAreas { get; set; }

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
        

        private void TreeViewLoaded()
        {
            TreeViewItem rootItem = treeViewAssemblyMetadata;
            HierarchicalAreas.Add(rootItem);
            if (_logger != null)
                _logger.Log("Treeview loaded", LogLevel.INFO);
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

            if (_logger != null)
                _logger.Log("Trying to save to XML", LogLevel.INFO);
            _reflectionService.Save(assemblyMetadata);
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

            ButtonRead = "Read Clicked";

            assemblyMetadata = _reflectionService.Read();

            if (ReadFileName.Contains(".json"))
            {
                if (_logger != null)
                    _logger.Log("Trying to read .json file", LogLevel.INFO);
                foreach (NamespaceMetadata n in assemblyMetadata.Namespaces)
                {
                    foreach (TypeMetadata type in n.Types)
                    {
                        type.CreateDictionary();
                    }
                }
            }

            if (_logger != null)
                _logger.Log("Creating tree view assembly metadata", LogLevel.INFO);
            treeViewAssemblyMetadata = new AssemblyTreeItem(assemblyMetadata);
            TreeViewLoaded();
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
            _ReadFileName = _openFilePathService.FilePath("");

            ButtonLoadFromFile = "Loaded from file";
            if (_logger != null)
                _logger.Log("LoadFromFile invoked", LogLevel.INFO);

            if (ReadFileName.Contains(".dll"))
            {
                if (_logger != null)
                    _logger.Log("Trying to read .dll file", LogLevel.INFO);
                assemblyMetadata = new AssemblyMetadata(Assembly.ReflectionOnlyLoadFrom(ReadFileName));
            }

            treeViewAssemblyMetadata = new AssemblyTreeItem(assemblyMetadata);
            TreeViewLoaded();
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
