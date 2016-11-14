using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.Parser
{
    public class DummyRestJsonParser : IJsonParser
    {
        public IEnumerable<Customer> ParseCustomers(HttpResponseMessage response)
        {
            string json = response.Content.ReadAsStringAsync().Result;
            JArray customers = JArray.Parse(json);
            IList<Customer> customerObjList = Enumerable.ToList<Customer>(customers.Select(c => new Customer
            {
                Id = (int)c["customerId"],
                FirstName = (string)c["firstName"],
                LastName = (string)c["lastName"]

            }));
            return customerObjList;
        }

        public string CustomerToJsonString(Customer customer)
        {
            return JsonConvert.SerializeObject(customer);
        }
    }
}