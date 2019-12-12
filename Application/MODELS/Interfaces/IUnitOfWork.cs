using MODELS.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ApplicationUser> ApplicationUsers { get; }

        IGenericRepository<BlockedUser> BlockedUsers { get; }

        IGenericRepository<Car> Cars { get; }

        IGenericRepository<CarType> CarTypes { get; }

        IGenericRepository<City> Cities { get; }

        IGenericRepository<Color> Colors { get; }

        IGenericRepository<Location> Locations { get; }

        IGenericRepository<LocationCar> LocationCars { get; }

        IGenericRepository<Order> Orders { get; }

        IGenericRepository<PhotoCar> PhotosCar { get; }

        IGenericRepository<PhotoUser> PhotosUser { get; }

        IGenericRepository<Transmission> Transmission { get; }

        IGenericRepository<RequiredInformation> RequiredInformation { get; }

        IGenericRepository<Role> Roles { get; }

        IGenericRepository<user> users { get; }





        int Save();

    }
}
