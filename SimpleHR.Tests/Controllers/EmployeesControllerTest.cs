using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleHR;
using SimpleHR.Controllers;
using PagedList;

namespace SimpleHR.Tests.Controllers
{
    [TestClass]
    public class EmployeesControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            // Arrange
            EmployeesController controller = new EmployeesController();

            // Act
            ViewResult result = controller.Index("", "", "", null) as ViewResult;
            PagedList.IPagedList<SimpleHR.Models.Employee> employees = result.Model as PagedList.IPagedList<SimpleHR.Models.Employee>;

            // Assert
            Assert.IsNotNull(employees.Count > 0);
        }
    }
}
