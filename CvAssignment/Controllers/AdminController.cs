using BL;
using BL.Interfaces;
using CvAssignment.Interfaces;
using CvAssignment.Services;
using CvAssignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvAssignment.Controllers
{
    

    public class AdminController : Controller
    {
        private readonly ILogicBL _logicBL = new BLogic(null);
        private readonly IService _Service = new ConversionService();


       //For test
       

    
        // GET: Admin
        public AdminController()
        {

        }
        public AdminController(ILogicBL logicBL, IService service)
        {
            _logicBL = logicBL;
            _Service = service;
        }

        public ActionResult CreateNewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewUser(UsersViewModel User_View_Details)
        {
           
            Session["User_ID"] = _Service.CreateNewUser(User_View_Details);
            return RedirectToAction("CreatePersonalDetails","Admin");
        }


        public ActionResult CreatePersonalDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePersonalDetails(PersonalViewModel p_model)
        {
            p_model.Person_ID = Convert.ToInt32(Session["User_ID"]);
            _Service.CreateNewPersonalDetail(p_model);
            
            return RedirectToAction("CreateEducation","Admin");
        }


        public ActionResult CreateInstitutionDetails()
        {
            return View();
        }

        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(List<EducationModel> E_VIewModel)
        {
            return View();
        }

        public ActionResult CreateSkills()
        {
            Session["User_ID"] = "1";
            return View(_Service.GetSkillsView(Convert.ToInt32(Session["User_ID"])));
        }

        [HttpPost]
        public string SaveSkills(List<SkillsViewModel> SkillsModel)
        {
            Session["User_ID"] = "1";
            bool response = _Service.SaveSkills(SkillsModel, Convert.ToInt32(Session["User_ID"]));
            if (response == true)
            {
                return "Successfully Saved";
            }
            else
                return "You have already saved this skill";
            
        }

        [HttpPost]
        public string UpdateList()
        {
            CreateSkills();
            return "true";
        }

        [HttpPost]
        public string SaveEducationDetails(List<EducationModel> EducationModel)
        {
           
            _Service.CreateEducationDetails(EducationModel, Convert.ToInt32(Session["User_ID"]));
            return "true";
        }

        public ActionResult ViewUsers()
        {
            
            return View(_Service.GetViewUsers());
        }

        public ActionResult EditPersonalDetails(int id)
        {
            Session["EditUserID"] = id;
            return View(_Service.GetPersonalDetailsView(id));
        }

        [HttpPost]
        public ActionResult EditPersonalDetails(PersonalViewModel p_model)
        {
            p_model.Person_ID = Convert.ToInt32(Session["EditUserID"]);
            _Service.EditPersonalViewModel(p_model);
            return RedirectToAction("ViewUsers", "Admin");
        }

        public ActionResult ShowSkillsAcquired()
        {
            Session["User_ID"] = "1";
            return View(_Service.AcquiredSkills(Convert.ToInt32(Session["User_ID"])));
        }

        public ActionResult AddNewSkill()
        {
            Session["User_ID"] = "1";
            return View(_Service.GetSkillsView(Convert.ToInt32(Session["User_ID"])));
        }

        [HttpPost]
        public string CreateNewSkill(string SkillName)
        {
            Session["User_ID"] = "1";
            bool response = _logicBL.CreateNewSkill(SkillName, Convert.ToInt32(Session["User_ID"]));

            if (response == true)
            {
                return "New Skills Saved Successfully";
            }
            else
                return "Skills already exist in Dropdown List";
        }
    }
}