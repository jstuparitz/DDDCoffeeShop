using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Order
{
    class Product
    {
        public int productId;
        private double cost;
        private string name;
        private Size size;

        public Product(int id,double cost, string name, Size size)
        {
            this.setProductId(id);
            this.setCost(cost);
            this.setName(name);
            this.setSize(size);
        }
        private void setProductId(int id)
        {
            this.productId = id;
        }
        private void setCost(double cost)
        {
            this.cost = cost;
        }
        private void setName(string  name)
        {
            this.name = name;
        }
        private void setSize(Size size)
        {
            this.size = size;
        }
        
        
        
    }
}
