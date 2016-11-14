using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vidly.BusinessLogic.BusinessLogic.Api;
using Vidly.BusinessLogic.Entities;

namespace Vidly.Tests
{
    [TestClass]
    public class MemoryApiTest
    {
        [TestMethod]
        public void AddCustomerToApiTest()
        {
            // Arrange
            MemoryApi memoryApi = new MemoryApi();
//            IEnumerable<Customer> customers = await memoryApi.getCustomers();

            int customerCount = memoryApi.getCustomers().Result.ToList().Count;

            // Act
            memoryApi.addCustomer(new Customer {Id = 0, FirstName = "Ofek", LastName = "Agmon"}).Wait();

            // Assert
            Assert.AreEqual(customerCount+1, memoryApi.getCustomers().Result.ToList().Count);

        }
    }
}
