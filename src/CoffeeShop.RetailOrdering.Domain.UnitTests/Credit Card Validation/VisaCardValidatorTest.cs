using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CoffeeShop.RetailOrdering.Domain.Credit_Card_Validation;

namespace CoffeeShop.RetailOrdering.Domain.UnitTests.Credit_Card_Validation
{
    [TestFixture]
    public class VisaCardValidatorTest
    {

        private static readonly DateTime futureDate = new DateTime(2020, 6, 3, 22, 15, 0);
        private static readonly DateTime pastDate = new DateTime(1996, 6, 3, 22, 15, 0);

        //Valid Visa Numbers
        //4485170117802550
        //4929420135431278
        //4716878626817452

        private static object[] ValidTestCases = 
            {
                new object[] { new int[] { 4,4,8,5,1,7,0,1,1,7,8,0,2,5,5,0 }, futureDate },
                new object[] { new int[] { 4,9,2,9,4,2,0,1,3,5,4,3,1,2,7,8 }, futureDate },
                new object[] { new int[] { 4,7,1,6,8,7,8,6,2,6,8,1,7,4,5,2 }, futureDate }
            };

        private static object[] InvalidCardNumberTestCases =
            {
                new object[] { new int[] { 1, 2, 3, 4, 5 }, futureDate },
                new object[] { new int[] { 0, 0, 0, 0, 0 }, futureDate },
                new object[] { new int[] { 9,5,8,2,3,3,2,3,2,4,3,7,6,4,3,5 }, futureDate },
                new object[] { new int[] { 5, 5, 8, 2, 3, 3, 2, 3, 2, 4, 3, 7, 7, 4, 3, 5 }, futureDate }
            };
        private static object[] InvalidExpirationDateTestCases =
            {
                new object[] { new int[] { 5, 5, 8, 2, 3, 3, 2, 3, 2, 4, 3, 3, 7, 4, 3, 5 }, pastDate },
                new object[] { new int[] { 5, 5, 8, 2, 3, 3, 2, 3, 2, 4, 3, 3, 7, 4, 3, 5 }, DateTime.UtcNow },
                new object[] { new int[] { 5, 5, 8, 2, 3, 3, 2, 3, 2, 4, 3, 3, 7, 4, 3, 5 }, DateTime.Now }
            };

        [Test, TestCaseSource("ValidTestCases")]
        public void ValidCardNumberTests(int[] cn, DateTime expDate)
        {
            var ccValidator = new VisaCardValidator(cn, expDate);
            Assert.IsTrue(ccValidator.validate());
        }

        [Test, TestCaseSource("InvalidCardNumberTestCases")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidCardNumberTests(int[] cn, DateTime expDate)
        {
            var ccValidator = new VisaCardValidator(cn, expDate);
            ccValidator.validate();
        }
        [Test, TestCaseSource("InvalidExpirationDateTestCases")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidExpirationDateTests(int[] cn, DateTime expDate)
        {
            var ccValidator = new VisaCardValidator(cn, expDate);
            ccValidator.validate();

        }

    }
}
