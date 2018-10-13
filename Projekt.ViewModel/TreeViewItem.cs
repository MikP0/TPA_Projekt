using log4net;
using Projekt.CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModel
{
    public class TreeViewItem
    {
        private static readonly ILog logger = LogManager.GetLogger("ViewModelAppender");
        public ObservableCollection<TreeViewItem> Children { get; set; }
        public string Name { get; set; }
        public IBuildable HierarchyReference { get; set; }
        private bool wasBuilt;
        private bool isExpanded;

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                if (wasBuilt)
                    return;
                Children.Clear();
                BuildMyself();
                wasBuilt = true;
            }
        }

        public TreeViewItem()
        {
            Children = new ObservableCollection<TreeViewItem>();
            Children.Add(null);
            this.wasBuilt = false;
            logger.Info("TreeViewItem CREATED");
        }


        private void BuildMyself()
        {
            HierarchyReference.Build(Children);
        }

    }
}
