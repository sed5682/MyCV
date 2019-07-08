
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IHomeDAL
    {
        List<PersonalDetailModel> GetPersonalDetails();
        List<SkillsModel> GetSkillsList();
        List<ExperienceModel> GetWorkingExperienceList();
        //  List<EducationModel> GetEducationList();
        bool CreateNewPersonalDetails(PersonalDetailModel personalDetail);

        int CreateNewUser(UsersModel U_Model);

        //int GetUserID(UsersModel U_Model);

        int SaveInstitutionModel(InstitutionModel institution_Model);
        int SaveQualificationsModel(QualificationModel qualification_Model);

        bool SaveModuleModel(ModuleModel module_Model);

        bool UpdatePersonalDetails(PersonalDetailModel p_details);

    }   
}
