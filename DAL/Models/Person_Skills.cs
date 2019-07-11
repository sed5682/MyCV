using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Person_Skills
    {
        public int Person_SkillsID { get; set; }
        public int SkillsID { get; set; }
        public int Person_ID { get; set; }
        public DateTime EffectiveStart { get; set; }
        public DateTime EffectiveEnd { get; set; }

        public string SkillsName { get; set; }

    }
}
