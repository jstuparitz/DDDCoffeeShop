using CoffeeShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Credit_Card_Validation
{
    public abstract class CreditCardValidator
    {

        protected List<int> cardNumber;
        protected DateTime expirationDate;

        protected readonly string EXPIRED_ERROR_MESSAGE = "This credit card has expired.";
        protected readonly string INVALID_CARD_NUMBER_ERROR_MESSAGE = "Invalid credit card number.";
        protected readonly string INVALID_CARD_NUMBER_LENGTH_ERROR_MESSAGE = "Invalid credit card number length.";



        public CreditCardValidator(int[] newCardNumber, DateTime newExpirationDate)
        {
            cardNumber = newCardNumber.ToList<int>();
            expirationDate = newExpirationDate;
        }

        abstract public bool validate();


        /// <summary>
        /// Based on Ligilo's post here:
        /// http://microcoder.livejournal.com/17175.html
        /// and this implementation 
        /// http://orb-of-knowledge.blogspot.com/2009/08/extremely-fast-luhn-function-for-c.html
        /// </summary>
        protected void LuhnCreditCardValidation()
        {
            var checkSum = 0;
            var alt = false;


            for (int i = cardNumber.Count - 1; i >= 0; i--)
            {
                var curDigit = cardNumber[i];
                if (alt)
                {
                    curDigit *= 2;
                    if (curDigit > 9)
                        curDigit -= 9;
                }
                checkSum += curDigit;
                alt = !alt;
            }
            bool creditCardFinalCheck = ((checkSum % 10) == 0);
            AssertionConcern.AssertStateTrue(creditCardFinalCheck,INVALID_CARD_NUMBER_ERROR_MESSAGE);
        }

        /// <summary>
        /// Simple check against DateTime.UTC to make sure the credit card has not expired.
        /// Passing citeria for this test is the current day is not equal to the expiration day
        /// and the current month is not less than the expiration month.
        /// 
        /// Limitations: assumes date format in UTC NOW
        /// </summary>
        protected void CheckExpirationDate()
        {
            DateTime currentDate = DateTime.UtcNow;
            int comparisonResult = currentDate.CompareTo(expirationDate);
            AssertionConcern.AssertArgumentTrue(comparisonResult < 0, EXPIRED_ERROR_MESSAGE);
        }


    }
}
