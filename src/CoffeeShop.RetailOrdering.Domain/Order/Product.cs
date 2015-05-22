using CoffeeShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Order
{
    public class Product:Entity
    {
        public ProductId productId { get; private set; }
        public double cost { get; private set { setCost(value); } }
        public string name { get; private set { setName(value); } }
        public Size size { get; private set; }

        public Product(ProductId productId,double cost, string name, Size size)
        {
            this.productId=productId;
            this.cost=cost;
            this.name=name;
            this.size=size;
        }
        private void setCost(double cost)
        {
            AssertionConcern.AssertArgumentRange(cost, 1, double.MaxValue, "Cost must be greater than 0");
            this.cost = cost;
        }
        private void setName(string  name)
        {
            AssertionConcern.AssertArgumentLength(name, 1,25, "Name must be 1-25 characters long");
            this.name = name;
        }
                     
    }
}
