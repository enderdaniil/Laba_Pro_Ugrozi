using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ugozi_Comparator
{
    public class Paging
    {
        //For holding the data globally.
        public static DataTable fullRecordsDataTable = new DataTable("Full Data");

        //For storing the current page number.
        private static int paging_PageIndex = 1;

        //For storing the Paging Size. Here it is static but you can use a property
        //to expose and update value.
        private static int paging_NoOfRecPerPage = 15;

        //To check the paging direction according to use selection.
        public enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4 };

        public static void ListRecords(DataGrid lstRecords)
        {
            fullRecordsDataTable = ConverterToDataTable.ToDataTable(RecourceHandler.fullRecords);

            paging_PageIndex = 1; //For default

            if (fullRecordsDataTable.Rows.Count > 0)
            {
                DataTable tmpTable = new DataTable();

                //Copying the schema to the temporary table.
                tmpTable = fullRecordsDataTable.Clone();

                //If total record count is greater than page size then import records
                //from 0 to pagesize (here 20)
                //Else import reports from 0 to total record count.
                if (fullRecordsDataTable.Rows.Count >= paging_NoOfRecPerPage)
                {
                    for (int i = 0; i < paging_NoOfRecPerPage; i++)
                    {
                        tmpTable.ImportRow(fullRecordsDataTable.Rows[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < fullRecordsDataTable.Rows.Count; i++)
                    {
                        tmpTable.ImportRow(fullRecordsDataTable.Rows[i]);
                    }
                }

                //Bind the table to the gridview.
                lstRecords.DataContext = tmpTable.DefaultView;

                //Dispose the temporary table.
                tmpTable.Dispose();
            }

        }
        public static void CustomPaging(int mode, DataGrid lstProducts)
        {
            //There is no need for these variables but i created them just for readability
            int totalRecords = fullRecordsDataTable.Rows.Count;
            int pageSize = paging_NoOfRecPerPage;

            //If total record count is less than  the page size then return.
            if (totalRecords <= pageSize)
            {
                return;
            }

            switch (mode)
            {
                case (int)PagingMode.Next:
                    if (totalRecords > (paging_PageIndex * pageSize))
                    {
                        DataTable tmpTable = new DataTable();
                        tmpTable = fullRecordsDataTable.Clone();

                        if (totalRecords >= ((paging_PageIndex * pageSize) + pageSize))
                        {
                            for (int i = paging_PageIndex * pageSize; i <
                                ((paging_PageIndex * pageSize) + pageSize); i++)
                            {
                                tmpTable.ImportRow(fullRecordsDataTable.Rows[i]);
                            }
                        }
                        else
                        {
                            for (int i = paging_PageIndex * pageSize; i < totalRecords; i++)
                            {
                                tmpTable.ImportRow(fullRecordsDataTable.Rows[i]);
                            }
                        }

                        paging_PageIndex += 1;

                        lstProducts.DataContext = tmpTable.DefaultView;
                        tmpTable.Dispose();
                    }
                    break;
                case (int)PagingMode.Previous:
                    if (paging_PageIndex > 1)
                    {
                        DataTable tmpTable = new DataTable();
                        tmpTable = fullRecordsDataTable.Clone();

                        paging_PageIndex -= 1;

                        for (int i = ((paging_PageIndex * pageSize) - pageSize);
                            i < (paging_PageIndex * pageSize); i++)
                        {
                            tmpTable.ImportRow(fullRecordsDataTable.Rows[i]);
                        }

                        lstProducts.DataContext = tmpTable.DefaultView;
                        tmpTable.Dispose();
                    }
                    break;

                case (int)PagingMode.First:
                    paging_PageIndex = 2;
                    CustomPaging((int)PagingMode.Previous, lstProducts);
                    break;

                case (int)PagingMode.Last:
                    paging_PageIndex = (totalRecords / pageSize);
                    CustomPaging((int)PagingMode.Next, lstProducts);
                    break;
            }
        }
    }
}
