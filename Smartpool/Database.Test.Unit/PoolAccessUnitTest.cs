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

        IPoolAccess _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new PoolAccess();
            _uut.DeleteAllPools();
        }

        [TearDown]
        public void Teardown()
        {
            _uut.DeleteAllPools();
        }

        #endregion

        #region AddPool

        // tests

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