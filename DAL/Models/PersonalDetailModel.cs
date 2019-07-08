using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PersonalDetailModel
    {
        public int Person_ID { get; set; }
        public string Full_Name { get; set; }
        public string Other_Name { get; set; }
        public string P_Address { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }
        public string Last_Modified { get; set; }

    }
}
