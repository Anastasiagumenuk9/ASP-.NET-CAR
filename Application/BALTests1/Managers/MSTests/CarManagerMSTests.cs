using Microsoft.VisualStudio.TestTools.UnitTesting;
using BAL.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using MODELS.DB;
using MODELS.Interfaces;
using BAL.Interfaces;
using AutoMapper;
using Moq;
using MODELS.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace BAL.Managers.Tests
{
    [TestClass()]
    public class CarManagerMSTests
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
        private Mock<IGenericRepository<Car>> productRepositoryMock;
        private Mock<IUnitOfWork> unitOfWorkMock;
        private List<Car> Bad;

        [TestInitialize()]
        public void TestInitialize()
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
            Bad = new List<Car>();

            carsExpected.Add(car);
            cars.Add(car);
            cars.Add(carSecond);

            mapperMock = new Mock<IMapper>();
            productRepositoryMock = new Mock<IGenericRepository<Car>>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [TestMethod()]
        public void MSGetById_carWithId1_carReturned()
        {
            //Arrange 
            mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());
            productRepositoryMock.Setup(m => m.GetById(carId)).Returns(car).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            var expected = mapperMock.Object.Map<Car, CarViewModel>(car);

            //Act
            var actual = carManager.GetById(carId);

            //Assert
            productRepositoryMock.Verify();//verify that GetByID was called based on setup.
            Assert.IsNotNull(actual.Id);//assert that a result was returned
            Assert.AreEqual(expected.Id, actual.Id);//assert that actual result was as expected
        }

        [TestMethod()]
        public void MSGetCars_AddCarsToCarList_ThenCarListReturned()
        {
            //Arrange 
            mapperMock.Setup(m => m.Map<IEnumerable<Car>, List<CarViewModel>>(It.IsAny<IEnumerable<Car>>())).Returns(new List<CarViewModel>());
            productRepositoryMock.Setup(m => m.GetAll()).Returns(cars).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            var expected = mapperMock.Object.Map<IEnumerable<Car>, List<CarViewModel>>(cars);

            //Act
            var actual = carManager.GetCars();

            //Assert
            productRepositoryMock.Verify(m => m.GetAll());
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSDelete_carWithId1_NullObjectReturned()
        {
            //Arrange 
            mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());
            productRepositoryMock.Setup(m => m.Delete(car)).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            //Act
            carManager.Delete(carId);

            //Assert
            productRepositoryMock.Verify();
            Assert.IsNull(car);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MSDelete_CarWithId1_ArgumentNullExceptionThrown()
        {
            //Arrange
            car = null;
            mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());
            productRepositoryMock.Setup(m => m.Delete(car)).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            //Act
            carManager.Delete(carId);

            //Assert
            productRepositoryMock.Verify();
        }

        [TestMethod()]
        public void MSGetCars_CountOfPageSearchValue_CarListReturned()
        {
            //Arrange 
            mapperMock.Setup(m => m.Map<IEnumerable<Car>, List<CarViewModel>>(It.IsAny<IEnumerable<Car>>())).Returns(new List<CarViewModel>());
            productRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<Car, bool>>>(), It.IsAny<Func<IQueryable<Car>, IOrderedQueryable<Car>>>(), It.IsAny<string>())).Returns(cars).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            var expected = mapperMock.Object.Map<IEnumerable<Car>, List<CarViewModel>>(carsExpected);

            //Act
            var actual = carManager.GetCars(1, 12, "AAA");

            //Assert
            productRepositoryMock.Verify();
            Assert.IsNotNull(actual);
            CollectionAssert.AreEquivalent(expected, actual.ToList());
        }

        [TestMethod()]
        public void MSGetCarsWithColor_ColorIdIs3_CarListReturnedWithCarColorId3()
        {
            //Arrange 
            mapperMock.Setup(m => m.Map<IEnumerable<Car>, List<CarViewModel>>(It.IsAny<IEnumerable<Car>>())).Returns(new List<CarViewModel>());
            productRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<Car, bool>>>(), It.IsAny<Func<IQueryable<Car>, IOrderedQueryable<Car>>>(), It.IsAny<string>())).Returns(cars).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            var expected = mapperMock.Object.Map<IEnumerable<Car>, List<CarViewModel>>(carsExpected);

            //Act
            var actual = carManager.GetCarsWithColor(colorId);

            //Assert
            productRepositoryMock.Verify();
            Assert.IsNotNull(actual);
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void MSGetCarsWithTransmission_TransmissionIdIs3_CarListWithTransmission3Returned()
        {
            //Arrange
            mapperMock.Setup(m => m.Map<IEnumerable<Car>, List<CarViewModel>>(It.IsAny<IEnumerable<Car>>())).Returns(new List<CarViewModel>());
            productRepositoryMock.Setup(m => m.Get(It.IsAny<Expression<Func<Car, bool>>>(), It.IsAny<Func<IQueryable<Car>, IOrderedQueryable<Car>>>(), It.IsAny<string>())).Returns(cars).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

            var expected = mapperMock.Object.Map<IEnumerable<Car>, List<CarViewModel>>(carsExpected);

            //Act
            var actual = carManager.GetCarsWithtransmission(transmissionId);

            //Assert
            productRepositoryMock.Verify();
            Assert.IsNotNull(actual);
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void MSInsert_addAnotherCarToList_SaveNewList()
        {
            //Arrange
            mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());
            productRepositoryMock.Setup(m => m.Insert(car)).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);
            CarViewModel carViewModel = mapperMock.Object.Map<Car, CarViewModel>(car);

            //Act
            carManager.Insert(carViewModel);

            //Assert

            productRepositoryMock.Verify(r => r.Insert(It.IsAny<Car>()));
        }

        [TestMethod()]
        public void MSUpdate_UpdateCar_UpdatedCarReturned()
        {
            //Arrange
            mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());
            productRepositoryMock.Setup(m => m.Update(car)).Verifiable();
            unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

            ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);
            CarViewModel carViewModel = mapperMock.Object.Map<Car, CarViewModel>(car);

            //Act
            carManager.Update(carViewModel);

            //Assert
            productRepositoryMock.Verify(r => r.Update(It.IsAny<Car>()));
        }
    }
}