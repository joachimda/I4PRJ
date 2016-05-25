using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using Smartpool;
using Smartpool.Connection.Server.FakePoolDataGeneration;

namespace Connection.Test
{
    [TestFixture]
    public class FakePoolKeeperUnitTest
    {
        private FakePoolKeeper _uut;
        private ISmartpoolDB _subForSmartpoolDb;

        [SetUp]
        public void Setup()
        {
            _subForSmartpoolDb = Substitute.For<ISmartpoolDB>();
            _uut = new FakePoolKeeper(_subForSmartpoolDb);
        }

        [Test]
        public void GeneratePoolsForUser_UserWithThreePools_ThreePoolsCreated()
        {
            var testUser = "testuser";
        _subForSmartpoolDb.PoolAccess.FindAllPoolsOfUser(testUser)
                .Returns(new List<Pool>() { new Pool() {Name = "1"}, new Pool() { Name = "1" }, new Pool() { Name = "1" } });

            _uut.GeneratePoolsForUser(testUser);

            _subForSmartpoolDb.Received(3)
                .DataAccess.CreateDataEntry(testUser, "1", Arg.Any<double>(), Arg.Any<double>(), Arg.Any<double>(),
                    Arg.Any<double>());
        }
    }
}
