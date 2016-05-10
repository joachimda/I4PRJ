﻿//========================================================================
// FILENAME :   LoginViewControllerTest.cs
// DESCR.   :   Unit test of LoginViewController
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
    public class LoginViewControllerTest
    {
        private LoginViewController _uut;
        private ILoginView _view;
        private IClientMessenger _clientMessenger;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ILoginView>();
            _clientMessenger = Substitute.For<IClientMessenger>();
            _uut = new LoginViewController(_view, _clientMessenger);
            _view.Controller = _uut;
        }

        // View/Controller ViewDidLoad Interaction

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
        public void ViewDidLoad_Called_ViewLoginButtonDisabled()
        {
            _uut.ViewDidLoad();
            _view.Received().SetLoginButtonEnabled(false);
        }

        // View/Controller DidChangeText Interaction

        [TestCase("", "", false)]
        [TestCase("email", "", false)]
        [TestCase("", "password", false)]
        [TestCase("email", "password", true)]
        public void DidChangeText_WithArguments_LoginButtonUpdated(string email, string password, bool enabled)
        {
            _uut.DidChangeEmailText(email);
            _uut.DidChangePasswordText(password);
            _view.Received().SetLoginButtonEnabled(enabled);
        }

        // Login

        [Test]
        public void Login_Accepted_LoginAcceptedCalledOnView()
        {
            _clientMessenger.SendMessage(new LoginRequestMsg("","")).ReturnsForAnyArgs(new LoginResponseMsg("",true));
            _uut.Login();
            _view.Received().LoginAccepted();
        }

        [Test]
        public void Login_Declined_DisplayAlertCalledOnView()
        {
            _clientMessenger.SendMessage(new LoginRequestMsg("", "")).ReturnsForAnyArgs(new LoginResponseMsg("", false));
            _uut.Login();
            _view.ReceivedWithAnyArgs().DisplayAlert("","");
        }

        // ButtonPressed

        [TestCase(LoginViewButton.LoginButton)]
        [TestCase(LoginViewButton.SignUpButton)]
        [TestCase(LoginViewButton.ForgotButton)]
        public void ButtonPressed_ValidArgument_NoExceptions(LoginViewButton button)
        {
            _clientMessenger.SendMessage(new LoginRequestMsg("", "")).ReturnsForAnyArgs(new LoginResponseMsg("", false));
            _uut.ButtonPressed(button);
        }

        [Test]
        public void ButtonPressed_InvalidArgument_DisplayAlertCalledOnView()
        {
            var invalidKey = 999;
            _uut.ButtonPressed(LoginViewButton.ForgotButton + invalidKey);
            _view.ReceivedWithAnyArgs().DisplayAlert("","");
        }
    }
}
