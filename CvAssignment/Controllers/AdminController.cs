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


    //    static int user_ID = 1;

    
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


    }
}