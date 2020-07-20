using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugozi_Comparator
{
    public class SmallRecord
    {
        public string Short_Naming { get; set; }
        public string UBI_Name { get; set; }
        public string UBI_ID { get; set; }

        public SmallRecord() { }

        public SmallRecord(string name, string id)
        {
            UBI_Name = name;
            UBI_ID = id;
            Short_Naming = $"УБИ.{this.UBI_ID}";
        }

        public SmallRecord(FullRecord a)
        {
            this.UBI_Name = a.UBI_Name;
            this.UBI_ID = a.UBI_ID;
            this.Short_Naming = $"УБИ.{a.UBI_ID}";
        }

        public override string ToString()
        {
            return $"УБИ.{this.UBI_ID}";
        }
    }
}
