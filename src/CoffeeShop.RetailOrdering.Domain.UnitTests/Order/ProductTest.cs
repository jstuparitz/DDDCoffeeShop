using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.RetailOrdering.Domain.Order;

namespace CoffeeShop.RetailOrdering.Domain.UnitTests.Order
{   
    [TestFixture]
    class ProductTest
    {
        [Test]
        public void Invalid_Cost_Should_Throw_Exception()
        {
            try
            {
                new Product(new ProductId(), -24.2, "invalid", Size.Large);
                Assert.Fail();
            }
            catch(InvalidOperationException e)
            {
                
            }
        }
        [Test]
        public void Invalid_Name_Should_Throw_Exception()
        {
            try
            {
                new Product(new ProductId(), 24.2, "", Size.Large);
                Assert.Fail();
            }
            catch (InvalidOperationException e)
            {

            }
        }
    }
}
