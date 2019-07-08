

using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ILogicBL
    {
       PersonalDetailModel GetUserName(int User_ID);
       PersonalDetailModel GetPersonalDetails(int User_ID);

        bool SavePersonalDetails(PersonalDetailModel P_Details);

        int SaveNewUserDetails(UsersModel U_Details);

        List<PersonalDetailModel> GetViewUsers();

        bool EditPersonalDetails(PersonalDetailModel p_details);

        List<SkillsModel> GetSkillsModels();

        //int GetUserID(UsersModel U_Model);

        // PersonalDetailModel CreateNewUser(PersonalViewModel ls);
        //List<EducationModel> GetEducationDetailsList(Guid User_ID);
        //SkillsViewModel GetSkills_WorkingExperienceList(Guid User_ID);

    }
}
