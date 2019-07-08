using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class QualificationModel
    {
        public int Qualification_ID { get; set; }
        public string Q_Name { get; set; }
        public string Course_Name { get; set; }
        public int Institution_ID { get; set; }
        public string Last_Modified { get; set; }

    }
}
