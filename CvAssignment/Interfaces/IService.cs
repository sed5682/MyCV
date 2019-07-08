
using CvAssignment.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAssignment.Interfaces
{
    public interface IService
    {
       PersonalDetailModel GetUserName(int User_ID);
       PersonalDetailModel GetPersonalDetails(int User_ID);
       // int GetUserID(UsersViewModel U_View_Model);
       bool CreateNewPersonalDetail(PersonalViewModel P_View_Model);
        int CreateNewUser(UsersViewModel U_View_Model);

        bool CreateEducationDetails(List<EducationModel> educationModel, int User_ID);
        List<ViewUsers> GetViewUsers();

        PersonalViewModel GetPersonalDetailsView(int User_ID);

        bool EditPersonalViewModel(PersonalViewModel p_model);
        //List<EducationModel> GetEducationDetailsList(Guid User_ID);
        //SkillsViewModel GetSkills_WorkingExperienceList(Guid User_ID);

    }
}
