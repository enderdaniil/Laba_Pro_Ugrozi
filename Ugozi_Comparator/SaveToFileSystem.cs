using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using System.Xml.Serialization;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Ugozi_Comparator
{
    public static class SaveToFileSystem
    {
        public static void UploadToFileSystem()
        {
            try
            {
                //File.Copy(RecourceHandler.copyPath, pathToFolder, true);
                //StreamWriter l_writer = null;

                //try
                //{
                //    l_writer = new StreamWriter("ProcInfo.xml", true);
                //    XmlSerializer l_serialier = new XmlSerializer(typeof(string));
                //    l_serialier.Serialize(l_writer, RecourceHandler.originalPath.ToString());
                //}
                //finally
                //{
                //    if (l_writer != null)
                //    {
                //        l_writer.Close();
                //    }
                //}

                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    //create a new Worksheet
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                    //add some text to cell A1
                    worksheet.Cells["A1"].LoadFromCollection(RecourceHandler.fullRecords);

                    //convert the excel package to a byte array
                    byte[] bin = excelPackage.GetAsByteArray();

                    //create a SaveFileDialog instance with some properties
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "Save Excel sheet";
                    saveFileDialog1.Filter = "Excel files|*.xlsx|All files|*.*";
                    saveFileDialog1.FileName = "ExcelSheet_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                    //check if user clicked the save button
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //write the file to the disk
                        File.WriteAllBytes(saveFileDialog1.FileName, bin);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                System.Windows.MessageBox.Show("Хммммм... У вас нет доступа к этому файлу!");
                return;
            }
            catch (ArgumentNullException)
            {
                System.Windows.MessageBox.Show("Хммммм... Вы не выбрали файл, куда сохранять... Не надо так ;)");
                return;
            }
            catch (ArgumentException)
            {
                System.Windows.MessageBox.Show("Хммммм... У вас нет доступа к этому файлу!");
                return;
            }
            catch (PathTooLongException)
            {
                System.Windows.MessageBox.Show("Хммммм... А это ошибка криворукого разраба. Не бейте)) PathToLong");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                System.Windows.MessageBox.Show("Хмм... Места, куда вы хотели сохранить базу данных, не существует!");
                return;
            }
            catch (FileNotFoundException)
            {
                System.Windows.MessageBox.Show("Хмм... Файл куда-то пропал, перезапустите программу!");
                return;
            }
            catch (IOException)
            {
                System.Windows.MessageBox.Show("Хммммм... А это ошибка криворукого разраба. Не бейте)) IO");
                return;
            }
            catch (NotSupportedException)
            {
                System.Windows.MessageBox.Show("Хммммм... А это ошибка криворукого разраба. Не бейте)) NotSupp");
                return;
            }

            //System.Windows.MessageBox.Show($"База данных успешно сохранена по пути: {pathToFolder}");
        }
    }
}
