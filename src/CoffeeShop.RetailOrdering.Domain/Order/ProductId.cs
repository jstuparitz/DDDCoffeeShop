using CoffeeShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Order
{
    public class ProductId:Identity
    {
        public ProductId():base(){}

        public ProductId(string id):base(id){}
     
    }
}
