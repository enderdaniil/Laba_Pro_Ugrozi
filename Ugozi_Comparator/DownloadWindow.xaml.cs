using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ugozi_Comparator
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class BeginDownloadWindow : Window
    {
        public BeginDownloadWindow()
        {
            InitializeComponent();
        }

        private void NO(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }

        private void YES(object sender, RoutedEventArgs e)
        {
            Uploader.DownloadFile();
            RecourceHandler.fullRecords = Parser.FillFullCollection(RecourceHandler.originalPath);

            if (Uploader.success)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();

                this.Close();
            }
            else
            {
                StartWindow startWindow = new StartWindow();
                startWindow.Show();
                this.Close();
            }
        }

        
    }
}
