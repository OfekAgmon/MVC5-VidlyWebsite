using System.Collections.Generic;
using System.Threading.Tasks;
using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.Api
{
    public interface IDataApi
    {
        Task<IEnumerable<Customer>> getCustomers();
        Task<bool> addCustomer(Customer item);

        IEnumerable<Movie> getMovies();
    }
}
