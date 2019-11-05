using BAL.Interfaces;
using BAL.Managers;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MODELS.DB;
using MODELS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddAllScoped(this IServiceCollection services)
        {
         services.AddScoped<IApplicationUserManager, ApplicationUserManager>();

            return services;
        }

        public static IServiceCollection AddAllTransient(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticateManager, TokenAuthenticationManager>();
            services.AddTransient<IBlockedUserManager, BlockedUserManager>();
            services.AddTransient<ICarManager, CarManager>();
            services.AddTransient<ICityManager, CityManager>();
            services.AddTransient<ICarTypeManager, CarTypeManager>();
            services.AddTransient<IColorManager, ColorManager>();
            services.AddTransient<ILocationManager, LocationManager>();
            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<IPhotoCarManager, PhotoCarManager>();
            services.AddTransient<IPhotoUserManager, PhotoUserManager>();
            services.AddTransient<IRequiredInformationManager, RequiredInformationManager>();
            services.AddTransient<ITransmissionManager, TransmissionManager>();
   

            return services;
        }

        public static IServiceCollection AddAllRepository(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<ApplicationUser>, GenericRepository<ApplicationUser>>();
            services.AddTransient<IGenericRepository<BlockedUser>, GenericRepository<BlockedUser>>();
            services.AddTransient<IGenericRepository<Car>, GenericRepository<Car>>();
            services.AddTransient<IGenericRepository<CarType>, GenericRepository<CarType>>();
            services.AddTransient<IGenericRepository<City>, GenericRepository<City>>();
            services.AddTransient<IGenericRepository<Color>, GenericRepository<Color>>();
            services.AddTransient<IGenericRepository<Location>, GenericRepository<Location>>();
            services.AddTransient<IGenericRepository<LocationCar>, GenericRepository<LocationCar>>();
            services.AddTransient<IGenericRepository<Order>, GenericRepository<Order>>();
            services.AddTransient<IGenericRepository<PhotoCar>, GenericRepository<PhotoCar>>();
            services.AddTransient<IGenericRepository<PhotoUser>, GenericRepository<PhotoUser>>();
            services.AddTransient<IGenericRepository<Transmission>, GenericRepository<Transmission>>();
            services.AddTransient<IGenericRepository<RequiredInformation>, GenericRepository<RequiredInformation>>();
          

            return services;
        }
    }
}
