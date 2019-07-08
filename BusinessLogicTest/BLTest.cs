using BL;
using BL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTest
{
    [TestFixture]
    public class BLTest
    {

        private ILogicBL _logic;

        private Mock<IHomeDAL> _homeDAL = new Mock<IHomeDAL>();

        [SetUp]
        public void Init()
        {
            _logic = new BLogic(_homeDAL.Object);
        }

        [TestCase(1)]
        public void GetUsernameResultTest1(int id)
        {
            List<PersonalDetailModel> personalDetails = new List<PersonalDetailModel>();
            personalDetails.Add(new PersonalDetailModel
            {
                Person_ID = 1,
                Full_Name = "Steven",
                Other_Name = "Deepoo",
                Email_Address = "sfsdfd",
                Phone_Number = "sadasd",
                Last_Modified = "fasdfdsf",
                P_Address = "asdas"
            });

            var actual = _homeDAL.Setup(x => x.GetPersonalDetails())
                 .Returns(personalDetails);

            Assert.IsInstanceOf<PersonalDetailModel>(_logic.GetUserName(id));
            
           
        }

        [TestCase(2)]
        public void GetUsernameResultTest2(int id)
        {
            List<PersonalDetailModel> personalDetails = new List<PersonalDetailModel>();
           

            var actual = _homeDAL.Setup(x => x.GetPersonalDetails())
                 .Returns(personalDetails);

            
            Assert.Null(_logic.GetUserName(id));

        }


    }
}
