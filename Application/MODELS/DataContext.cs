using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace MODELS.DB
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<BlockedUser> BlockedUsers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarType> CarTypes { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<PhotoCar> PhotosCar { get; set; }

        public DbSet<PhotoUser> PhotosUser { get; set; }

        public DbSet<RequiredInformation> RequiredInformation { get; set; }

       

        public DbSet<Transmission> Transmission { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




         
         
            builder.Entity<BlockedUser>().HasKey(i => i.Id);
           
            builder.Entity<Car>().HasKey(i => i.Id);
           
            builder.Entity<CarType>().HasKey(i => i.Id);
           
            builder.Entity<City>().HasKey(i => i.Id);
           
            builder.Entity<Color>().HasKey(i => i.Id);
            
            builder.Entity<Location>().HasKey(i => i.Id);
           
            builder.Entity<Order>().HasKey(i => i.Id);
           
            builder.Entity<PhotoCar>().HasKey(i => i.Id);
          
            builder.Entity<PhotoUser>().HasKey(i => i.Id);
           
            builder.Entity<RequiredInformation>().HasKey(i => i.Id);
         
            builder.Entity<Transmission>().HasKey(i => i.Id);
           
    

            //Connections




            builder.Entity<ApplicationUser>()
        .HasOne(m => m.RequiredInformation)
        .WithOne(m => m.ApplicationUser)
        .HasForeignKey<RequiredInformation>(m => m.ApplicationUserId);


            builder.Entity<Car>()
        .HasMany(p => p.PhotosCar)
        .WithOne(p => p.Car)
        .HasForeignKey(s => s.CarId);

           builder.Entity<Car>()
        .HasMany(p => p.LocationsCars)
        .WithOne(p => p.Car)
        .HasForeignKey(s => s.CarId);

           builder.Entity<ApplicationUser>()
        .HasMany(p => p.PhotosUser)
        .WithOne(p => p.ApplicationUser)
        .HasForeignKey(s => s.ApplicationUserId);

           builder.Entity<ApplicationUser>()
        .HasMany(p => p.Orders)
        .WithOne(p => p.ApplicationUser)
        .HasForeignKey(s => s.ApplicationUserId);

           builder.Entity<CarType>()
        .HasMany(p => p.Cars)
        .WithOne(p => p.CarType)
        .HasForeignKey(s => s.CarTypeId);

           builder.Entity<City>()
        .HasMany(p => p.Locations)
        .WithOne(p => p.City)
        .HasForeignKey(s => s.CityId);

           builder.Entity<Color>()
        .HasMany(p => p.Cars)
        .WithOne(p => p.Color)
        .HasForeignKey(s => s.ColorId);

           builder.Entity<Location>()
        .HasMany(p => p.LocationsCars)
        .WithOne(p => p.Location)
        .HasForeignKey(s => s.LocationId);

           builder.Entity<Transmission>()
        .HasMany(p => p.Cars)
        .WithOne(p => p.Transmission)
        .HasForeignKey(s => s.TransmissionId);

       

            builder.Entity<Car>()
        .Property(c => c.Name)
        .IsRequired();

        }


    }
}
