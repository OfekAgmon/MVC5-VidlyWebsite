using System.Collections.Generic;
using System.Net.Http;
using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.Parser
{
    public interface IJsonParser
    {
        IEnumerable<Customer> ParseCustomers(HttpResponseMessage response);

        string CustomerToJsonString(Customer customer);
    }
}
