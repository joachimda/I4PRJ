using NUnit.Framework;

namespace Calculator.Test.Unit
{
    [TestFixture]
    public class CalculatorTestUnit
    {
        private CalculatorProject.Calculator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new CalculatorProject.Calculator();
        }

        [TestCase(1, 1, 2)]
        [TestCase(2, 1, 3)]
        [TestCase(3, 1, 4)]
        [TestCase(4, 1, 5)]
        [TestCase(5, 1, 6)]
        public void Add_AddTwoNumbers_ReturnCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Add(a,b), Is.EqualTo(result));
        }
    }
}
