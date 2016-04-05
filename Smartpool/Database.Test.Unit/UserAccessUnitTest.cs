using NUnit.Framework;
using Smartpool.UserAccess;

namespace Database.Test.Unit
{
    [TestFixture]
    public class UserAccessUnitTest
    {
        #region Setup

        IUserAccess _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new UserAccess();
        }

        #endregion

        #region AddUser, testing that the name is set correct when using 3 names

        [Test]
        public void AddUser_InsertsUserWith3Names_UserHasCorrectFirstname()
        {
            _uut.AddUser("John Derp Johnson", "mail", "password");

            Assert.That(_uut.FindUserByEmail("mail").Firstname, Is.EqualTo("John"));
        }

        [Test]
        public void AddUser_InsertsUserWith3Names_UserHasCorrectMiddelname()
        {
            _uut.AddUser("John Derp Johnson", "mail", "password");

            Assert.That(_uut.FindUserByEmail("mail").Firstname, Is.EqualTo("Derp"));
        }

        [Test]
        public void AddUser_InsertsUserWith3Names_UserHasCorrectLastname()
        {
            _uut.AddUser("John Derp Johnson", "mail", "password");

            Assert.That(_uut.FindUserByEmail("mail").Firstname, Is.EqualTo("Johnson"));
        }

        #endregion

        #region AddUser, testing that the name is set correct when using 2 names

        [Test]
        public void AddUser_InsertUserWith2Names_UserHasCorrectFirstname()
        {
            _uut.AddUser("John Johnson", "mail", "password");

            Assert.That(_uut.FindUserByEmail("mail").Firstname, Is.EqualTo("John"));
        }

        [Test]
        public void AddUser_InsertUserWith2Names_UserHasCorrectLastname()
        {
            _uut.AddUser("John Johnson", "mail", "password");

            Assert.That(_uut.FindUserByEmail("mail").Firstname, Is.EqualTo("Johnson"));
        }

        #endregion


    }
}
