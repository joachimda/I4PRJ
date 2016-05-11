//========================================================================
// FILENAME :   PoolValidatorTest.cs
// DESCR.   :   Unit test of PoolValidator
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
    }
}
