using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Data;

namespace Ugozi_Comparator
{
    public static class RecourceHandler
    {
        public static ObservableCollection<FullRecord> fullRecords = new ObservableCollection<FullRecord>();
        public static List<ObservableCollection<FullRecord>> parsedFullRecords = new List<ObservableCollection<FullRecord>>();

        public static ObservableCollection<SmallRecord> smallRecords = new ObservableCollection<SmallRecord>();

        public static ObservableCollection<UpdateRecord> updateRecords = new ObservableCollection<UpdateRecord>();
        public static ObservableCollection<string> stringedUpdateRecords = new ObservableCollection<string>();
        
        public static string copyPath;
        public static string copyPathHandler;

        public static string originalPath;
        public static string originalPathHandler;
    }
}
