

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
            //List<Person_Skills> SkillsAcquired = _homeDAL.GetUserSkillsAcquired(UserID);
            return _homeDAL.GetSkillsList();
        }

        public List<Person_Skills> GetAcquiredSkills(int UserID)
        {
          //  List<SkillsModel> AllSkills = GetSkillsModels();
          // List<Person_Skills> UserSkills = _homeDAL.GetUserSkillsAcquired(UserID);
            List<Person_Skills> SkillsAcquiredName = new List<Person_Skills>();

            foreach(var SkillsID in GetSkillsModels())
            {
                foreach(var UserSkillsID in _homeDAL.GetUserSkillsAcquired(UserID))
                {
                    if(SkillsID.SkillsID == UserSkillsID.SkillsID)
                    {
                        SkillsAcquiredName.Add(new Person_Skills
                        {
                            SkillsName = SkillsID.SkillsName,
                            EffectiveStart = UserSkillsID.EffectiveStart,
                            EffectiveEnd = UserSkillsID.EffectiveEnd
                        });
                    }
                }
            }

            return SkillsAcquiredName;

        }

        public bool CreateNewSkill(string SkillName,string Start,string End, int UserID)
        {
            int SkillsID = _homeDAL.CreateNewSkills(SkillName, UserID);

            Person_Skills P_Skills = new Person_Skills()
            {
                SkillsID = SkillsID,
                Person_ID = UserID,
                EffectiveStart = Convert.ToDateTime(Start),
                EffectiveEnd = Convert.ToDateTime(End)
            };

            return _homeDAL.SaveUserSkillsDB(P_Skills);
        }
        public bool SaveUserSkills(Person_Skills SkillsToSave, int UserID)
        {
           // Person_Skills person = new Person_Skills();
            //foreach(var skillsID in SkillsToSave)
            //{
            //    person.Person_ID = UserID;
            //    person.SkillsID = skillsID.SkillsID;
            //    person.EffectiveStart = skillsID.EffectiveStart;
            //    person.EffectiveEnd = skillsID.EffectiveEnd;
            //}

            return _homeDAL.SaveUserSkillsDB(SkillsToSave);
        }

        public bool DeleteSkill(string SkillName, int User_ID)
        {
            return _homeDAL.DeletePersonSkills(SkillName, User_ID);
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
