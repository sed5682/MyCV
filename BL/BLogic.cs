

using BL.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class BLogic : ILogicBL
    {
        private readonly IHomeDAL _homeDAL;
        
        public BLogic(IHomeDAL homeDAL)
        {
            if(homeDAL != null) { 
             _homeDAL = homeDAL;
            }
            else
            {
                _homeDAL = new HomeDAL();
            }
        }


        public PersonalDetailModel GetUserName(int User_ID)
        {

            var name = _homeDAL.GetPersonalDetails();


                PersonalDetailModel name2 = name.Where(user => user.Person_ID == User_ID).Select(x => new PersonalDetailModel
                {
                    Full_Name = x.Full_Name
                }).FirstOrDefault();

                return name2;
  
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


        public bool SavePersonalDetails(PersonalDetailModel P_Details)
        {
            _homeDAL.CreateNewPersonalDetails(P_Details);
            return true;
        }

        public int SaveNewUserDetails(UsersModel U_Details)
        {
            
            return _homeDAL.CreateNewUser(U_Details);
        }

        public List<PersonalDetailModel> GetViewUsers()
        {
            List<PersonalDetailModel> View_Details = _homeDAL.GetPersonalDetails().Select(x => new PersonalDetailModel
            {
                Person_ID = x.Person_ID,
                Full_Name = x.Full_Name,
                Other_Name = x.Other_Name
            }).ToList();

            return View_Details;
        }

        public bool EditPersonalDetails(PersonalDetailModel p_details)
        {

            return _homeDAL.UpdatePersonalDetails(p_details);
        }

        public List<SkillsModel> GetSkillsModels()
        {
            return _homeDAL.GetSkillsList();
        }



        //public int GetUserID(UsersModel U_Model) {
        //    return _homeDAL.GetUserID(U_Model);
        //}


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
