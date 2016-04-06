//========================================================================
// FILENAME :   LoginViewControllerTest.cs
// DESCR.   :   Unit test of LoginViewController
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using NUnit.Framework;
using NSubstitute;
using Smartpool.Application.Model;
using Smartpool.Application.Presentation;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Test.Unit
{
    [TestFixture]
    public class LoginViewControllerTest
    {
        private LoginViewController _uut;
        private ILoginView _view;
        private IAuthenticator _authenticator;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ILoginView>();
            _authenticator = Substitute.For<IAuthenticator>();
            _uut = new LoginViewController(_view, _authenticator);
        }

        // Life Cycle

        [TestCase()]
        public void Constructor_Performed_ControllerSetForView()
        {
            _view.Received().Controller = _uut;
        }

        [TestCase()]
        public void ViewDidLoad_Performed_LoginButtonDisabledOnView()
        {
            _uut.ViewDidLoad();
            _view.Received().SetLoginButtonEnabled(false);
        }

        // Interface

        [TestCase("","")]
        [TestCase("john@doe.com", "johndoe123")]
        public void ButtonPressed_LoginButtonArgument_AuthenticateCalled(string email, string password)
        {
            _uut.DidChangeEmailText(email);
            _uut.DidChangePasswordText(password);
            _uut.ButtonPressed(LoginViewButton.LoginButton);
            _authenticator.Received().Authenticate(email, password);
        }

        [TestCase("", "", false)]
        [TestCase("john@doe.com", "", false)]
        [TestCase("", "johndoe123", false)]
        [TestCase("john@doe.com", "johndoe123", true)]
        public void DidChangeText_EmailAndPasswordChanged_ViewLoginButtonStateSet(string email, string password, bool loginButtonEnabled)
        {
            _uut.DidChangeEmailText(email);
            _uut.DidChangePasswordText(password);
            _view.Received().SetLoginButtonEnabled(loginButtonEnabled);
        }

        // LoginViewController
    }
}
