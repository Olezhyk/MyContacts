using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyContacts.BusinessLogic.Services.ServiceInterfaces;
using MyContacts.BusinessLogic.ViewModels;
using MyContacts.Controllers.MvcControllers;
using MyContacts.Entities.Models;

namespace MyContacts.Tests.Controllers
{
    [TestClass]
    public class MvcContactControllerTest
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            var mock = new Mock<IContactService>();
            ContactController controller = new ContactController(mock.Object);

            ViewResult result = controller.List() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewEqualIndexCshtml()
        {
            var mock = new Mock<IContactService>();
            ContactController controller = new ContactController(mock.Object);

            ViewResult result = controller.List() as ViewResult;

            Assert.AreEqual("List", result.ViewName);
        }

        [TestMethod]
        public void IndexStringInViewbag()
        {
            var mock = new Mock<IContactService>();
            ContactController controller = new ContactController(mock.Object);

            ViewResult result = controller.List() as ViewResult;

            Assert.AreEqual("Hello world!", result.ViewBag.Message);
        }
    }
}
