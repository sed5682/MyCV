using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ModuleModel
    {
        public int Module_ID { get; set; }
        public string Module_Name { get; set; }
        public float Module_Marks { get; set; }
        public string Module_Level { get; set; }
        public int Qualification_ID { get; set; }
        public int Person_ID { get; set; }
        public string Last_Modified { get; set; }

    }
}
