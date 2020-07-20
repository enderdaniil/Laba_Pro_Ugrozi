using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ugozi_Comparator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isFileDownloaded = TableCheker.Check();

            if (isFileDownloaded)
            {
                RecourceHandler.fullRecords = Parser.FillFullCollection(RecourceHandler.originalPath);
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
            }
            else
            {
                BeginDownloadWindow downloadWindow = new BeginDownloadWindow();
                downloadWindow.Show();
            }

            this.Close();
        }
    }
}
