using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using log4net;

namespace Projekt_Ver_2_0
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog logger = LogManager.GetLogger("ViewModelLogger");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickLoadFromFile(object sender, RoutedEventArgs e)
        {
            if(logger.IsInfoEnabled)
            {
                logger.Info("Button load from file clicked");
            }
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ReadPath.Content = openFileDialog.FileName;
            }
        }
        private void ButtonClickSaveToFile(object sender, RoutedEventArgs e)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info("Button save to file clicked");
            }
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.ShowDialog();
            SavePath.Content = saveFileDialog.FileName;
        }
    }
}
