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
    public class MasterCardValidatorTest
    {
        private static readonly DateTime futureDate = new DateTime(2020, 6, 3, 22, 15, 0);
        private static readonly DateTime pastDate = new DateTime(1996, 6, 3, 22, 15, 0);

        //Valid MC numbers
        //5396463360455548
        //5453394492221229
        //5257914654194498

        private static object[] ValidTestCases = 
            {
                new object[] { new int[] { 5,3,9,6,4,6,3,3,6,0,4,5,5,5,4,8 }, futureDate },
                new object[] { new int[] { 5,4,5,3,3,9,4,4,9,2,2,2,1,2,2,9 }, futureDate },
                new object[] { new int[] { 5,2,5,7,9,1,4,6,5,4,1,9,4,4,9,8 }, futureDate }
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
            var ccValidator = new MasterCardValidator(cn, expDate);
            Assert.IsTrue(ccValidator.validate());
        }

        [Test, TestCaseSource("InvalidCardNumberTestCases")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidCardNumberTests( int[] cn, DateTime expDate)
        {
            var ccValidator = new MasterCardValidator(cn,expDate);
            ccValidator.validate();
        }
        [Test, TestCaseSource("InvalidExpirationDateTestCases")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidExpirationDateTests(int[] cn, DateTime expDate)
        {
            var ccValidator = new MasterCardValidator(cn,expDate);
            ccValidator.validate();

        }


    }
}
