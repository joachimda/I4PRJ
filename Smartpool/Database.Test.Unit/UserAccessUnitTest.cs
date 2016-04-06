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
            _uut.DeleteAllUsers();
        }

        #endregion

        #region AddUser

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

            Assert.That(_uut.FindUserByEmail("mail").Middelname, Is.EqualTo("Derp"));
        }

        [Test]
        public void AddUser_InsertsUserWith3Names_UserHasCorrectLastname()
        {
            _uut.AddUser("John Derp Johnson", "mail", "password");

            Assert.That(_uut.FindUserByEmail("mail").Lastname, Is.EqualTo("Johnson"));
        }

        #endregion

        #region AddUser, testing that the name is set correct when using 2 names

        [Test]
        public void AddUser_InsertUserWith2Names_UserHasCorrectFirstname()
        {
            _uut.AddUser("John Derpson", "mail", "password");

            Assert.That(_uut.FindUserByEmail("mail").Firstname, Is.EqualTo("John"));
        }

        [Test]
        public void AddUser_InsertUserWith2Names_UserHasCorrectLastname()
        {
            _uut.AddUser("John Derpson", "mail", "password");

            Assert.That(_uut.FindUserByEmail("mail").Lastname, Is.EqualTo("Derpson"));
        }

        #endregion

        #region AddUser, testing that it should not the possible to add user with existing email

        [Test]
        public void AddUser_InsertUserWithAlreadyUsedEmail_ReturnsFalse()
        {
            _uut.AddUser("John Johnson", "mail", "password");

            Assert.That(_uut.AddUser("Derp Derpsen", "mail", "wordpass"), Is.False);
        }

        [Test]
        public void AddUser_InsertUserWithAlreadyUsedEmail_SecondUserIsNotInDatabase()
        {
            _uut.AddUser("John Johnson", "mail", "password");
            _uut.AddUser("Derp Derpsen", "mail", "wordpass");

            // not sure how to test this...
        }

        #endregion

        #endregion

        #region FindUserByEmail

        #endregion

        #region EmailIsUsed

        #endregion

        #region ValidatePassword

        #endregion

        #region RemoveUser

        #endregion
    }
}
