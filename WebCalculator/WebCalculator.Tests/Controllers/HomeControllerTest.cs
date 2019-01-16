using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebCalculator;
using WebCalculator.Controllers;
using Moq;
using ICalculatorRepository;
using System.Threading.Tasks;

namespace WebCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var moq = new Mock<ICalculatorRepository.ICalculatorRepository>();
            moq.Setup(m => m.GetOperations(It.IsAny<string>())).Returns
                (Task.FromResult(default(IEnumerable<string>)));
            HomeController controller = new HomeController(moq.Object);

            // Act
            ViewResult result = controller.Index().Result as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
