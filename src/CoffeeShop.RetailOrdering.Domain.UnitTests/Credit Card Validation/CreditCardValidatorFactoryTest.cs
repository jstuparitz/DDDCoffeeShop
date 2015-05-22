using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.RetailOrdering.Domain.Credit_Card_Validation;
using NUnit.Framework;


namespace CoffeeShop.RetailOrdering.Domain.UnitTests.Credit_Card_Validation
{
    [TestFixture]
    class CreditCardValidatorFactoryTest
    {
        //BS data to make the tests compile
        private int[] intArray = { 1, 2, 3, 4, 5 };
        private DateTime mockDateTime = DateTime.Now;

        [Test]
        public void BuildMasterCardTest()
        {

            var builtObject = CreditCardValidatorFactory.build(PaymentType.Mastercard, intArray, mockDateTime);
            Assert.That(builtObject, Is.InstanceOf(typeof(MasterCardValidator)));
        }
        [Test]
        public void BuildVisaCardTest()
        {
            var builtObject = CreditCardValidatorFactory.build(PaymentType.Visa, intArray, mockDateTime);
            Assert.That(builtObject, Is.InstanceOf(typeof(VisaCardValidator)));
        }
        [Test]
        public void BuildCashTest()
        {
            var builtObject = CreditCardValidatorFactory.build(PaymentType.Cash, intArray, mockDateTime);
            Assert.Null(builtObject);
        }

    }

}
