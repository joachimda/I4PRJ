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
    public class SensorValueAuthenticatorUnitTest
    {
        private SensorValueAuthenticator _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new SensorValueAuthenticator();
        }
        
        [TestCase(40)]
        [TestCase(41)]
        public void Auth_TempInput_ReturnsWithinMax(double temp)
        {
            Assert.That(_uut.Auth(SensorTypes.Temperature, temp), Is.LessThanOrEqualTo(40));
        }

        [TestCase(19)]
        [TestCase(20)]
        public void Auth_TempInput_ReturnsWithinMin(double temp)
        {
            Assert.That(_uut.Auth(SensorTypes.Temperature, temp), Is.AtLeast(20));
        }

        [TestCase(9)]
        [TestCase(9.1)]
        public void Auth_PhInput_ReturnsWithinMax(double ph)
        {
            Assert.That(_uut.Auth(SensorTypes.Ph, ph), Is.LessThanOrEqualTo(9));
        }

        [TestCase(5.9)]
        [TestCase(6)]
        public void Auth_PhInput_ReturnsWithinMin(double ph)
        {
            Assert.That(_uut.Auth(SensorTypes.Ph, ph), Is.AtLeast(6));
        }
        
        [TestCase(6)]
        [TestCase(6.1)]
        public void Auth_ChlorInput_ReturnsWithinMax(double chlor)
        {
            Assert.That(_uut.Auth(SensorTypes.Chlorine, chlor), Is.LessThanOrEqualTo(6));
        }
        
        [TestCase(0)]
        [TestCase(-0.1)]
        public void Auth_ChlorInput_ReturnsWithinMin(double chlor)
        {
            Assert.That(_uut.Auth(SensorTypes.Chlorine, chlor), Is.AtLeast(0));
        }
        
        [TestCase(70.1)]
        [TestCase(70)]
        public void Auth_HumInput_ReturnsWithinMax(double hum)
        {
            Assert.That(_uut.Auth(SensorTypes.Humidity, hum), Is.LessThanOrEqualTo(70));
        }
        
        [TestCase(29.9)]
        [TestCase(30)]
        public void Auth_HumInput_ReturnsWithinMin(double hum)
        {
            Assert.That(_uut.Auth(SensorTypes.Humidity, hum), Is.AtLeast(30));
        }
    }
}
