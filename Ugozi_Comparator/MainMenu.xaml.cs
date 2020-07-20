using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Ugozi_Comparator
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            Thread thread = new Thread(new ThreadStart(Updater.AutoUpdate));
            thread.Start();
        }

        private void Full_Records_Check(object sender, RoutedEventArgs e)
        {
            RecourceHandler.fullRecords = Parser.FillFullCollection(RecourceHandler.originalPath);
            RecourceHandler.parsedFullRecords = Parser.ListingFullRecordCollection(RecourceHandler.fullRecords);
            FullView fullView = new FullView();
            fullView.Show();
            this.Close();
        }

        private void Small_Records_Check(object sender, RoutedEventArgs e)
        {
            RecourceHandler.smallRecords = Parser.FillSmallCollection(RecourceHandler.originalPath);
            ShortView shortView = new ShortView();
            shortView.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            bool success = Updater.UpdateInformation();

            if (success)
            {
                Updater.Update();
                if (RecourceHandler.updateRecords.Count > 1)
                {
                    SuccessUpdate successUpdate = new SuccessUpdate();
                    successUpdate.Show();
                    this.Close();
                }
                else
                {
                    NoNewInformationUpdate noNewInformationUpdate = new NoNewInformationUpdate();
                    noNewInformationUpdate.Show();
                    this.Close();
                }
            }
            else
            {
                UnSuccessUpdate unSuccessUpdate = new UnSuccessUpdate();
                unSuccessUpdate.Show();
                this.Close();
            }
        }

    }
}
