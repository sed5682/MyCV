

using BL;
using BL.Interfaces;
using CvAssignment.Interfaces;
using CvAssignment.ViewModel;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CvAssignment.Services
{
    public class ConversionService : IService
    {
        private readonly ILogicBL _logicBL;
        private readonly IHomeDAL _homeDAL;

       static string user_Name = "Steven";

        public ConversionService()
        {
            _logicBL = new BLogic(null);
            _homeDAL = new HomeDAL();
        }

        public PersonalDetailModel GetUserName(int User_ID)
        {

            PersonalDetailModel name = _homeDAL.GetPersonalDetails().Where(user => user.Person_ID.Equals(User_ID)).Select(x => new PersonalDetailModel
                {
                    Full_Name = x.Full_Name
                }).FirstOrDefault();

                return name;
  
        }

        public PersonalDetailModel GetPersonalDetails(int User_ID)
        {
            PersonalDetailModel P_Details = _homeDAL.GetPersonalDetails().Where(user => user.Person_ID.Equals(User_ID)).Select(x => new PersonalDetailModel
            {
                Full_Name = x.Full_Name,
                Email_Address = x.Email_Address,
                Other_Name =x.Other_Name,
                P_Address = x.P_Address,
                Phone_Number = x.Phone_Number
            }).FirstOrDefault();
            return P_Details;
        }

        public bool CreateNewPersonalDetail(PersonalViewModel P_View_Model)
        {
            PersonalDetailModel P_Detail_Model = new PersonalDetailModel();

            P_Detail_Model.Person_ID = P_View_Model.Person_ID;
            P_Detail_Model.Full_Name = P_View_Model.Full_Name;
            P_Detail_Model.Other_Name = P_View_Model.Other_Name;
            P_Detail_Model.Email_Address = P_View_Model.Email_Address;
            P_Detail_Model.P_Address = P_View_Model.P_Address;
            P_Detail_Model.Phone_Number = P_View_Model.Phone_Number;
            P_Detail_Model.Last_Modified = user_Name;

            _logicBL.SavePersonalDetails(P_Detail_Model);
            return true;
        }

        public int CreateNewUser(UsersViewModel U_View_Model)
        {
            UsersModel U_Model = new UsersModel();

            U_Model.Username = U_View_Model.Username;
            U_Model.P_Password = U_View_Model.Password;

            
            return _logicBL.SaveNewUserDetails(U_Model);
            
        }
        //public int GetUserID(UsersViewModel U_View_Model)
        //{
        //    UsersModel U_Model = new UsersModel();

        //    U_Model.Username = U_View_Model.Username;
        //    U_Model.P_Password = U_View_Model.Password;

        //   return _logicBL.GetUserID(U_Model);
        //}

        public bool CreateEducationDetails(List<EducationModel> educationModel, int User_ID)
        {
            
            InstitutionModel institution = new InstitutionModel();
            QualificationModel qualification = new QualificationModel();
            ModuleModel modules = new ModuleModel();

            foreach(var institutionName in educationModel.Select(X => X.Institution_Name).Distinct())
            {

                institution.Institution_Name = institutionName;
                institution.Person_ID = User_ID;
                institution.Last_Modified = User_ID.ToString();
               int institution_ID = _homeDAL.SaveInstitutionModel(institution);
                    
              
                foreach (var qualifications in educationModel.Where(t => t.Institution_Name.Equals(institutionName)).Distinct())
                {

                    qualification.Q_Name = qualifications.Q_Name;
                    qualification.Course_Name = qualifications.Course_Name;
                    qualification.Last_Modified = User_ID.ToString();
                  qualification.Institution_ID = institution_ID;
                  int qualification_ID = _homeDAL.SaveQualificationsModel(qualification);    
                    

                    foreach (var module in educationModel.Where(t => t.Q_Name.Equals(qualifications.Q_Name) && t.Institution_Name.Equals(institutionName)).Distinct())
                    {

                        modules.Module_Name = module.Module_Name;
                        modules.Module_Marks = module.Module_Marks;
                        modules.Module_Level = module.Module_Level;
                        modules.Person_ID = User_ID;
                        modules.Last_Modified = User_ID.ToString();
                        modules.Qualification_ID = qualification_ID;
                        _homeDAL.SaveModuleModel(modules);

                        
                    }
                }
            }

            return true;
            
        }

        public List<ViewUsers> GetViewUsers()
        {
            List<PersonalDetailModel> p_details = _logicBL.GetViewUsers();
            List<ViewUsers> View_Users = p_details.Select(x => new ViewUsers
            {
                Full_Name = x.Full_Name,
                Other_Name = x.Other_Name,
                Person_ID = x.Person_ID
            }).ToList();

            return View_Users;
            
        }

        public PersonalViewModel GetPersonalDetailsView(int User_ID)
        {
            PersonalDetailModel p_details = _logicBL.GetPersonalDetails(User_ID);
            PersonalViewModel p_View = new PersonalViewModel();

            p_View.Full_Name = p_details.Full_Name;
            p_View.Email_Address = p_details.Email_Address;
            p_View.Other_Name = p_details.Other_Name;
            p_View.Phone_Number = p_details.Phone_Number;
            p_View.P_Address = p_details.P_Address;

            return p_View;
           
        }

        public bool EditPersonalViewModel(PersonalViewModel p_model)
        {
            PersonalDetailModel p_details = new PersonalDetailModel();

            p_details.Person_ID = p_model.Person_ID;
            p_details.Full_Name = p_model.Full_Name;
            p_details.Other_Name = p_model.Other_Name;
            p_details.Phone_Number = p_model.Phone_Number;
            p_details.P_Address = p_model.P_Address;
            p_details.Email_Address = p_model.Email_Address;

            return _logicBL.EditPersonalDetails(p_details);
        }


        //public List<EducationModel> GetEducationDetailsList(Guid User_ID)
        //{
        //    List<EducationModel> educationList = _homeDAL.GetEducationList().Where(u => u.Person_ID.Equals(User_ID)).Select(x => new EducationModel
        //    {
        //        Module_Name = x.Module_Name,
        //        Module_Level = x.Module_Level,
        //        Marks = x.Marks,
        //        Institution_Name = x.Institution_Name
        //    }).ToList();

        //    return educationList;
        // }

        //public SkillsViewModel GetSkills_WorkingExperienceList(Guid User_ID)
        //{
        //    List<SkillsModel> skillsList = _homeDAL.GetSkillsList().Where(x => x.Person_ID.Equals(User_ID)).Select(x => new SkillsModel
        //    {
        //        Details = x.Details,
        //        Skills_Type = x.Skills_Type
        //    }).ToList();

        //    List<WorkingExperienceModel> workingList = _homeDAL.GetWorkingExperienceList().Where(x => x.Person_ID.Equals(User_ID)).Select(x => new WorkingExperienceModel
        //    {
        //        Working_Area = x.Working_Area,
        //        Title = x.Title
        //    }).ToList();

        //    SkillsViewModel skillsViewModel = new SkillsViewModel();
        //    skillsViewModel.SkillsList = skillsList;
        //    skillsViewModel.WorkingExperienceList = workingList;

        //    return skillsViewModel;
        //}
    }

}
