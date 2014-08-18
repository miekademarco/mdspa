using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicZDem.MdSpa.WebUI;
using MicZDem.MdSpa.WebUI.Controllers;

namespace MicZDem.MdSpa.WebUI.Unit.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
