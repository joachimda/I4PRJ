using NUnit.Framework;
using Smartpool;
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

            Assert.That(_uut.FindUserByEmail("mail").Firstname, Is.Not.EqualTo("Derp"));
        }

        #endregion

        #endregion

        #region FindUserByEmail

        [Test]
        public void FindUserByEmail_UserIsNotAdded_ThrowsUserNotFoundException()
        {
            Assert.Throws<UserNotFoundException>(() => _uut.FindUserByEmail("mail"));
        }

        [Test]
        public void FindUserByEmail_UserIsAdded_FindsCorrectUser()
        {
            _uut.AddUser("John Derp Herpson", "email", "password");

            Assert.That(_uut.FindUserByEmail("email").Password, Is.EqualTo("password"));
        }

        [Test]
        public void FindUserByEmail_TwoUsersWithSameEmailExistInDB_ThrowsMultipleOccourencesOfEmailWasFoundException()
        {
            User user1 = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Herpson", Email = "email", Password = "password" };
            User user2 = new User() { Firstname = "Simon", Middelname = "Siggy", Lastname = "Sergson", Email = "email", Password = "hellopass" };

            using (var db = new DatabaseContext())
            {
                db.UserSet.Add(user1);
                db.UserSet.Add(user2);
                db.SaveChanges();
            }

            Assert.Throws<MultipleOccourencesOfEmailWasFoundException>(() => _uut.FindUserByEmail("email"));
        }

        #endregion

        #region EmailIsUsed

        // is tested through 'FindUserByEmail'

        #endregion

        #region ValidatePassword

        [Test]
        public void ValidatePassword_ValidPassword_ReturnsTrue()
        {
            _uut.AddUser("John Derp", "email", "pass");

            Assert.That(_uut.ValidatePassword("email", "pass"), Is.True);
        }

        [Test]
        public void ValidatePassword_InvalidPassword_ReturnsFalse()
        {
            _uut.AddUser("John Derp", "email", "pass");

            Assert.That(_uut.ValidatePassword("email", "falsepass"), Is.False);
        }

        [Test]
        public void ValidatePassword_UserIsNotInDB_ThrowsUserNotFoundException()
        {
            _uut.AddUser("John Derp", "email", "pass");

            Assert.Throws<UserNotFoundException>(() => _uut.ValidatePassword("otheremail", "pass"));
        }

        #endregion

     /*   #region RemoveUser

        [Test]
        public void RemoveUser_RemoveExistingUser_UserNotInDatabase()
        {
            _uut.AddUser("Joachim Fucktard Andersen", "jokkemail", "tissemisse");
            _uut.RemoveUser("jokkemail");

            Assert.Throws<UserNotFoundException>(() => _uut.FindUserByEmail("jokkemail"));
        }

        [Test]
        public void RemoveUser_UserNotPresentInDB_ThrowsUserNotFoundException()
        {
            Assert.Throws<UserNotFoundException>(() => _uut.RemoveUser("jokkemail"));
        }

        #endregion
    */
    }
}
