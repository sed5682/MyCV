using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CvAssignment.ViewModel
{
    public class SkillsViewModel
    {
        
        //public IEnumerable<SkillsModel> SkillList {get; set; }

        public int SkillsID { get; set; }
        public string SkillsName { get; set; }

        // public type SkillsType { get; set; }

    }
    
    

    //public enum type
    //{
    //    Personal,
    //    Technical
    //}
}