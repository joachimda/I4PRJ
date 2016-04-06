using DbAccess;
using NSubstitute;
using NUnit.Framework;

namespace SmartPoolDB.UnitTest
{
    [TestFixture]
    public class UserAccessTest
    {
        IUserAccess _userAccess;

        [SetUp]
        public void Setup()
        {
            _userAccess = new UserAccess();
        }

        [Test]
        public void FindUserByEmail_InsertsUserWithOriginalEmail_ReturnsThisUser()
        {
            _userAccess.AddUser("John", "Derp", "derp@herp.com", "password123");


        }
    }
}