using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.Factory.Cstomers
{
    public interface ICustomerFactory
    {
        Customer createCustomer(string firstName, string lastName);
    }
}
