using Projekt.CommonInterfaces;
using System.ComponentModel.Composition;

namespace Projekt_Ver_2_0
{
    [Export(typeof(ISaveFilePathService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
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
