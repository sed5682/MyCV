using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvAssignment.ViewModel
{
    public class SkillsViewModel
    {

        //public IEnumerable<SkillsModel> SkillList {get; set; }

        public int SkillsID { get; set; }
        public string SkillsName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime EffectiveStart { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EffectiveEnd { get; set; }

        // public type SkillsType { get; set; }

        // public List<string> AcquiredSkills{ get; set; }

        // public List<SelectListItem> skillViews { get; set; }
        //{
        //skillViews.Add(new SelectListItem()
        //{
        //    Value = skills.SkillsID.ToString(),
        //    Text = skills.SkillsName

        //});

    }

}
    
    

    //public enum type
    //{
    //    Personal,
    //    Technical
    //}
