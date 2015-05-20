using CoffeeShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Credit_Card_Validation
{
    abstract class CreditCardValidator
    {

        protected List<int> cardNumber;
        protected DateTime expirationDate;
        protected int[] DELTAS = { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };

        protected readonly string EXPIRED_ERROR_MESSAGE = "This credit card has expired.";
        protected readonly string INVALID_CARD_NUMBER_ERROR_MESSAGE = "Invalid credit card number.";
        protected readonly string INVALID_CARD_NUMBER_LENGTH_ERROR_MESSAGE = "Invalid credit card number length.";



        public CreditCardValidator(int[] newCardNumber, DateTime newExpirationDate)
        {
            cardNumber = newCardNumber.ToList<int>();
            expirationDate = newExpirationDate;
        }

        abstract protected void validate();


        /// <summary>
        /// Based on Ligilo's post here:
        /// http://microcoder.livejournal.com/17175.html
        /// </summary>
        protected void LuhnCreditCardValidation()
        {
            long checkSum = 0;

            for (int i = 0; i < cardNumber.Count;i++)
            {
                int number = cardNumber[i];
                checkSum += number;
                if ( (i % 2) == 1)
                {
                    checkSum += DELTAS[number];
                }

            }
            AssertionConcern.AssertArgumentTrue(((checkSum % 10) == 0),INVALID_CARD_NUMBER_ERROR_MESSAGE);
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
            AssertionConcern.AssertArgumentTrue(currentDate.Month <= expirationDate.Month, EXPIRED_ERROR_MESSAGE);
            AssertionConcern.AssertArgumentTrue(currentDate.Day < expirationDate.Day,EXPIRED_ERROR_MESSAGE);
        }


    }
}
