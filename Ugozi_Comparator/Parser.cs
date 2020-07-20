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
using System.IO;
using System.Collections.ObjectModel;
using OfficeOpenXml;
using System.Data;

namespace Ugozi_Comparator
{
    public static class Parser
    {
        public static DataTable FillDataTable()
        {
            FileInfo file = new FileInfo(RecourceHandler.originalPath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<string> excelData = new List<string>();

            //read the Excel file as byte array
            byte[] bin = File.ReadAllBytes(RecourceHandler.originalPath);

            //create a new Excel package in a memorystream
            MemoryStream stream = new MemoryStream(bin);
            ExcelPackage excelPackage = new ExcelPackage(stream);

            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];

            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }

            //create a list to hold the column names
            List<string> columnNames = new List<string>();

            //needed to keep track of empty column headers
            int currentColumn = 1;

            //loop all columns in the sheet and add them to the datatable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();

                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }

                //add the column name to the list to count the duplicates
                columnNames.Add(columnName);

                //count the duplicate column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTable
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }

                //add the column to the datatable
                dt.Columns.Add(columnName);

                currentColumn++;
            }

            //start adding the contents of the excel file to the datatable
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();

                //loop all cells in the row
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }

                dt.Rows.Add(newRow);
            }

            return dt;
        }


        public static ObservableCollection<FullRecord> FillFullCollection(string path)
        {
            ObservableCollection<FullRecord> localFullRecords = new ObservableCollection<FullRecord>();

            byte[] bin = File.ReadAllBytes(path);

            bool isPrivacyViolent;
            bool isIntegrityViolent;
            bool isAccessViolent;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (MemoryStream stream = new MemoryStream(bin))
            {
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
                {
                    foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                    {
                        //loop all rows
                        for (int i = worksheet.Dimension.Start.Row + 2; i <= worksheet.Dimension.End.Row; i++)
                        {
                            isPrivacyViolent = boolConverter(Convert.ToInt32(worksheet.Cells[i, 6].Value.ToString()));
                            isIntegrityViolent = boolConverter(Convert.ToInt32(worksheet.Cells[i, 7].Value.ToString()));
                            isAccessViolent = boolConverter(Convert.ToInt32(worksheet.Cells[i, 8].Value.ToString()));

                            localFullRecords.Add(new FullRecord(worksheet.Cells[i, 1].Value.ToString(), worksheet.Cells[i, 2].Value.ToString(),
                                                                worksheet.Cells[i, 3].Value.ToString(), worksheet.Cells[i, 4].Value.ToString(),
                                                                worksheet.Cells[i, 5].Value.ToString(), isPrivacyViolent,
                                                                isIntegrityViolent, isAccessViolent));
                        }
                    }
                }
            }

            return localFullRecords;
        }

        public static List<ObservableCollection<FullRecord>> ListingFullRecordCollection(ObservableCollection<FullRecord> fullRecords)
        {
            List<ObservableCollection<FullRecord>> list = new List<ObservableCollection<FullRecord>>();

            int i = 0;

            for (i = 0; i < fullRecords.Count / 15; i++)
            {
                list.Add(new ObservableCollection<FullRecord>());
                for (int j = 0 + (i * 15); j < 15 * (i + 1); j++)
                {
                    list[i].Add(fullRecords[j]);
                }
            }

            if (fullRecords.Count >= (i) * 15)
            {
                list.Add(new ObservableCollection<FullRecord>());

                for (i = i * 15 + 1; i < fullRecords.Count; i++)
                {
                    list[list.Count - 1].Add(fullRecords[i]);
                }
            }

            return list;
        }

        public static ObservableCollection<SmallRecord> FillSmallCollection(string path)
        {
            ObservableCollection<SmallRecord> localSmallRecords = new ObservableCollection<SmallRecord>();

            byte[] bin = File.ReadAllBytes(path);

            bool isPrivacyViolent;
            bool isIntegrityViolent;
            bool isAccessViolent;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (MemoryStream stream = new MemoryStream(bin))
            {
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
                {
                    foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                    {
                        //loop all rows
                        for (int i = worksheet.Dimension.Start.Row + 2; i <= worksheet.Dimension.End.Row; i++)
                        {
                            isPrivacyViolent = boolConverter(Convert.ToInt32(worksheet.Cells[i, 6].Value.ToString()));
                            isIntegrityViolent = boolConverter(Convert.ToInt32(worksheet.Cells[i, 7].Value.ToString()));
                            isAccessViolent = boolConverter(Convert.ToInt32(worksheet.Cells[i, 8].Value.ToString()));

                            localSmallRecords.Add(new SmallRecord(worksheet.Cells[i, 2].Value.ToString(), worksheet.Cells[i, 1].Value.ToString()));
                        }
                    }
                }
            }

            return localSmallRecords;
        }

        public static bool boolConverter(int a)
        {
            if (a == 1)
            {
                return true;
            }
            return false;
        }
    }
}
