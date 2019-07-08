using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvAssignment.ViewModel
{
    public class PersonalViewModel
    {
        public int Person_ID { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5,ErrorMessage ="The Name must be filled")]
        [Display(Name = "Full Name")]
        public string Full_Name { get; set; }
        [Display(Name = "Other Name")]
        public string Other_Name { get; set; }

        [Display(Name = "Address")]
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "The Address must be filled")]
        public string P_Address { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email_Address { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone_Number { get; set; }
    }
}