using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
    public class TableCheker
    {
		public static bool Check()
        {
			try
			{
				RecourceHandler.originalPath = Directory.GetCurrentDirectory();
				RecourceHandler.originalPathHandler = Directory.GetCurrentDirectory();
				RecourceHandler.copyPathHandler = Directory.GetCurrentDirectory();
                RecourceHandler.copyPath = Directory.GetCurrentDirectory() + @"\copy\thrlist.xlsx";
            }
			catch (UnauthorizedAccessException)
			{
				MessageBox.Show("У вас почему-то нет доступа к файлам (^人^)");
				throw;
			}


			RecourceHandler.originalPath += @"\thrlist.xlsx";

			if (!Directory.Exists(RecourceHandler.originalPathHandler + @"\copy"))
			{
				DirectoryInfo di = Directory.CreateDirectory(RecourceHandler.originalPathHandler + @"\copy");
				RecourceHandler.copyPathHandler = RecourceHandler.originalPathHandler + @"\copy";

                //File.Copy(RecourceHandler.originalPath, );
            }

			if (File.Exists(RecourceHandler.originalPath))
			{
				return true;
			}
			else
			{
				return false;
			}

		}
    }
}
