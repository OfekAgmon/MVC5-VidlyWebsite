using System.Collections.Generic;

namespace Vidly.BusinessLogic.BusinessLogic.Api.PerField
{
    public interface ICustomerApi<T>
    {
        IEnumerable<T> getData();
        void addItem(T item);
    }
}
