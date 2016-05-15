//========================================================================
// FILENAME :   EditUserViewControllerTest.cs
// DESCR.   :   Unit test of EditUserViewController
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
    public class EditUserViewControllerTest
    {
        private EditUserViewController _uut;
        private IEditUserView _view;
        private IClientMessenger _clientMessenger;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IEditUserView>();
            _clientMessenger = Substitute.For<IClientMessenger>();
            _uut = new EditUserViewController(_view, _clientMessenger);
            _view.Controller = _uut;
        }

        // View/Controller ViewDidLoad Interaction

        [Test]
        public void ViewDidLoad_Called_ViewTextCleared()
        {
            _uut.ViewDidLoad();
            _view.Received().ClearAllText();
        }

        [Test]
        public void ViewDidLoad_Called_PasswordSetInvalid()
        {
            _uut.ViewDidLoad();
            _view.Received().SetNewPasswordValid(false);
        }

        [Test]
        public void ViewDidLoad_Called_SaveButtonDisabled()
        {
            _uut.ViewDidLoad();
            _view.Received().SetSaveButtonEnabled(false);
        }
    }
}
