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

namespace Projekt.ViewModel
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class WorkspaceViewModel : ViewModelBase
    {

        private static readonly ILog logger = LogManager.GetLogger("ViewModelLogger");

        public ObservableCollection<TreeViewItem> HierarchicalAreas { get; set; }

        private Visibility visibilityRead = Visibility.Hidden;
        private Visibility visibilitySave = Visibility.Hidden;

        [Import(typeof(IOpenFilePathService))]
        IOpenFilePathService _openFilePathService { get; set; }
        [Import(typeof(ISaveFilePathService))]
        ISaveFilePathService _saveFilePathService { get; set; }
        [Import(typeof(IDataRepositoryService))]
        IDataRepositoryService _DataRepositoryService { get; set; }
        private AssemblyMetadata assemblyMetadata;
        private AssemblyTreeItem treeViewAssemblyMetadata;

        [ImportingConstructor]
        public WorkspaceViewModel()
        {
            HierarchicalAreas = new ObservableCollection<TreeViewItem>();
            SaveDataCommand = new RelayCommand(param => ChangeButtonSave());
            ReadDataCommand = new RelayCommand(param => ChangeButtonRead());
            LoadFromFileDataCommand = new RelayCommand(param => ChangeButtonLoadFromFile());
            if (logger.IsInfoEnabled)
                logger.Info("WorkspaceViewModel created");
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
                if (logger.IsInfoEnabled)
                    logger.Info("Setting ReadButton visibility");
                visibilityRead = value;
                OnPropertyChanged();
            }
        }

        public Visibility ChangeControlButtonSaveVisibility
        {
            get { return visibilitySave; }
            set
            {
                if (logger.IsInfoEnabled)
                    logger.Info("Setting SaveButton visibility");
                visibilitySave = value;
                OnPropertyChanged();
            }
        }

        private void TreeViewLoaded()
        {
            TreeViewItem rootItem = treeViewAssemblyMetadata;
            HierarchicalAreas.Add(rootItem);
            if (logger.IsInfoEnabled)
                logger.Info("Treeview loaded");
        }

        private void SaveToXmlFile()
        {
            if (logger.IsInfoEnabled)
                logger.Info("Trying to save to XML");

            _DataRepositoryService.Save(assemblyMetadata, SaveFileName);
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
            if (logger.IsInfoEnabled)
                logger.Info("Saving started");
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
                if (logger.IsInfoEnabled)
                    logger.Info("Changing status of ButtonSave property");
                _ButtonSave = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ButtonRead
        public void ChangeButtonRead()
        {
            if (logger.IsInfoEnabled)
                logger.Info("Read Button clicked");
            _ReadFileName = _openFilePathService.FilePath("");
            ButtonRead = "Read Clicked";

            if (ReadFileName.Contains(".dll"))
            {
                if (logger.IsInfoEnabled)
                    logger.Info("Trying to read .dll file");

                assemblyMetadata = new AssemblyMetadata(Assembly.LoadFrom(ReadFileName));
            }
            else if (ReadFileName.Contains(".xml"))
            {
                if (logger.IsInfoEnabled)
                    logger.Info("Trying to read .xml file");

                assemblyMetadata = _DataRepositoryService.Read(ReadFileName);
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
                if (logger.IsErrorEnabled)
                {
                    logger.Error("Error reading file: " + ReadFileName);
                    logger.Error("File type not supported!");
                }
                return;
            }

            if (logger.IsInfoEnabled)
                logger.Info("Creating tree view assembly metadata");
            treeViewAssemblyMetadata = new AssemblyTreeItem(assemblyMetadata);
            TreeViewLoaded();
            ChangeControlButtonSaveVisibility = Visibility.Visible;
            if (logger.IsDebugEnabled)
                logger.Debug("Save button set to visible");
        }
        private string _ButtonRead;
        public String ButtonRead
        {
            get { return _ButtonRead ?? (_ButtonRead = "Read"); }
            set
            {
                if (logger.IsInfoEnabled)
                    logger.Info("Changing status of ButtonRead property");
                _ButtonRead = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ButtonLoadFromFile
        public void ChangeButtonLoadFromFile()
        {
            ButtonLoadFromFile = "Loaded from file";
            if (logger.IsInfoEnabled)
            {
                logger.Info("LoadFromFile invoked");
            }
            ChangeControlButtonReadVisibility = Visibility.Visible;
            if (logger.IsInfoEnabled)
                logger.Info("Read button is now visible");
        }
        private String _ButtonLoadFromFile;
        public String ButtonLoadFromFile
        {
            get { return _ButtonLoadFromFile ?? (_ButtonLoadFromFile = "Load from file"); }
            set
            {
                if (logger.IsInfoEnabled)
                    logger.Info("Changing status of ButtonLoadFromFile property");
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
                if (logger.IsInfoEnabled)
                    logger.Info("Changing status of FileName property");
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
                if (logger.IsInfoEnabled)
                    logger.Info("Changing status of FileName property");
                _SaveFileName = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
