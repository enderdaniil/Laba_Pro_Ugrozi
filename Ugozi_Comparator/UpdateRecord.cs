using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugozi_Comparator
{
    public class UpdateRecord
    {
        public string PointOfUpdate { get; set; }
        public string OldVersion { get; set; }
        public string NewVersion { get; set; }
        
        public UpdateRecord(string pointOfUpdate, string oldVersion, string newVersion)
        {
            PointOfUpdate = pointOfUpdate;
            OldVersion = oldVersion;
            NewVersion = newVersion;
        }

        public override string ToString()
        {
            return $"{PointOfUpdate}: {OldVersion} -> {NewVersion}";
        }
    }
}
