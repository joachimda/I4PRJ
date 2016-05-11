//========================================================================
// FILENAME :   PoolValidatorTest.cs
// DESCR.   :   Unit test of PoolValidator
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using NUnit.Framework;
using Smartpool.Application.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Test.Unit
{
    [TestFixture]
    public class PoolValidatorTest
    {
        private PoolValidator _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new PoolValidator();
        }

        [Test]
        public void IsValid_CalledRightAfterConstruction_ReturnsFalse()
        {
            Assert.That(_uut.IsValid(), Is.EqualTo(false));
        }

        [TestCase("", "", false)]
        [TestCase("dennis", "", false)]
        [TestCase("", "12345-12345-12345", false)]
        [TestCase("dennis", "12345-12345-12345", true)]
        public void IsValid_CalledAfterPropertiesSetToInput_ReturnsCorrectValue(string name, string serial, bool valid)
        {
            _uut.Name = name;
            _uut.SerialNumber = serial;

            Assert.That(_uut.IsValid(), Is.EqualTo(valid));
        }

        [TestCase("0", 0)]
        [TestCase("10,5", 10.5)]
        [TestCase("-10,5", 0)]
        public void Volume_VolumeUpdated_CorrectReturnValue(string volume, double actualVolume)
        {
            _uut.UpdateVolume(volume, null);

            Assert.That(_uut.Volume, Is.EqualTo(actualVolume).Within(0.1));
        }

        [TestCase("0", "0", "0", 0)]
        [TestCase("1", "1", "1", 1)]
        [TestCase("2", "2", "2", 8)]
        public void Volume_DimensionsUpdated_CorrectReturnValue(string h, string w, string d, double actualVolume)
        {
            var dimensions = new string[] {h, w, d};
            _uut.UpdateVolume(null, dimensions);

            Assert.That(_uut.Volume, Is.EqualTo(actualVolume).Within(0.1));
        }
    }
}
