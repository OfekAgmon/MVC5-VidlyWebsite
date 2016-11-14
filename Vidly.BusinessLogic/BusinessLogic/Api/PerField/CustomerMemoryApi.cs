using System.Collections.Generic;
using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.Api.PerField
{
    public class CustomerMemoryApi : ICustomerApi<Customer>
    {

        public IEnumerable<Customer> getData()
        {
            return MemoryStorage.MemoryStorage.getCustomers();
        }

        public void addItem(Customer item)
        {
            MemoryStorage.MemoryStorage.addCustomer(item);
        }
    }
}