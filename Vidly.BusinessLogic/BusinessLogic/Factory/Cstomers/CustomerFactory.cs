using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.Factory.Cstomers
{
    public class CustomerFactory : ICustomerFactory
    {
        public Customer createCustomer(string firstName, string lastName)
        {
            return new Customer { FirstName = firstName, LastName = lastName };
        }
    }
}