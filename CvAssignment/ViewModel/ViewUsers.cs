using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvAssignment.ViewModel
{
    public class ViewUsers
    {
        public int Person_ID { get; set; }

        [Display(Name = "Full Name")]
        public string Full_Name { get; set; }

        [Display(Name = "Other Name")]
        public string Other_Name { get; set; }
    }
}