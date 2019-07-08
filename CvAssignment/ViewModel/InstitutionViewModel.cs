using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvAssignment.ViewModel
{
    public class InstitutionViewModel
    {
        public int Institutiton_ID { get; set; }

        [Required]
        [Display(Name = "Institution Name")]
        public string Institution_Name { get; set; }
        public int Person_ID { get; set; }
        public string Last_Modified { get; set; }
    }
}