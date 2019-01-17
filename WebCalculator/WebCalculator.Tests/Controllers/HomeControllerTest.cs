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
        public void IndexReturnesView()
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

        [TestMethod]
        public void IndexReturnesListOfStrings()
        {
            //Arrange
            var moq = new Mock<ICalculatorRepository.ICalculatorRepository>();
            moq.Setup(m => m.GetOperations(It.IsAny<string>())).Returns
                (Task.FromResult(new List<string>() as IEnumerable<string>));
            HomeController controller = new HomeController(moq.Object);

            //Act
            ViewResult result = controller.Index().Result as ViewResult;

            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void PostRecordReturnedJsonResult()
        {
            //Arrange
            var moq = new Mock<ICalculatorRepository.ICalculatorRepository>();
            HomeController controller = new HomeController(moq.Object);

            //Act
            JsonResult result = controller.PostRecord("").Result;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostRecortReturnsSuccess()
        {
            //Arrange
            var moq = new Mock<ICalculatorRepository.ICalculatorRepository>();
            HomeController controller = new HomeController(moq.Object);

            //Act
            JsonResult result = controller.PostRecord("").Result;

            //Assert
            Assert.AreEqual(result.Data.ToString(), "{\"Success\": \"true\"}");
        }

        [TestMethod]
        public void PostRecordThrowsError()
        {
            //Arrange
            var moq = new Mock<ICalculatorRepository.ICalculatorRepository>();
            string exceptionMessage = "A \"Test eception\" had occured";
            moq.Setup(m => m.SaveOperation(It.IsAny<string>(), It.IsAny<string>())).
                Throws(new Exception(exceptionMessage));
            HomeController controller = new HomeController(moq.Object);

            //Act
            JsonResult result = controller.PostRecord("").Result;

            //Assert
            Assert.AreEqual(result.Data.ToString(), $"{{\"Success\": \"false\", \"Error\":\"{exceptionMessage.Replace("\"", "'")}\"}}");
        }
    }
}
