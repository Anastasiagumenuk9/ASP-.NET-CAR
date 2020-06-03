using Application.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using MODELS.Interfaces;
using Moq;
using DAL.Repositories;
using MODELS.DB;
using AutoMapper;
using MODELS.ViewModels;
using BAL.Interfaces;
using BAL.Managers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Application.Controllers.Tests
{
   
    public class CarControllerXunitTests:IDisposable
    {
        private Car car;
        private Car carSecond;
        private Color color;
        private Transmission transmission;
        private int transmissionId;
        private int colorId;
        private List<Car> cars;
        private List<Car> carsExpected;
        private int carId;
        private string name;
        private Mock<IMapper> mapperMock;
        private Mock<IGenericRepository<Car>> mock;
        private Mock<IUnitOfWork> unitOfWorkMock;

       
        public CarControllerXunitTests()
        {
            colorId = 3;
            color = new Color() { Id = colorId };

            transmissionId = 2;
            transmission = new Transmission() { Id = transmissionId };

            carId = 1;
            name = "AAA";
            car = new Car() { Name = name, Id = carId, ColorId = colorId, TransmissionId = transmissionId };
            carSecond = new Car() { Name = "BBB", Id = 2 };
            cars = new List<Car>();
            carsExpected = new List<Car>();
           

            carsExpected.Add(car);
            cars.Add(car);
            cars.Add(carSecond);

            mapperMock = new Mock<IMapper>();
            mock = new Mock<IGenericRepository<Car>>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void AddCar_AddCar_RedirectToIndexPage()
        {
            // Arrange
            mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());
            mock.Setup(m => m.Insert(car)).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(mock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            var controller = new CarController(carManager);
            CarViewModel carViewModel = mapperMock.Object.Map<Car, CarViewModel>(car);

            // Act
            var result = controller.AddCar(carViewModel);

            // Assert
            var redirectToActionResult = Xunit.Assert.IsType<RedirectToActionResult>(result);
            Xunit.Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.Insert(It.IsAny<Car>())); 
        }

        //[Fact]
        //public void DeleteConfirmed_DeleteCar_RedirectToIndexPage()
        //{
        //    // Arrange
        //    mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());
        //    mock.Setup(m => m.Delete(car)).Verifiable();
        //    unitOfWorkMock.Setup(m => m.Cars).Returns(mock.Object);

        //    ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

        //    var controller = new CarController(carManager);
        //    IActionResult result;

        //    // Act
        //    result = controller.DeleteConfirmed(carId);

        //    // Assert
        //    var redirectToActionResult = Xunit.Assert.IsType<RedirectToActionResult>(result);
        //    Xunit.Assert.Equal("Index", redirectToActionResult.ActionName);
        //    mock.Verify(r => r.Delete(It.IsAny<Car>()));
        //    Xunit.Assert.Null(car);
        //}
        public void Dispose()
        {
            
        }
    }
}