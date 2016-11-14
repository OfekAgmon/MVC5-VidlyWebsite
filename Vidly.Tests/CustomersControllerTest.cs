using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vidly.App_Start;
using Vidly.BusinessLogic.BusinessLogic.Api;
using Vidly.BusinessLogic.BusinessLogic.Factory.Cstomers;
using Vidly.BusinessLogic.Entities;
using Vidly.Controllers;

namespace Vidly.Tests
{
    [TestClass]
    public class CustomersControllerTest
    {

        [TestMethod]
        public void CustomersIndexListCountTest()
        {
            //Arrange
            Mock<IDataApi> dataMock = new Mock<IDataApi>();
            dataMock.Setup(d => d.getCustomers()).ReturnsAsync(new List<Customer>
            {
                new Customer {Id = 0, FirstName = "Ofek", LastName = "Agmon"},
                new Customer {Id = 1, FirstName = "Nadav", LastName = "Miran"},
                new Customer {Id = 2, FirstName = "Rom", LastName = "Shiri"},
                new Customer {Id = 3, FirstName = "Asaf", LastName = "Shalin"},
                new Customer {Id = 4, FirstName = "Aviv", LastName = "Firetag"}
            });

            Mock<ICustomerFactory> customerFactoryMock = new Mock<ICustomerFactory>();

            CustomersController customersController = new CustomersController(dataMock.Object, customerFactoryMock.Object);

            // Act
            var result = customersController.Index().Result as ViewResult;

            // Assert
            var model = result.ViewData.Model as List<Customer>;
            Assert.IsTrue(model.Count == 5);
        }

        [TestMethod]
        public void CustomerAccessInvalidIdTest()
        {
            //Arrange
            Mock<IDataApi> dataMock = new Mock<IDataApi>();
            dataMock.Setup(d => d.getCustomers()).ReturnsAsync(new List<Customer>
            {
                new Customer {Id = 0, FirstName = "Ofek", LastName = "Agmon"}
            });
            Mock<ICustomerFactory> customerFactoryMock = new Mock<ICustomerFactory>();

            CustomersController customersController = new CustomersController(dataMock.Object, customerFactoryMock.Object);

            // Act
            var resultNegative = customersController.Details(-1); // negative id
            var resultOutOfIndex = customersController.Details(1); // id doesn't exist

            // Assert
            Assert.IsInstanceOfType(resultNegative.Result, typeof(HttpNotFoundResult));
            Assert.IsInstanceOfType(resultOutOfIndex.Result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void AddCustomerRedirectsToIndexTest()
        {
            // Arrange
            Mock<IDataApi> dataMock = new Mock<IDataApi>();
            dataMock.Setup(d => d.getCustomers()).ReturnsAsync(new List<Customer>
            {
                new Customer {Id = 0, FirstName = "Ofek", LastName = "Agmon"}
            });
            dataMock.Setup(d => d.addCustomer(It.IsAny<Customer>())).ReturnsAsync(true);
            Mock<ICustomerFactory> customerFactoryMock = new Mock<ICustomerFactory>();

            // Act
            CustomersController customersController = new CustomersController(dataMock.Object, customerFactoryMock.Object);
            var createResult = customersController.Create("New", "Customer");

            // Assert
            Assert.IsInstanceOfType(createResult.Result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = createResult.Result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
        }
    }
}
