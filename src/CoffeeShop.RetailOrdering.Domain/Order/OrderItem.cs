using CoffeeShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Order
{
    class OrderItem
    {
        public Product product{get;private set;}
        public double price { get; private set { setPrice(value); } }
        public int quantity { get; private set { setQuantity(value); } }
        public Size size{get;private set;}

        OrderItem(Product product, double price, int quantity,Size size)
        {
            this.product=product;
            this.price=price;
            this.quantity=quantity;
            this.size=size;
        }
        private void setProduct(Product product)
        {
            this.product = product;
        }
        private void setPrice(double price)
        {
            AssertionConcern.AssertArgumentRange(price, 1, double.MaxValue, "Price must be greater than 0");
            this.price = price;
        }
        private void setQuantity(int quantity)
        {
            AssertionConcern.AssertArgumentRange(quantity, 1, 500, "Quantity must be 1-500");
            this.quantity = quantity;
        }

    }
}
