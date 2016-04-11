using NSubstitute;
using NUnit.Framework;
using Smartpool;
using Smartpool.Factories;
using Smartpool.UserAccess;

namespace Database.Test.Unit
{
    [TestFixture]
    public class PoolAccessUnitTest
    {
        #region Setup

        private IPoolAccess _uut;
        private IUserAccess _userAccess;

        [SetUp]
        public void Setup()
        {
            _uut.DeleteAllPools();
            
            _uut = new PoolAccess();
            _userAccess = Substitute.For<IUserAccess>();
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllPools();
        }

        #endregion

        #region AddPool

        [Test]
        public void AddPool_AddingPool_ReturnsSomething()
        {
            //_uut.AddPool()
        }

        #endregion

        #region IsPoolNameInUse

        // tests

        #endregion

        #region RemovePool

        // tests

        #endregion

        #region DeleteAllPools

        // tests

        #endregion
    }
}