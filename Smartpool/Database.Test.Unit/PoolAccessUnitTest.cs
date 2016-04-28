using System;
using NSubstitute;
using NUnit.Framework;
using Smartpool;

namespace Database.Test.Unit
{
    [TestFixture]
    public class PoolAccessUnitTest
    {
        #region Setup

        private IPoolAccess _uut;

        [SetUp]
        public void Setup()
        {
            _uut.DeleteAllPools();
            _uut = new PoolAccess();

            User user = new User() { Firstname = "John", Middelname = "Derp", Lastname = "Andersen", Email = "post@andersen.dk", Password = "password123" };

            using (var db = new DatabaseContext())
            {
                db.UserSet.Add(user);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllPools();
        }

        #endregion

        #region AddPool

        [Test]
        public void AddPool_AddingPoolWithExistingUser_IsPoolNameInUseReturnsTrue()
        {

        }

        [Test]
        public void AddPool_AddingPoolWithNonNullUser_ThrowsUserNotFoundException()
        {

        }

        // public void AddPool_AddingPoolWithZeroVolume_ThrowsArgumentException()
        // public void AddPool_AddingPoolWith-5Volume_ThrowsArgumentException()
        // public void AddPool_AddingIdenticalPool_ThrowsArgumentException()
        // public void AddPool_AddingSecondPoolWithValidName_IsPoolNameInUseReturnsTrue()
        // public void AddPool_AddingPoolOnNewAddressWithExistingName_IsPoolNameInUseReturnsTrue()

        #endregion

        #region IsPoolNameInUse

        // public void IsPoolNameInUse_EmptyDatabase_ReturnsFalse()
        // public void IsPoolNameInUse_EmptyDatabase_ThrowsUserNotFoundException()
        // public void IsPoolNameInUse_EmptyDatabase_ThrowsPoolNotFoundException()
        // public void IsPoolNameInUse_AddedOtherOriginalPool_ReturnsFalse()
        // public void IsPoolNameInUse_PoolOnSameUserAndAddress_ReturnsFalse()
        // public void IsPoolNameInUse_PoolOnSameUserAndAddressAndName_ReturnsTrue()

        #endregion

        #region FindSpecificPool

        // public void FindSpecificPool_EmptyDatabase_ThrowsUserNotFoundException()
        // public void FindSpecificPool_EmptyDatabase_ThrowsPoolNotFoundException()
        // public void FindSpecificPool_UserExistsInDatabase_ThrowsPoolNotFoundException()
        // public void FindSpecificPool_PoolIsInDatabase_ReturnsCorrectPool()

        #endregion

        #region RemovePool

        [Test]
        public void RemovePool_RemoveExistingPool_IsPoolNameInUseReturnsFalse()
        {

        }

        [Test]
        public void RemovePool_PoolNotInDatabase_ThrowsPoolNotFoundException()
        {

        }

        #endregion
    }
}