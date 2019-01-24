using Projekt.ViewModel;
using System.ComponentModel.Composition;

namespace Projekt_Ver_2_0
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class GraphicalOpenFilePathService : IOpenFilePathService
    {
        public static GraphicalOpenFilePathService Create()
        {
            return new GraphicalOpenFilePathService();
        }
        public string FilePath(string defaultPath)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            return defaultPath;
        }
    }
}
