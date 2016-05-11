//========================================================================
// FILENAME :   SessionTest.cs
// DESCR.   :   Unit test of Session
//------------------------------------------------------------------------ 
// REV. AUTHOR  CHANGE DESCRIPTION
// 1.0  LP      Initial version
//========================================================================

using System;
using NUnit.Framework;
using Smartpool.Application.Model;

// ReSharper disable once CheckNamespace
namespace Smartpool.Application.Test.Unit
{
    [TestFixture]
    public class SessionTest
    {
        private Session _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = Session.SharedSession;
            _uut.Pools.Clear();
        }

        [Test]
        public void SelectedPool_CalledRightAfterConstruction_IsNull()
        {
            Assert.That(_uut.SelectedPool, Is.EqualTo(null));
        }

        [Test]
        public void SelectedPool_CalledAfterOnePoolIsAdded_ReturnsTheOnePool()
        {
            var selectedPool = new Tuple<string, bool>("Min Sjove Pool", false);
            _uut.Pools.Add(selectedPool);
            Assert.That(_uut.SelectedPool, Is.EqualTo(selectedPool));
        }
    }
}
