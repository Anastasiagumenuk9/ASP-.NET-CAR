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
    public class LocationManager : GenericManager, ILocationManager
    {
        public LocationManager(IUnitOfWork unitOfWork, IMapper mapper): base (unitOfWork, mapper)
        {

        }

        public void Delete(int id)
        {
            Location location = unitOfWork.Locations.GetById(id);
            unitOfWork.Locations.Delete(location);
            unitOfWork.Save();

        }

        public LocationViewModel GetById(int id)
        {
            Location location = unitOfWork.Locations.GetById(id);
            return mapper.Map<Location, LocationViewModel>(location);
            
        }

        public IEnumerable<LocationViewModel> GetLocations()
        {
            IEnumerable<Location> locations = unitOfWork.Locations.GetAll();
            return mapper.Map<IEnumerable<Location>, List<LocationViewModel>>(locations);
        }

        public void Insert(LocationViewModel item)
        {
            Location location = mapper.Map<LocationViewModel, Location>(item);
            unitOfWork.Locations.Insert(location);
            unitOfWork.Save();
        }

        public void Update(LocationViewModel item)
        {
            Location location = mapper.Map<LocationViewModel, Location>(item);
            unitOfWork.Locations.Update(location);
            unitOfWork.Save();
        }
    }

}
