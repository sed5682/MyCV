using System;
using BL;
using BL.Interfaces;
using NUnit.Framework;

namespace BusinessLogicUnitTest
{
    [TestFixture]
    public class BLTest
    {

        private ILogicBL _logic = new BLogic();
        [SetUp]
        public void Init(ILogicBL logic)
        {
            logic = _logic;
        }
    }
}
