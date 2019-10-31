using AutoMapper;
using BAL.Interfaces;
using MODELS.DB;
using MODELS.Interfaces;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Managers
{
    public class LocationCarManager : GenericManager, ILocationCarManager
    {
        public LocationCarManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public void Delete(int id)
        {
            LocationCar locationCar = unitOfWork.LocationCars.GetById(id);
            unitOfWork.LocationCars.Delete(locationCar);
            unitOfWork.Save();

        }

        public LocationCarViewModel GetById(int id)
        {
            LocationCar locationCar = unitOfWork.LocationCars.GetById(id);
            return mapper.Map<LocationCar, LocationCarViewModel>(locationCar);
        }

        public IEnumerable<LocationCarViewModel> GetLocationCars()
        {
            IEnumerable<LocationCar> locationCars = unitOfWork.LocationCars.GetAll();
            return mapper.Map<IEnumerable<LocationCar>, List<LocationCarViewModel>>(locationCars);
        }

        public void Insert(LocationCarViewModel item)
        {
            LocationCar locationCar = mapper.Map<LocationCarViewModel, LocationCar>(item);
            unitOfWork.LocationCars.Insert(locationCar);
            unitOfWork.Save();

        }

        public void Update(LocationCarViewModel item)
        {
            LocationCar locationCar = mapper.Map<LocationCarViewModel, LocationCar>(item);
            unitOfWork.LocationCars.Update(locationCar);
            unitOfWork.Save();
        }
    }
}
