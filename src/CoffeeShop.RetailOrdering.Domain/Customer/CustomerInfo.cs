using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.RetailOrdering.Domain.Customer
{
    class CustomerInfo
    {
        public string FirstName;
        public string LastName;
        public string Email;

           public Custo1mer(string firstName, string lastName, string email)
           {
                FirstName = firstName;
                lastName = lastName;
                Email = email;
           }

    }
}
