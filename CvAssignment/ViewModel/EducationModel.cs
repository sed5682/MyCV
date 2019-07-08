using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvAssignment.ViewModel
{
    public class EducationModel
    {
        public int Institutiton_ID { get; set; }
        public int Person_ID { get; set; }
        public int Qualification_ID { get; set; }
        public int Module_ID { get; set; }

        [Required]
        [Display(Name = "Institution Name")]
        public string Institution_Name { get; set; }

        [Required]
        [Display(Name = "Qualifications")]
        public string Q_Name { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string Course_Name { get; set; }

        [Required]
        [Display(Name = "Module Name")]
        public string Module_Name { get; set; }

        [Required]
        [Display(Name = "Marks")]
        public float Module_Marks { get; set; }

        [Required]
        [Display(Name = "Level")]
        public string Module_Level { get; set; }
        public string Last_Modified { get; set; }



    }
}