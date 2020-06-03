using Application.Controllers;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BALTests.Controllers
{
    [TestClass]
    public class CarControllerTests
    {
        public ICarManager carManager;
        public IColorManager colorManager;

        [TestMethod]
        public void Index_ViewResult_IsNotNull()
        {
            // Arrange
            CarController controller = new CarController(carManager, colorManager);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
