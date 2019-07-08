using BL;
using BL.Interfaces;
using CvAssignment.Interfaces;
using CvAssignment.Services;
using System.Web.Mvc;

namespace CvAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogicBL _logicBL = new BLogic(null);
        private readonly IService _Service = new ConversionService();
        static int user_ID = 1;

        public HomeController()
        {

        }

        public HomeController(ILogicBL logicBL, IService service)
        {
            _logicBL = logicBL;
            _Service = service;
        }

        public ActionResult Index()
        {
            var username = _logicBL.GetUserName(user_ID);

            return View(username);
        }


        public ActionResult PersonalDetails()
        {

            var P_details = _logicBL.GetPersonalDetails(user_ID);
            return View(P_details);
        }


        public ActionResult Education()
        {
            //  var Education_Details = _logicBL.GetEducationDetailsList(user_ID);
            return View();
        }


        public ActionResult Skills()
        {

            //  var Skills_Working_Details = _logicBL.GetSkills_WorkingExperienceList(user_ID);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


    }
}