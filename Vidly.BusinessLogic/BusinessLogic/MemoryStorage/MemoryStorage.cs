using System.Collections.Generic;
using Vidly.BusinessLogic.Entities;

namespace Vidly.BusinessLogic.BusinessLogic.MemoryStorage
{
    public class MemoryStorage
    {
        private static int customerId = 5;
        private static List<Customer> customers = new List<Customer>
            {
                new Customer {Id = 0, FirstName = "Ofek", LastName = "Agmon"},
                new Customer {Id = 1, FirstName = "Nadav", LastName = "Miran"},
                new Customer {Id = 2, FirstName = "Rom", LastName = "Shiri"},
                new Customer {Id = 3, FirstName = "Asaf", LastName = "Shalin"},
                new Customer {Id = 4, FirstName = "Aviv", LastName = "Firetag"}
            };

        private static List<Movie> movies = new List<Movie>
            {
                new Movie {Name = "The dark kngiht", Score = 8.8f},
                new Movie {Name = "Inception", Score = 9.1f}
            };


        public static void addCustomer(Customer customer)
        {
            customer.Id = customerId;
            customerId++;
            customers.Add(customer);
        }

        public static IEnumerable<Customer> getCustomers()
        {
            return customers;
        }

        public static IEnumerable<Movie> getMovies()
        {
            return movies;
        }

    }
}