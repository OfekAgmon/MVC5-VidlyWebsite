using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Vidly.BusinessLogic.BusinessLogic.Parser;
using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.Api
{
    public class WebRestApi : IDataApi
    {
        private IJsonParser _jsonParser;

        public WebRestApi(IJsonParser jsonParser)
        {
            _jsonParser = jsonParser;
        }

        public async Task<IEnumerable<Customer>> getCustomers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://demo0636357.mockable.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("customers/");

                if (response.IsSuccessStatusCode)
                    return _jsonParser.ParseCustomers(response);
            }
            return null;
        }

        public async Task<bool> addCustomer(Customer item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://httpbin.org/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string customerJson = _jsonParser.CustomerToJsonString(item);
                HttpResponseMessage response = await client.PostAsync("post", new StringContent(customerJson));

                if (response.IsSuccessStatusCode)
                    return true;

                return false;

            }
        }

        public IEnumerable<Movie> getMovies()
        {
            throw new NotImplementedException();
        }
    }
}