//========================================================================
// FILENAME :   StatViewControllerTest.cs
// DESCR.   :   Unit test of StatViewControllerTest
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using Smartpool.Application.Model;
using Smartpool.Application.Presentation;
using Smartpool.Connection.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Test.Unit
{
    [TestFixture]
    public class StatViewControllerTest
    {
        private StatViewController _uut;
        private IStatView _view;
        private IClientMessenger _clientMessenger;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IStatView>();
            _clientMessenger = Substitute.For<IClientMessenger>();
            _uut = new StatViewController(_view, _clientMessenger);
            _view.Controller = _uut;
        }

        // View/Controller ViewDidLoad Interaction

        [Test]
        public void DidSelectPool_CalledForFirstPoolInSession_CorrectPoolInSession()
        {
            var session = Session.SharedSession;
            session.Pools = new List<Tuple<string, bool>>() {new Tuple<string, bool>("Min Sjove Pool", false), new Tuple<string, bool>("Charmander", false)};

            _clientMessenger.SendMessage(new Message())
                .ReturnsForAnyArgs(new GetPoolDataResponseMsg(new List<Tuple<SensorTypes, List<double>>>()));

            _uut.DidSelectPool("Min Sjove Pool");

            Assert.That(session.SelectedPool.Item1, Is.EqualTo("Min Sjove Pool"));
        }
    }
}
