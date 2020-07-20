using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Windows;


namespace Ugozi_Comparator
{
    class Uploader
    {
        public static bool success = false;
        public static void DownloadFile()
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(new Uri("https://bdu.fstec.ru/files/documents/thrlist.xlsx"), RecourceHandler.originalPath);
                }
                catch (WebException)
                {
                    MessageBox.Show("Ой, Ой, у вас какие-то проблемы с Интернетом...");
                    return;
                }
                success = true;
            }
        }
    }
}
