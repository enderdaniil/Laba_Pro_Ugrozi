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
using System.Collections;
using System.Data;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;
using System.IO;

namespace Ugozi_Comparator
{
    /// <summary>
    /// Логика взаимодействия для FullView.xaml
    /// </summary>
    public partial class FullView : Window
    {
        static int currentPage = 0;

        public FullView()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();

            this.Close();
        }

        private void On_DataGrid_Load(object sender, RoutedEventArgs e)
        {
            FullDataGrid.ItemsSource = RecourceHandler.parsedFullRecords[currentPage];
            FullDataGrid.IsReadOnly = true;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage == 0)
            {
                System.Windows.MessageBox.Show("Это первая страница! Вы не можете нажать НАЗАД");
                return;
            }

            currentPage--;
            FullDataGrid.ItemsSource = RecourceHandler.parsedFullRecords[currentPage];
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage == RecourceHandler.parsedFullRecords.Count - 1)
            {
                System.Windows.MessageBox.Show("Это последняя страница! Вы не можете нажать ВПЕРЁД");
                return;
            }

            currentPage++;
            FullDataGrid.ItemsSource = RecourceHandler.parsedFullRecords[currentPage];
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //Saving saving = new Saving();
            //saving.Show();

            //this.Close();


            ////var dlg = new CommonOpenFileDialog();

            ////try
            ////{
            ////    dlg.Title = "Выбор папки для сохранения";
            ////    dlg.IsFolderPicker = true;

            ////    dlg.AddToMostRecentlyUsedList = false;
            ////    dlg.AllowNonFileSystemItems = false;
            ////    dlg.EnsureFileExists = true;
            ////    dlg.EnsurePathExists = true;
            ////    dlg.EnsureReadOnly = false;
            ////    dlg.EnsureValidNames = true;
            ////    dlg.Multiselect = false;
            ////    dlg.ShowPlacesList = true;
            ////    dlg.RestoreDirectory = true;


            ////    if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            ////    {
            ////        var folder = dlg.FileName;
            ////        // Do something with selected folder string
            ////        SaveToFileSystem.UploadToFileSystem(folder);
            ////    }
            ////}
            ////finally
            ////{
            ////    dlg.Dispose();
            ////}


            //FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            //DialogResult result = folderBrowser.ShowDialog();

            //if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            //{
                //string[] files = Directory.GetFiles(folderBrowser.SelectedPath);
                //System.Windows.MessageBox.Show(folderBrowser.SelectedPath + "\\");
                SaveToFileSystem.UploadToFileSystem();
            //}
        }
    }
}
