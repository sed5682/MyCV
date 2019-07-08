using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL
{
    public class HomeDAL : PortfolioDBConnection, IHomeDAL
    {
        public DataTable getData(string sql)
        {
            SqlConnection _connect = CreateSQLConnection();
            using (_connect)
            {
              
                SqlDataAdapter sda = new SqlDataAdapter(sql,_connect);
                DataTable dt = new DataTable();
                _connect.Open();
                sda.Fill(dt);
                _connect.Close();

                return dt;
            }
        }
        public List<PersonalDetailModel> GetPersonalDetails()
        {

            List<PersonalDetailModel> PersonalDetailsList = new List<PersonalDetailModel>();
            string Sql = $"SELECT * FROM Personal_Details";

     
            DataTable dt = new DataTable();
            dt = getData(Sql);
                foreach (DataRow dr in dt.Rows)
                {
                    PersonalDetailsList.Add(
                       new PersonalDetailModel
                       {
                           Person_ID = Convert.ToInt32((dr["Person_ID"])),
                           Other_Name = Convert.ToString(dr["Other_Names"]),
                           Email_Address = Convert.ToString(dr["Email_Address"]),
                           P_Address = Convert.ToString(dr["P_Address"]),
                           Phone_Number = Convert.ToString(dr["Phone_Number"]),
                           Full_Name = Convert.ToString(dr["Full_Name"])
                       });

                }
            return PersonalDetailsList;
        }

        public List<SkillsModel> GetSkillsList()
        {
      

            List<SkillsModel> SkillsList = new List<SkillsModel>();            
            string Sql = $"SELECT * FROM Skills";

          


                DataTable dt = new DataTable();
                dt = getData(Sql);
                foreach (DataRow dr in dt.Rows)
                {
                    SkillsList.Add(
                        new SkillsModel
                        {
                            Skills_Details = Convert.ToString(dr["Skills_Details"]),
                            Skills_Type = Convert.ToString(dr["Skills_Type"]),
                            Person_ID = Convert.ToInt32((dr["Person_ID"]))

                        });
                
            }
            return SkillsList;
        }

        public List<ExperienceModel> GetWorkingExperienceList()
        {

            List<ExperienceModel> WorkingExperienceList = new List<ExperienceModel>();
          
            string Sql = $"SELECT * FROM WorkingExperience";

           
                DataTable dt = new DataTable();
                dt = getData(Sql);

                foreach (DataRow dr in dt.Rows)
                {
                    WorkingExperienceList.Add(
                        new ExperienceModel
                        {
                            Experience_Area = Convert.ToString(dr["Experience_Area"]),
                            Experience_Title = Convert.ToString(dr["Experience_Title"]),
                            Person_ID = Convert.ToInt32(dr["Person_ID"])

                        });
                
            }
            return WorkingExperienceList;
        }

        public bool CreateNewPersonalDetails(PersonalDetailModel P_Details)
        {
            string sql = $"Insert into Personal_Details(Person_ID,Full_Name,Other_Names,P_Address,Email_Address,Phone_Number,Last_Modified)  VALUES ('{P_Details.Person_ID}','{P_Details.Full_Name}','{P_Details.Other_Name}','{P_Details.P_Address}','{P_Details.Email_Address}','{P_Details.Phone_Number}','{P_Details.Last_Modified}') ";
            SqlConnection _connect = CreateSQLConnection();
            
            SqlCommand command = new SqlCommand(sql, _connect);
            _connect.Open();
           int i = command.ExecuteNonQuery();
            _connect.Close();

            return true;
        }

        public int CreateNewUser(UsersModel U_Model)
        {
            string sql = $"Insert into Users(Username,P_Password) VALUES('{U_Model.Username}','{U_Model.P_Password}'); SELECT CAST(scope_identity() AS int)";
            int User_ID = 0;
            SqlConnection _connect = CreateSQLConnection();

            SqlCommand command = new SqlCommand(sql, _connect);
            _connect.Open();
            User_ID = (int)command.ExecuteScalar();
            _connect.Close();

            return User_ID;
        }

        //public int GetUserID(UsersModel U_Model)
        //{
        //    string sql = $"SELECT Person_ID FROM Users WHERE Username = '{U_Model.Username}' AND P_Password = '{U_Model.P_Password}'";

        //    int User_ID = 0;
        //    DataTable dt = new DataTable();
        //    dt = getData(sql);

        //    User_ID = Convert.ToInt32(dt.Rows[0]["Person_ID"]);

        //    return User_ID;
        //}

        public int SaveInstitutionModel(InstitutionModel institution_Model)
        {
            string sql = $"INSERT INTO Institution(Institution_Name, Person_ID,Last_Modified) VALUES ('{institution_Model.Institution_Name}',{institution_Model.Person_ID},'{institution_Model.Last_Modified}'); SELECT CAST(scope_identity() AS int)";
            int Institution_ID = 0;
            SqlConnection _connect = CreateSQLConnection();

            SqlCommand command = new SqlCommand(sql, _connect);
            _connect.Open();
            Institution_ID = (int)command.ExecuteScalar();
            _connect.Close();

            return Institution_ID;
        }

        public int SaveQualificationsModel(QualificationModel qualification_Model)
        {
            string sql = $"INSERT INTO Qualifications(Q_Name,Course_Name,Institution_ID,Last_Modified) VALUES('{qualification_Model.Q_Name}','{qualification_Model.Course_Name}',{qualification_Model.Institution_ID},'{qualification_Model.Last_Modified}'); SELECT CAST(scope_identity() AS int)";
            int qualification_ID = 0;
            SqlConnection _connect = CreateSQLConnection();

            SqlCommand command = new SqlCommand(sql, _connect);
            _connect.Open();
            qualification_ID = (int)command.ExecuteScalar();
            _connect.Close();

            return qualification_ID;
        }

        public bool SaveModuleModel(ModuleModel module_Model)
        {
            string sql = $"INSERT INTO Modules(Module_Name,Module_Marks,Module_Level,Qualification_ID,Person_ID,Last_Modified) VALUES ('{module_Model.Module_Name}',{module_Model.Module_Marks},'{module_Model.Module_Level}',{module_Model.Qualification_ID},{module_Model.Person_ID},'{module_Model.Last_Modified}')";

            SqlConnection _connect = CreateSQLConnection();

            SqlCommand command = new SqlCommand(sql, _connect);
            _connect.Open();
            command.ExecuteNonQuery();
            _connect.Close();

            return true;

        }


        public bool UpdatePersonalDetails(PersonalDetailModel p_details)
        {
            string sql = $"UPDATE Personal_Details SET Full_Name = '{p_details.Full_Name}', Other_Names = '{p_details.Other_Name}', Phone_Number = '{p_details.Phone_Number}', Email_Address = '{p_details.Email_Address}', P_Address = '{p_details.P_Address}' WHERE Person_ID ={p_details.Person_ID}";
            SqlConnection _connect = CreateSQLConnection();

            SqlCommand command = new SqlCommand(sql, _connect);
            _connect.Open();
            command.ExecuteNonQuery();
            _connect.Close();

            return true;
        }

        //public List<EducationModel> GetEducationList()
        //{
        //    SqlConnection connect = CreateSQLConnection();
        //    List<EducationModel> EducationModelList = new List<EducationModel>();
        //    string Sql = $"Select Module.Module_Name,Module.Module_Level,Module.Marks,Institution.Institution_Name,Course.Course_Name,Module.Person_ID " +
        //        $"from Module " +
        //        $"full JOIN Institution ON Institution.Institution_ID = Module.Institution_ID " +
        //        $"full join Course ON Module.Course_ID = Course.Course_ID " +
        //        $"Group by Module.module_level,Module.Module_Name,Module.Marks,Institution.Institution_Name,Course.Course_Name,Module.Person_ID";


        //    using (connect)
        //    {
        //        SqlCommand command = new SqlCommand(Sql, connect);

        //        SqlDataAdapter sda = new SqlDataAdapter(command);
        //        DataTable dt = new DataTable();
        //        connect.Open();
        //        sda.Fill(dt);
        //        connect.Close();

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            EducationModelList.Add(
        //                new EducationModel
        //                {
        //                    Module_Name = Convert.ToString(dr["Module_Name"]),
        //                    Module_Level = Convert.ToString(dr["Module_Level"]),
        //                    Marks = Convert.ToString(dr["Marks"]),
        //                    Institution_Name = Convert.ToString(dr["Institution_Name"]),
        //                    Course_Name = Convert.ToString(dr["Course_Name"]),
        //                    Person_ID = Guid.Parse(Convert.ToString(dr["Person_ID"])),

        //                });
        //        }

        //        return EducationModelList;
        //    }

        //}



    }

}