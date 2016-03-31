using NUnit.Framework;

namespace CreditcardValidationTest
{
    [TestFixture]
    public class CreditcardValidationTest
    {
        private CreditcardValidation.CreditcardValidation _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new CreditcardValidation.CreditcardValidation();
        }
    }
}
