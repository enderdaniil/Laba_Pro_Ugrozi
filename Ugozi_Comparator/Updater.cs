using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Windows;

namespace Ugozi_Comparator
{
    public class Updater
    {
        public static bool UpdateInformation()
        {
            try
            {
                RecourceHandler.copyPath = Directory.GetCurrentDirectory() + @"\copy\thrlist.xlsx";
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("У вас почему-то нет доступа к файлам (^人^)");
                return false;
            }

            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(new Uri("https://bdu.fstec.ru/files/documents/thrlist.xlsx"), RecourceHandler.copyPath);
                }

                catch (WebException)
                {
                    MessageBox.Show("Ой, Ой, у вас какие-то проблемы с Интернетом...");
                    return false;
                }
                catch (NoFileException e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Хмм, проблема с файлами...");
                    return false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Что-то внутри пошло не так... Походу разраб криворукий ;)");
                    return false;
                }
            }

            //File.Delete(RecourceHandler.copyPath);

            return true;
        }

        public static void Update()
        {
            ObservableCollection<UpdateRecord> updateInfo = new ObservableCollection<UpdateRecord>();

            ObservableCollection<FullRecord> localfullRecords = RecourceHandler.fullRecords;
            ObservableCollection<FullRecord> localNewRecords = Parser.FillFullCollection(RecourceHandler.copyPath);

            using (var client = new WebClient())
            {
                client.DownloadFile(new Uri("https://bdu.fstec.ru/files/documents/thrlist.xlsx"), RecourceHandler.originalPath);
            } 

            int i = 0;
            for (i = 0; i < localfullRecords.Count; i++)
			{
                if (localfullRecords[i] != localNewRecords[i])
                {
                    localfullRecords[i].CompareTo(localNewRecords[i], RecourceHandler.updateRecords);
                }  
			}

            if (i < localNewRecords.Count - 1)
            {
                for (i = i + 1; i < localNewRecords.Count; i++)
                {
                    updateInfo.Add(new UpdateRecord("Новая запись", "", $"{localNewRecords[i].ToString()}"));
                }
            }

            updateInfo.Add(new UpdateRecord("Общее количество обновлённий", "", $"{updateInfo.Count}"));

            RecourceHandler.updateRecords = updateInfo;

            for (int j = 0; j < updateInfo.Count; j++)
            {
                RecourceHandler.stringedUpdateRecords.Add(updateInfo[j].ToString());
            }
        }

        public static void AutoUpdate()
        {
            bool waiter = false;

            DateTime dateTime = DateTime.Now;

            while (true)
            {
                dateTime = DateTime.Now;
                if (dateTime.Hour == 12 && !waiter)
                {
                    bool success = Updater.UpdateInformation();

                    if (success)
                    {
                        Updater.Update();
                        if (RecourceHandler.updateRecords.Count > 1)
                        {
                            SuccessUpdate successUpdate = new SuccessUpdate();
                            successUpdate.Show();
                        }
                        else
                        {
                            NoNewInformationUpdate noNewInformationUpdate = new NoNewInformationUpdate();
                            noNewInformationUpdate.Show();
                        }
                    }
                    else
                    {
                        UnSuccessUpdate unSuccessUpdate = new UnSuccessUpdate();
                        unSuccessUpdate.Show();
                    }

                    waiter = true;

                    if (dateTime.Hour == 8)
                    {
                        waiter = false;
                    }
                }
            }

        }

        private class NoFileException : Exception
        {
            public override string Message => "Почему то пропал файл...";
        }
    }
}
