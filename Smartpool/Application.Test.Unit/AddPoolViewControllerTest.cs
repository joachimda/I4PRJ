//========================================================================
// FILENAME :   AddPoolViewControllerTest.cs
// DESCR.   :   Unit test of AddPoolViewControllerTest
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using NUnit.Framework;
using NSubstitute;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Test.Unit
{
    [TestFixture]
    public class AddPoolViewControllerTest
    {
        private AddPoolViewController _uut;
        private IAddPoolView _view;
        private IClientMessager _clientMessager;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IAddPoolView>();
            _clientMessager = Substitute.For<IClientMessager>();
            _uut = new AddPoolViewController(_view, _clientMessager);
            _view.Controller = _uut;
        }

        // View/Controller ViewDidLoad Interaction

        [Test]
        public void ViewDidLoad_Called_AddPoolButtonDisabled()
        {
            _uut.ViewDidLoad();
            _view.Received().SetAddPoolButtonEnabled(false);
        }

        // View/Controller TextChanged Interaction

        [TestCase("100,5", 100.5)]
        [TestCase("0", 0)]
        [TestCase("-100,23", -100.23)]
        public void ActualVolume_VolumeTextChanged_ActualVolumeCorrectValue(string text, double volume)
        {
            _uut.DidChangeText(AddPoolTextField.Volume, text);
            Assert.That(_uut.PoolToBeAdded.Volume, Is.EqualTo(volume).Within(0.1));
        }

        [TestCase("10", "10", "10", 1000)]
        [TestCase("charmander", "10", "10", 0)]
        [TestCase("10", "bulbasaur", "10", 0)]
        [TestCase("10", "10", "squirtle", 0)]
        public void ActualVolume_DimensionTextChanged_ActualVolumeCorrectValue(string width, string length, string depth, double volume)
        {
            _uut.DidChangeText(AddPoolTextField.Width, width);
            _uut.DidChangeText(AddPoolTextField.Length, length);
            _uut.DidChangeText(AddPoolTextField.Depth, depth);
            Assert.That(_uut.PoolToBeAdded.Volume, Is.EqualTo(volume).Within(0.1));
        }

        [TestCase("109,23", 109.23)]
        public void ActualVolume_VolumeTextChangedAfterDimensions_VolumeCorrectValue(string volumeText, double volume)
        {
            _uut.DidChangeText(AddPoolTextField.Width, "10");
            _uut.DidChangeText(AddPoolTextField.Length, "10");
            _uut.DidChangeText(AddPoolTextField.Depth, "10");
            _uut.DidChangeText(AddPoolTextField.Volume, volumeText);
            Assert.That(_uut.PoolToBeAdded.Volume, Is.EqualTo(volume).Within(0.1));
        }

        // Required text field filled tests

        [Test]
        public void SetAddPoolButtonEnabled_RequiredTextChanged_ViewReceivedEnableButtonCall()
        {
            _uut.DidChangeText(AddPoolTextField.PoolName, "Den Sjove Pool");
            _uut.DidChangeText(AddPoolTextField.SerialNumber, "12345-67890-12345");
            _view.Received().SetAddPoolButtonEnabled(true);
        }
    }
}
