using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.Api
{
    public class MemoryApi : IDataApi
    {
        public async Task<IEnumerable<Customer>> getCustomers()
        {
            return await Task.Run(() =>
            {
                return MemoryStorage.MemoryStorage.getCustomers();
            });
        }

        public async Task<bool> addCustomer(Customer item)
        {
            return await Task.Run(() =>
            {
                MemoryStorage.MemoryStorage.addCustomer(item);
                return true;
            });
        }

        public IEnumerable<Movie> getMovies()
        {
            return MemoryStorage.MemoryStorage.getMovies();
        }
    }
}