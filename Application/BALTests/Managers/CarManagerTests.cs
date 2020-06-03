using AutoMapper;
using BAL.Interfaces;
using BAL.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MODELS.DB;
using MODELS.Interfaces;
using MODELS.ViewModels;
using Moq;

namespace BALTests.Managers
{
    [TestClass]
    public class CarManagerTests
    {
       
        [TestMethod]
        public void GetById_GivenId_IdShouldGetCar()
        {
            //Arrange
            var carId = 1;
            var name = "AAA";
            var car = new Car() { Name = name, Id = carId };

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());

            var expected = mapperMock.Object.Map<Car, CarViewModel>(car);

            var productRepositoryMock = new Mock<IGenericRepository<Car>>();
            productRepositoryMock.Setup(m => m.GetById(carId)).Returns(car).Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            //Act
            var actual = carManager.GetById(carId);

            //Assert
            productRepositoryMock.Verify();//verify that GetByID was called based on setup.
            Assert.IsNotNull(actual);//assert that a result was returned
            Assert.AreEqual(expected, actual);//assert that actual result was as expected
        }
    }
}
