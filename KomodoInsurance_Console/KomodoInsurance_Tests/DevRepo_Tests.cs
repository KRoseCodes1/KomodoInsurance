using KomodoInsurance_Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoInsurance_Tests
{
    [TestClass]
    public class DevRepo_Tests
    {
        DeveloperRepo _devRepo = new DeveloperRepo();
        [TestMethod]
        public Developer AddMember_ShouldReturnNotNull()
        {   
            Developer dev = new Developer("Kacie","Rose",70,true);
            _devRepo.AddNewDeveloper(dev);
            foreach (Developer member in _devRepo._listOfDevelopers)
            {
                if (member.ID == 70)
                {
                    return member;
                }
            }
            return null;
        }
    }
}
