//========================================================================
// FILENAME :   SignUpViewControllerTest.cs
// DESCR.   :   Unit test of SignUpViewController
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
    public class SignUpViewControllerTest
    {
        private SignUpViewController _uut;
        private ISignUpView _view;
        private IClientMessenger _clientMessenger;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ISignUpView>();
            _clientMessenger = Substitute.For<IClientMessenger>();
            _uut = new SignUpViewController(_view, _clientMessenger);
            _view.Controller = _uut;
        }

        // View/Controller ViewDidLoad Interaction

        [Test]
        public void ViewDidLoad_Called_ViewNameTextReset()
        {
            _uut.ViewDidLoad();
            _view.Received().SetNameText("");
        }

        [Test]
        public void ViewDidLoad_Called_ViewEmailTextReset()
        {
            _uut.ViewDidLoad();
            _view.Received().SetEmailText("");
        }

        [Test]
        public void ViewDidLoad_Called_ViewPasswordTextReset()
        {
            _uut.ViewDidLoad();
            _view.Received().SetPasswordText("");
        }

        [Test]
        public void ViewDidLoad_Called_ViewButtonDisabled()
        {
            _uut.ViewDidLoad();
            _view.Received().SetButtonEnabled(false);
        }

        [Test]
        public void ViewDidLoad_Called_ViewPasswordInvalid()
        {
            _uut.ViewDidLoad();
            _view.Received().SetPasswordValid(false);
        }

        // View/Controller PasswordValid Interaction

        [TestCase("ajax", "xaja", false)]
        [TestCase("ajax", "ajax", false)]
        [TestCase("ajax1234", "ajax4321", false)]
        [TestCase("ajax1234", "ajax1234", true)]
        [TestCase("validpassword", "validpassword", true)]
        public void DidChangeText_WithArguments_LoginButtonUpdated(string passwordOne, string passwordTwo, bool valid)
        {
            _uut.DidChangePasswordText(passwordOne, 0);
            _uut.DidChangePasswordText(passwordTwo, 1);
            _view.Received().SetPasswordValid(valid);
        }

        // ButtonPressed

        public void ButtonPressed_Called_NoExceptions()
        {
            _clientMessenger.SendMessage(new AddUserRequestMsg("", "", "")).ReturnsForAnyArgs(new GeneralResponseMsg(false, true));
            _uut.ButtonPressed();
        }
    }
}
