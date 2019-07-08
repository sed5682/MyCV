using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvAssignment.ViewModel
{
    public class UsersViewModel
    {
        public int Person_ID { get; set; }
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}