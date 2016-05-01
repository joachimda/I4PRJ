using NUnit.Framework;
using Smartpool;

namespace Database.Test.Unit
{
    [TestFixture]
    public class UserAccessUnitTest
    {
        #region Setup

        IUserAccess _uut;
        IPoolAccess _poolAccess;

        [SetUp]
        public void Setup()
        {
            _uut = new UserAccess();
            _poolAccess = new PoolAccess();
        }

        [TearDown]
        public void Teardown()
        {
            _poolAccess.DeleteAllPools();
            _uut.DeleteAllUsers();
        }

        #endregion

        #region AddUser

        #region AddUser, testing that the name is set correct when using 3 names

        [Test]
        public void AddUser_InsertsUserWith3Names_UserHasCorrectFirstname()
        {
            _uut.AddUser("John Derp Johnson", "mail1", "password");

            Assert.That(_uut.FindUserByEmail("mail1").Firstname, Is.EqualTo("John"));
        }

        [Test]
        public void AddUser_InsertsUserWith3Names_UserHasCorrectMiddelname()
        {
            _uut.AddUser("John Derp Johnson", "mail2", "password");

            Assert.That(_uut.FindUserByEmail("mail2").Middelname, Is.EqualTo("Derp"));
        }

        [Test]
        public void AddUser_InsertsUserWith3Names_UserHasCorrectLastname()
        {
            _uut.AddUser("John Derp Johnson", "mail3", "password");

            Assert.That(_uut.FindUserByEmail("mail3").Lastname, Is.EqualTo("Johnson"));
        }

        #endregion

        #region AddUser, testing that the name is set correct when using 2 names

        [Test]
        public void AddUser_InsertUserWith2Names_UserHasCorrectFirstname()
        {
            _uut.AddUser("John Derpson", "mail4", "password");

            Assert.That(_uut.FindUserByEmail("mail4").Firstname, Is.EqualTo("John"));
        }

        [Test]
        public void AddUser_InsertUserWith2Names_UserHasCorrectLastname()
        {
            _uut.AddUser("John Derpson", "mail5", "password");

            Assert.That(_uut.FindUserByEmail("mail5").Lastname, Is.EqualTo("Derpson"));
        }

        #endregion

        [Test]
        public void AddUser_AddingUserWith1NameOnly_ReturnsFalse()
        {
            Assert.That(_uut.AddUser("OnlyName", "sædoij", "iuhiu"), Is.False);
        }

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

        [Test]
        public void AddUser_Add2UsersWithSameEmailWithDiffCaPiTaL_ReturnsFalse()
        {
            _uut.AddUser("John Steward Sirson", "john@sirson.com", "password1");

            Assert.That(_uut.AddUser("Gurn Hat Derpson", "John@Sirson.com", "password2"), Is.False);
        }

        #endregion

        #region FindUserByEmail

        [Test]
        public void FindUserByEmail_UserIsNotAdded_ReturnsNullUser()
        {
            //Assert.Throws<UserNotFoundException>(() => _uut.FindUserByEmail("mail"));

            Assert.That(_uut.FindUserByEmail("mail11"), Is.Null);
        }

        [Test]
        public void FindUserByEmail_UserIsAdded_FindsCorrectUser()
        {
            _uut.AddUser("John Derp Herpson", "email7", "password");

            Assert.That(_uut.FindUserByEmail("email7").Password, Is.EqualTo("password"));
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

        [Test]
        public void FindUserByEmail_InsertsUserWithEmailInAllCaps_FindUserSearchingWithLowerCaps()
        {
            _uut.AddUser("John Derp Herpson", "EMAIL", "password");

            Assert.That(_uut.FindUserByEmail("email").Lastname, Is.EqualTo("Herpson"));
        }

        #endregion

        #region EmailIsUsed

        // is tested through 'FindUserByEmail'

        #endregion
        
        #region ValidatePassword

        [Test]
        public void ValidatePassword_ValidPassword_ReturnsTrue()
        {
            _uut.AddUser("John Derp", "email8", "pass");

            Assert.That(_uut.ValidatePassword("email8", "pass"), Is.True);
        }

        [Test]
        public void ValidatePassword_InvalidPassword_ReturnsFalse()
        {
            _uut.AddUser("John Derp", "email9", "pass");

            Assert.That(_uut.ValidatePassword("email9", "falsepass"), Is.False);
        }

        [Test]
        public void ValidatePassword_UserIsNotInDB_ReturnsFalse()
        {
            Assert.That(_uut.ValidatePassword("email0", "pass"), Is.False);
        }

        #endregion

        #region RemoveUser

        [Test]
        public void RemoveUser_RemoveExistingUser_UserNotInDatabase()
        {
            _uut.AddUser("Joachim Fucktard Andersen", "jokkemail", "tissemisse");
            _uut.RemoveUser("jokkemail");

            Assert.That(_uut.FindUserByEmail("jokkemail"), Is.Null);
        }

        [Test]
        public void RemoveUser_UserNotPresentInDB_ThrowsUserNotFoundException()
        {
            Assert.Throws<UserNotFoundException>(() => _uut.RemoveUser("jokkemail"));
        }

        #endregion
    }
}
