using CoffeeShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoffeeShop.RetailOrdering.Domain.Payment_Information
{
    class PaymentInformation : ValueObject
    {

        //Do these need to be readonly?
        private BillingInformation creditCardBillingInformation;
        private DateTime paymentDate;

        public PaymentInformation(BillingInformation newBillingInfo, DateTime newPaymentDate)
        {
            creditCardBillingInformation = newBillingInfo;
            //May want to verify that the payment date has not passed the expiration date
            paymentDate = newPaymentDate;
        }

        protected override IEnumerable<object> GetEqualityComponents(){

            List<object> equalityComponents = new List<object>();

            equalityComponents.Add(creditCardBillingInformation);
            equalityComponents.Add(paymentDate);

            return equalityComponents;

        }

    }
}
