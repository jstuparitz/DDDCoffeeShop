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
       
        public CustomerInfo(string firstName, string lastName, string email)
        {
            setFirstName(firstName);
            setLastName(lastName);
         
        }

         private void setFirstName(string firstName)
        {
            this.FirstName = firstName;
        }
         private void setLastName(string lastName)
        {
            this.LastName = lastName;
        }
  

    }
}
