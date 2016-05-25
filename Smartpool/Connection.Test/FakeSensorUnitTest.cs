using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Smartpool.Connection.Model;
using Smartpool.Connection.Server.FakePoolDataGeneration;

namespace Connection.Test
{
    [TestFixture]
    public class FakeSensorUnitTest
    {
        private FakeSensor _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new FakeSensor();
        }

#region TestOfSensorCreation
        [Test]
        public void CreatedTemp_LastSensorValueEntry_GreaterThanMin()
        {
            _uut = new FakeSensor(0);
            Assert.That(_uut.LastSensorValueEntry, Is.GreaterThanOrEqualTo(25));
        }

        [Test]
        public void CreatedTemp_LastSensorValueEntry_LowerThanMax()
        {
            _uut = new FakeSensor(0);
            Assert.That(_uut.LastSensorValueEntry, Is.LessThanOrEqualTo(35));
        }

        [Test]
        public void CreatedPh_LastSensorValueEntry_GreaterThanMin()
        {
            _uut = new FakeSensor(1);
            Assert.That(_uut.LastSensorValueEntry, Is.GreaterThanOrEqualTo(7));
        }

        [Test]
        public void CreatedPh_LastSensorValueEntry_LowerThanMax()
        {
            _uut = new FakeSensor(1);
            Assert.That(_uut.LastSensorValueEntry, Is.LessThanOrEqualTo(7.8));
        }

        [Test]
        public void CreatedChlor_LastSensorValueEntry_GreaterThanMin()
        {
            _uut = new FakeSensor(2);
            Assert.That(_uut.LastSensorValueEntry, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void CreatedChlor_LastSensorValueEntry_LowerThanMax()
        {
            _uut = new FakeSensor(2);
            Assert.That(_uut.LastSensorValueEntry, Is.LessThanOrEqualTo(2));
        }
        
        [Test]
        public void CreatedHum_LastSensorValueEntry_GreaterThanMin()
        {
            _uut = new FakeSensor(3);
            Assert.That(_uut.LastSensorValueEntry, Is.GreaterThanOrEqualTo(40));
        }

        [Test]
        public void CreatedHum_LastSensorValueEntry_LowerThanMax()
        {
            _uut = new FakeSensor(3);
            Assert.That(_uut.LastSensorValueEntry, Is.LessThanOrEqualTo(70));
        }
        #endregion

#region TestOfGetNextSensorValue
        [Test]
        public void CreatedTemp_GetNextSensorValue_GreaterThanMin()
        {
            _uut = new FakeSensor(0);
            for (int i = 0; i < 1000; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.LastSensorValueEntry, Is.GreaterThanOrEqualTo(20));
        }

        [Test]
        public void CreatedTemp_GetNextSensorValue_LowerThanMax()
        {
            _uut = new FakeSensor(0);
            for (int i = 0; i < 1000; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.LastSensorValueEntry, Is.LessThanOrEqualTo(40));
        }

        [Test]
        public void CreatedPh_GetNextSensorValue_GreaterThanMin()
        {
            _uut = new FakeSensor(1);
            for (int i = 0; i < 1000; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.LastSensorValueEntry, Is.GreaterThanOrEqualTo(6));
        }

        [Test]
        public void CreatedPh_GetNextSensorValue_LowerThanMax()
        {
            _uut = new FakeSensor(1);
            for (int i = 0; i < 1000; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.LastSensorValueEntry, Is.LessThanOrEqualTo(9));
        }

        [Test]
        public void CreatedChlor_GetNextSensorValue_GreaterThanMin()
        {
            _uut = new FakeSensor(2);
            for (int i = 0; i < 1000; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.LastSensorValueEntry, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void CreatedChlor_GetNextSensorValue_LowerThanMax()
        {
            _uut = new FakeSensor(2);
            for (int i = 0; i < 1000; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.LastSensorValueEntry, Is.LessThanOrEqualTo(6));
        }

        [Test]
        public void CreatedHum_GetNextSensorValue_GreaterThanMin()
        {
            _uut = new FakeSensor(3);
            for (int i = 0; i < 1000; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.LastSensorValueEntry, Is.GreaterThanOrEqualTo(30));
        }

        [Test]
        public void CreatedHum_GetNextSensorValue_LowerThanMax()
        {
            _uut = new FakeSensor(3);
            for (int i = 0; i < 1000; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.LastSensorValueEntry, Is.LessThanOrEqualTo(70));
        }
#endregion

        [Test]
        public void ReturnSensorValueList_ContainsList()
        {
            for (int i = 0; i < 9; i++)
            {
                _uut.GetNextSensorValue();
            }
            Assert.That(_uut.SensorValueList.Count, Is.EqualTo(10));
        }
        
    }
}
