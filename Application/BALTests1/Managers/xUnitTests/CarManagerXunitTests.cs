using System;
using System.Collections.Generic;
using System.Text;
using MODELS.Interfaces;
using Moq;
using MODELS.DB;
using AutoMapper;
using MODELS.ViewModels;
using BAL.Interfaces;
using BAL.Managers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Linq.Expressions;
using System.Linq;

namespace BALTests.Managers.xUnitTests
{
    public class CarManagerXunitTests
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


        public CarManagerXunitTests()
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

        [Fact]
        public void GetById_carWithId1_carReturned()
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
            Assert.NotNull(actual.Id);//assert that a result was returned
            Assert.Equal(expected.Id, actual.Id);//assert that actual result was as expected
        }

        [Fact]
        public void GetCars_AddCarsToCarList_ThenCarListReturned()
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
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void Delete_carWithId1_NullObjectReturned()
        //{
        //    //Arrange 
        //    bool callFailed = false;

        //    mapperMock.Setup(m => m.Map<Car, CarViewModel>(It.IsAny<Car>())).Returns(new CarViewModel());
        //    productRepositoryMock.Setup(m => m.GetById(carId)).Returns(car).Verifiable();
        //    unitOfWorkMock.Setup(m => m.Cars).Returns(productRepositoryMock.Object);

        //    ICarManager carManager = new CarManager(unitOfWorkMock.Object, mapperMock.Object);

        //    try
        //    {   
        //        //Act
        //        carManager.Delete(carId);
        //    }
        //    catch (ArgumentNullException)
        //    {
        //        callFailed = true;
                
        //    }
        //    //Assert
        //    Assert.True(callFailed, "Car not exists!");
        //    productRepositoryMock.Verify(m => m.Delete(car));
            
        //}


        [Fact]
        public void GetCars_CountOfPageSearchValue_CarListReturned()
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
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCarsWithColor_ColorIdIs3_CarListReturnedWithCarColorId3()
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
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetCarsWithTransmission_TransmissionIdIs3_CarListWithTransmission3Returned()
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
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_addAnotherCarToList_SaveNewList()
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

        [Fact]
        public void Update_UpdateCar_UpdatedCarReturned()
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
