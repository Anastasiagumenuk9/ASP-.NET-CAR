using System;
using System.Collections.Generic;
using System.Text;
using MODELS.DB;
using MODELS.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;

        private IGenericRepository<ApplicationUser> appUsersRepo;
        private IGenericRepository<BlockedUser> blockedUsersRepo;
        private IGenericRepository<Car> carsRepo;
        private IGenericRepository<CarType> carTypesRepo;
        private IGenericRepository<City> citiesRepo;
        private IGenericRepository<Color> colorsRepo;
        private IGenericRepository<Location> locationsRepo;
        private IGenericRepository<LocationCar> locationCarsRepo;
        private IGenericRepository<Order> ordersRepo;
        private IGenericRepository<PhotoCar> photosCarRepo;
        private IGenericRepository<PhotoUser> photosUserRepo;
        private IGenericRepository<Transmission> transmissionRepo;
        private IGenericRepository<RequiredInformation> RequiredInformationsRepo;


        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        #region EntityRepository

        public IGenericRepository<ApplicationUser> ApplicationUsers
        {
            get
            {
                if (appUsersRepo == null) { appUsersRepo = new GenericRepository<ApplicationUser>(context); }
                return appUsersRepo;
            }
        }

        public IGenericRepository<BlockedUser> BlockedUsers
        {
            get
            {
                if (blockedUsersRepo == null) { blockedUsersRepo = new GenericRepository<BlockedUser>(context); }
                return blockedUsersRepo;
            }
        }



        public IGenericRepository<Car> Cars
        {
            get
            {
                if (carsRepo == null) { carsRepo = new GenericRepository<Car>(context); }
                return carsRepo;
            }
        }

        public IGenericRepository<CarType> CarTypes
        {
            get
            {
                if (carTypesRepo == null) {carTypesRepo = new GenericRepository<CarType>(context); }
                return carTypesRepo;
            }
        }

        public IGenericRepository<City> Cities
        {
            get
            {
                if (citiesRepo == null) { citiesRepo = new GenericRepository<City>(context); }
                return citiesRepo;
            }
        }
        public IGenericRepository<RequiredInformation> RequiredInformation
        {
            get
            {
                if (RequiredInformationsRepo == null) { RequiredInformationsRepo = new GenericRepository<RequiredInformation>(context); }
                return RequiredInformationsRepo;
            }
        }

        public IGenericRepository<Color> Colors
        {
            get
            {
                if (colorsRepo == null) { colorsRepo = new GenericRepository<Color>(context); }
                return colorsRepo;
            }
        }

        public IGenericRepository<Location> Locations
        {
            get
            {
                if (locationsRepo == null) { locationsRepo = new GenericRepository<Location>(context); }
                return locationsRepo;
            }
        }

        public IGenericRepository<LocationCar> LocationCars
        {
            get
            {
                if (locationCarsRepo == null) { locationCarsRepo = new GenericRepository<LocationCar>(context); }
                return locationCarsRepo;
            }
        }

        public IGenericRepository<Order> Orders
        {
            get
            {
                if (ordersRepo == null) { ordersRepo = new GenericRepository<Order>(context); }

                return ordersRepo;
            }
        }

        public IGenericRepository<PhotoCar> PhotosCar
        {
            get
            {
                if (photosCarRepo == null) { photosCarRepo = new GenericRepository<PhotoCar>(context); }
                return photosCarRepo;
            }
        }
        public IGenericRepository<PhotoUser> PhotosUser
        {
            get
            {
                if (photosUserRepo == null) { photosUserRepo = new GenericRepository<PhotoUser>(context); }
                return photosUserRepo;
            }
        }
        public IGenericRepository<Transmission> Transmission
        {
            get
            {
                if (transmissionRepo == null) { transmissionRepo = new GenericRepository<Transmission>(context); }
                return transmissionRepo;
            }
        }

       

        #endregion
        public int Save()
        {
            return context.SaveChanges();
        }

        private bool isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                context.Dispose();
            }
            isDisposed = true;
        }
    }
}
