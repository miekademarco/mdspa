using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicZDem.MdSpa.Domain;
using MicZDem.MdSpa.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MicZDem.MdSpa.WebUI.Controllers.Tests
{
    [TestClass()]
    public class PersonsControllerTests
    {
        [TestMethod()]
        public void Post_PersonWithNegativeAge_Test()
        {
            // Arrange
            var controller = new PersonsController();

            // Create a person with a negative age
            var p = new Person()
            {
                FirstName = "Mic",
                LastName = "Dem",
                Age = -30,
                Location = "Sydney"
            };

            try
            {
                var ret = controller.Post(p);
                Assert.Fail(); //should generate exception
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }

        }
    }
}
