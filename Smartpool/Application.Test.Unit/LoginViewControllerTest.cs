//========================================================================
// FILENAME :   ILoginView.cs
// DESCR.   :   Interface for login views
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using NUnit.Framework;
using NSubstitute;
using Smartpool.Application.Presentation;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Test.Unit
{
    [TestFixture]
    public class LoginViewControllerTest
    {
        private ILoginViewController _uut;
        private ILoginView _view;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ILoginView>();
            _uut = new LoginViewController(_view);
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
    }
}
