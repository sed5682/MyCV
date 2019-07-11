using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvAssignment.ViewModel
{
    public class SkillsAcquired
    {
        public string Acquired { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime EffectiveStart {
            get;
                //string start = EffectiveStart.ToString();
                //return DateTime.ParseExact(start, "dd/mm/yyyy", null);


            set;
        }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EffectiveEnd { get; set; }
    }
}