using Projekt.CommonInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Ver_2_0
{
    class GraphicalSaveFilePathService : ISaveFilePathService
    {
        public static GraphicalSaveFilePathService Create()
        {
            return new GraphicalSaveFilePathService();
        }
        public string FilePath(string defaultPath)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName ?? defaultPath;
        }
    }
}
