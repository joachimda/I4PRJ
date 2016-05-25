using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NSubstitute;
using NUnit.Framework;
using Smartpool;
using Smartpool.Connection.Server.FakePoolDataGeneration;

namespace Connection.Test
{
    [TestFixture]
    public class FakePoolUnitTest
    {
        private FakePool _uut;
        private ISmartpoolDB _subForSmartpoolDb;

        [SetUp]
        public void SetUp()
        {
            _subForSmartpoolDb = Substitute.For<ISmartpoolDB>();
            _uut = new FakePool(4, 1, "username", "poolname", _subForSmartpoolDb);
        }

        [Test]
        public void Constructor_CreatedWithFourSensors()
        {
            _subForSmartpoolDb.Received(1)
                .DataAccess.CreateDataEntry("username", "poolname", Arg.Any<double>(), Arg.Any<double>(),
                    Arg.Any<double>(), Arg.Any<double>());
        }

        [Test]
        public void Constructor_CreatedWithFourSensors_RunningForFiveSeconds()
        {
            Thread.Sleep(5000);
            _subForSmartpoolDb.Received(5)
                .DataAccess.CreateDataEntry("username", "poolname", Arg.Any<double>(), Arg.Any<double>(),
                    Arg.Any<double>(), Arg.Any<double>());
        }
    }
}
