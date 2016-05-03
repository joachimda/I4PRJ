using System.Globalization;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Smartpool;

namespace Database.Test.Unit
{
    [TestFixture]
    public class PoolAccessUnitTest
    {
        #region Setup

        private IPoolAccess _uut;
        private IUserAccess _userAccess;


        private User _user1, _user2;

        [SetUp]
        public void Setup()
        {
            _userAccess = Substitute.For<IUserAccess>();
            _uut = new PoolAccess(_userAccess);

            _user1 = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Andersen", Email = "somemail@derp.com", Password = "password123" };
            _user2 = new User() { Firstname = "Sire", Middelname = "Herp", Lastname = "Jensenei", Email = "post@jensenei.dk", Password = "mydogsname" };

            using (var db = new DatabaseContext())
            {
                db.UserSet.Add(_user1);
                db.UserSet.Add(_user2);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllPools();
            _userAccess.DeleteAllUsers();
        }

        #endregion

        #region AddPool

        [Test]
        public void AddPool_AddingPoolWithExistingUser_IsPoolNameAvailableReturnsFalse()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            _uut.AddPool(mail, "poolname", 4);

            Assert.That(_uut.IsPoolNameAvailable(mail, "poolname"), Is.False);
        }

        [Test]
        public void AddPool_AddingPoolWithValidUser_ThrowsUserNotFoundException()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            Assert.DoesNotThrow(() => _uut.AddPool(mail, "poolname", 89));
        }

        [Test]
        public void AddPool_AddingPoolWithZeroVolume_ReturnsFalse()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            Assert.That(_uut.AddPool(mail, "name", 0), Is.False);
        }

        [Test]
        public void AddPool_AddingPoolWithNeg5Volume_ReturnsFalse()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            Assert.That(_uut.AddPool(mail, "name", -5), Is.False);
        }

        [Test]
        public void AddPool_AddingIdenticalPool_ReturnsFalse()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            _uut.AddPool(mail, "name", 4);
            Assert.That(_uut.AddPool(mail, "name", 4), Is.False);
        }

        [Test]
        public void AddPool_AddingSecondPoolWithValidName_IsPoolNameAvailableReturnsTrue()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            _uut.AddPool(mail, "name", 8);
            bool shouldBeTrue = _uut.AddPool(mail, "othername", 3);
            Assert.That(shouldBeTrue, Is.True);
        }

        [Test]
        public void AddPool_AddingPoolToOtherUserWithSameName_ReturnTrue()
        {
            const string mail1 = "somemail@derp.com";
            const string mail2 = "post@jensenei.dk";
            _uut.AddPool(mail2, "name", 8);
            bool beTrue = _uut.AddPool(mail1, "name", 8);
            Assert.That(beTrue, Is.True);
        }

        #endregion

        #region IsPoolNameAvailable

        [Test]
        public void IsPoolNameAvailable_UserNotExisting_IsPoolNameAvailableReturnsTrue()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            Assert.That(_uut.IsPoolNameAvailable(mail, "somename"), Is.True);
        }

        [Test]
        public void IsPoolNameAvailable_PoolExists_IsPoolNameAvailableReturnsFalse()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            _uut.AddPool(mail, "unknown", 8);
            Assert.That(_uut.IsPoolNameAvailable(mail, "unknown"), Is.False);
        }

        [Test]
        public void IsPoolNameAvailable_AddedOtherOriginalPool_IsPoolNameAvailableReturnsTrue()
        {
            const string mail = "somemail@derp.com";
            _userAccess.FindUserByEmail(mail).ReturnsNull();
            _uut.AddPool(mail, "name", 8);
            bool mustBeTrue = _uut.IsPoolNameAvailable(mail, "othername");

            Assert.That(mustBeTrue, Is.True);
        }

        #endregion

        #region FindSpecificPool
        
        [Test]
        public void FindSpecificPool_EmptyDatabase_ThrowsPoolNotFoundException()
        {
            User derp = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Andersen", Email = "post@andersen.dk" };

            Assert.Throws<PoolNotFoundException>(() => _uut.FindSpecificPool(derp.Email, "thispooldoesnotexist"));
        }

        [Test]
        public void FindSpecificPool_UserExistsInDatabaseButWithoutPool_ThrowsPoolNotFoundException()
        {
            const string mail = "somemail@derp.com";

            User derp = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Andersen", Email = mail };
            _userAccess.FindUserByEmail(mail).Returns(derp);
            Assert.Throws<PoolNotFoundException>(() => _uut.FindSpecificPool(derp.Email, "thispooldoesnotexist"));
        }

        [Test]
        public void FindSpecificPool_PoolIsInDatabase_ReturnsPoolWithCorrectName()
        {
            const string mail = "somemail@derp.com";
            _uut.AddPool(mail, "poolio", 50);

            Pool pool = _uut.FindSpecificPool(mail, "poolio");
            Assert.That(pool.Name, Is.EqualTo("poolio"));
        }

        [Test]
        public void FindSpecificPool_PoolIsInDatabase_ReturnsPoolWithCorrectUserId()
        {
            const string mail = "somemail@derp.com";
            User derp = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Andersen", Email = mail };
            _uut.AddPool(mail, "poolio", 50);
            _userAccess.FindUserByEmail(mail).Returns(derp);

            Pool pool = _uut.FindSpecificPool(mail, "poolio");
            Assert.That(pool.UserId, Is.EqualTo(derp.Id));
        }

        #endregion

        #region RemovePool

        [Test]
        public void RemovePool_RemoveExistingPool_IsPoolNameAvailableReturnsTrue()
        {
            string poolname = "helloworld";

            _uut.AddPool(_user1, poolname, 9);
            _uut.RemovePool(_user1, poolname);

            Assert.That(_uut.IsPoolNameAvailable(_user1, poolname), Is.True);
        }

        [Test]
        public void RemovePool_PoolNotInDatabase_RemovePoolReturnsFalse()
        {
            Assert.That(_uut.RemovePool(_user1, "ThisPoolIsNotHere"), Is.False);
        }

        #endregion
    }
}