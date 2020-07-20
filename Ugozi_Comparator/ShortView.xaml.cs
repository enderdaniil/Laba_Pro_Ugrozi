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
using System.Windows.Shapes;

namespace Ugozi_Comparator
{
    /// <summary>
    /// Логика взаимодействия для ShortView.xaml
    /// </summary>
    public partial class ShortView : Window
    {
        public ShortView()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Close();
        }

        private void Short_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ShortGrid.ItemsSource = RecourceHandler.smallRecords;
            ShortGrid.IsReadOnly = true;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
