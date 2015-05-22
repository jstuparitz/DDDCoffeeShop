using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Credit_Card_Validation
{
    class CreditCardValidatorFactory
    {

        public static CreditCardValidator build(PaymentType newPaymentType, int[] newCardNumber, DateTime newExpirationDate)
        {

            if (newPaymentType.Equals(PaymentType.Mastercard))
            {
                return new MasterCardValidator(newCardNumber, newExpirationDate);
            }else if(newPaymentType.Equals(PaymentType.Visa))
            {
                return new VisaCardValidator(newCardNumber, newExpirationDate);
            }else
            {
                return null;
            }

        }


    }
}
