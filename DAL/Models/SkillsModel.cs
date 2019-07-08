using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SkillsModel
    {
        public int Skills_ID { get; set; }
        public string Skills_Details { get; set; }
        public string Skills_Type { get; set; }
        public int Person_ID { get; set; }
        public string Last_Modified { get; set; }

    }
}
