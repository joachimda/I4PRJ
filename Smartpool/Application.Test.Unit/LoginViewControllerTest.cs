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
            _uut = new LoginViewController(_view);
        }
    }
}
