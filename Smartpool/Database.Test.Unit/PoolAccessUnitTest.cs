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
            _uut.DeleteAllUsers();
        }

        [TearDown]
        public void Teardown()
        {
            //_uut.DeleteAllUsers();
        }

        #endregion

    }
}