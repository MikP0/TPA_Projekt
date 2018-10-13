using System;
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

namespace Projekt.ViewModel
{
    internal class WorkspaceViewModel : ViewModelBase
    {
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
                visibilityRead = value;
                OnPropertyChanged();
            }
        }

        public Visibility ChangeControlButtonSaveVisibility
        {
            get { return visibilitySave; }
            set
            {
                visibilitySave = value;
                OnPropertyChanged();
            }
        }

        public WorkspaceViewModel()
        {
            HierarchicalAreas = new ObservableCollection<TreeViewItem>();
            SaveDataCommand = new RelayCommand(param => ChangeButtonSave());
            ReadDataCommand = new RelayCommand(param => ChangeButtonRead());
            LoadFromFileDataCommand = new RelayCommand(param => ChangeButtonLoadFromFile());
        }


        public void InitializeData(IDataFiller dataFiller)
        {
            DataLayerExternalSource dataLayerExternalSource = dataFiller.Fill();
            DataLayer = new DataLayer(dataLayerExternalSource);
        }

        private void TreeViewLoaded()
        {
            TreeViewItem rootItem = new TreeViewItem { Name = treeViewAssemblyMetadata.Name, HierarchyReference = treeViewAssemblyMetadata };
            HierarchicalAreas.Add(rootItem);
        }

        private void SaveToXmlFile()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.ShowDialog();
            Serialize.XmlSerialize<AssemblyMetadata>(assemblyMetadata, saveFileDialog.FileName);
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
            ButtonSave = "Save Clicked";
            SaveToXmlFile();
        }
        private string _ButtonSave;
        public String ButtonSave
        {
            get { return _ButtonSave ?? (_ButtonSave = "Save"); }
            set
            {
                _ButtonSave = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ButtonRead
        public void ChangeButtonRead()
        {

            ButtonRead = "Read Clicked";

            if (FileName.Contains(".dll"))
            {
                assemblyMetadata = new AssemblyMetadata(Assembly.LoadFrom(FileName));
            }
            if (FileName.Contains(".xml"))
            {
                assemblyMetadata = Deserialize.XmlDeserialize<AssemblyMetadata>(FileName);
                foreach (NamespaceMetadata n in assemblyMetadata.Namespaces)
                {
                    foreach (TypeMetadata type in n.Types)
                    {
                        type.CreateDictionary();
                    }
                }
            }

            treeViewAssemblyMetadata = new TreeViewAssemblyMetadata(assemblyMetadata);
            TreeViewLoaded();
            ChangeControlButtonSaveVisibility = Visibility.Visible;
        }
        private string _ButtonRead;
        public String ButtonRead
        {
            get { return _ButtonRead ?? (_ButtonRead = "Read"); }
            set
            {
                _ButtonRead = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ButtonLoadFromFile
        public void ChangeButtonLoadFromFile()
        {
            ButtonLoadFromFile = "Load from file Clicked";
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.FileName = openFileDialog.FileName;
            ChangeControlButtonReadVisibility = Visibility.Visible;

        }
        private String _ButtonLoadFromFile;
        public String ButtonLoadFromFile
        {
            get { return _ButtonLoadFromFile ?? (_ButtonLoadFromFile = "Load from file"); }
            set
            {
                _ButtonLoadFromFile = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region FileName;
        private String _FileName;
        public String FileName
        {
            get { return _FileName ?? (_FileName = "Nie wybrano pliku"); }
            set
            {
                _FileName = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
