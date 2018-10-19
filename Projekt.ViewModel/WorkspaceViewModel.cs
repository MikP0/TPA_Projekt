﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Model;
using Projekt.Data;
using Projekt.CommonInterfaces;
using Projekt.Fillers;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Projekt.ViewModel.TreeViewTemplate;
using Projekt.Model.Reflection;
using System.Reflection;
using System.Windows.Forms;
using System.Windows;
using log4net;

namespace Projekt.ViewModel
{
    internal class workspaceViewModel : ViewModelBase
    {

        private static readonly ILog logger = LogManager.GetLogger("ViewModelLogger");

        public ObservableCollection<TreeViewItem> HierarchicalAreas { get; set; }

        private Visibility visibilityRead = Visibility.Hidden;
        private Visibility visibilitySave = Visibility.Hidden;

        internal DataLayer DataLayer;

        private AssemblyMetadata assemblyMetadata;
        private TreeViewAssemblyMetadata treeViewAssemblyMetadata;

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

        public workspaceViewModel()
        {
            HierarchicalAreas = new ObservableCollection<TreeViewItem>();
            SaveDataCommand = new RelayCommand(param => ChangeButtonSave());
            ReadDataCommand = new RelayCommand(param => ChangeButtonRead());
            LoadFromFileDataCommand = new RelayCommand(param => ChangeButtonLoadFromFile());
            if (logger.IsInfoEnabled)
                logger.Info("WorkspaceViewModel created");
        }


        public void InitializeData(IDataFiller dataFiller)
        {
            DataLayerExternalSource dataLayerExternalSource = dataFiller.Fill();
            DataLayer = new DataLayer(dataLayerExternalSource);
            if (logger.IsInfoEnabled)
                logger.Info("Data initialized");
        }

        private void TreeViewLoaded()
        {
            TreeViewItem rootItem = new TreeViewItem { Name = treeViewAssemblyMetadata.Name, HierarchyReference = treeViewAssemblyMetadata };
            HierarchicalAreas.Add(rootItem);
            if (logger.IsInfoEnabled)
                logger.Info("Treeview loaded");
        }

        private void SaveToXmlFile()
        {
            if (logger.IsInfoEnabled)
                logger.Info("Trying to save to XML");

            Serialize.XmlSerialize<AssemblyMetadata>(assemblyMetadata, SaveFileName);
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
                logger.Info("Save Button clicked");
            ButtonSave = "Save Clicked";
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

                assemblyMetadata = Deserialize.XmlDeserialize<AssemblyMetadata>(ReadFileName);
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
            treeViewAssemblyMetadata = new TreeViewAssemblyMetadata(assemblyMetadata);
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
            ButtonLoadFromFile = "Load from file Clicked";
            if (logger.IsInfoEnabled)
            {
                logger.Info("LoadFromFile button clicked");
                logger.Info("Opening file dialog");
            }
//            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
//            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                if (logger.IsInfoEnabled)
//                    logger.Info("File dialog status is OK");
//                this.FileName = openFileDialog.FileName;
//            }
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
