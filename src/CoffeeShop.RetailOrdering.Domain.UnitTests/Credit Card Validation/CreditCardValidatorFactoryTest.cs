using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.RetailOrdering.Domain;


namespace CoffeeShop.RetailOrdering.Domain.UnitTests.Credit_Card_Validation
{
    class CreditCardValidatorFactoryTest
    {

        public object[] testData = { new TestPaymentDTO(PaymentType.Visa,null,DateTime.Now),
                                    new TestPaymentDTO(PaymentType.Mastercard,null,DateTime.Now),
                                    new TestPaymentDTO(PaymentType.Cash,null,DateTime.Now)
                                    };

        public void BuildMasterCardTest()
        {
            var builtObject = Credit.build(PaymentType.Mastercard, null, null);

        }

        public void BuildVisaCardTest()
        {

        }

        public void BuildCashTest()
        {

        }

        public void BuildNullTest()
        {

        }

    }

    class TestPaymentDTO
    {
         PaymentType paymentType { get; set; }
         int[] cardNumber { get; set; }
         DateTime expDate { get; set; }

         public TestPaymentDTO(PaymentType pt, List<int> cn, DateTime expD)
         {
             paymentType = pt;
             cardNumber = cn.ToArray<int>();
             expDate = expD;
         }


    }

}
