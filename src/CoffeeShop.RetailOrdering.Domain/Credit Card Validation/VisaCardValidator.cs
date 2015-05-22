using CoffeeShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Credit_Card_Validation
{
    class VisaCardValidator : CreditCardValidator
    {
        private readonly int MAX_LENGTH_OF_CARD_NUMBER = 16;
        private readonly int MIN_LENGTH_OF_CARD_NUMBER = 13;

        public VisaCardValidator(int[] newCardNumber,DateTime newExpirationDate) 
            : base(newCardNumber,newExpirationDate) { }

        public override void validate()
        {
            AssertionConcern.AssertArgumentRange(cardNumber.Count,
                                                 MIN_LENGTH_OF_CARD_NUMBER,
                                                 MAX_LENGTH_OF_CARD_NUMBER,
                                                 INVALID_CARD_NUMBER_LENGTH_ERROR_MESSAGE);

            string startOfCardNumber = cardNumber[0].ToString();
            AssertionConcern.AssertArgumentEquals("4",startOfCardNumber, INVALID_CARD_NUMBER_ERROR_MESSAGE);

            CheckExpirationDate();
            LuhnCreditCardValidation();
        }
    }
}
