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
    public class CityManager : GenericManager, ICityManager
    {
        public CityManager(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
        {

        }
        public void Delete(int id)
        {
            City city = unitOfWork.Cities.GetById(id);
            unitOfWork.Cities.Delete(city);
            unitOfWork.Save();
        }

        public CityViewModel GetById(int id)
        {
            City city = unitOfWork.Cities.GetById(id);
            return mapper.Map<City, CityViewModel>(city);
        }

        public IEnumerable<CityViewModel> GetCities()
        {
            IEnumerable<City> cities = unitOfWork.Cities.GetAll();
            return mapper.Map<IEnumerable<City>, List<CityViewModel>>(cities);
        }

        public void Insert(CityViewModel item)
        {
            City city = mapper.Map<CityViewModel, City>(item);
            unitOfWork.Cities.Insert(city);
            unitOfWork.Save();

        }

        public void Update(CityViewModel item)
        {
            City city = mapper.Map<CityViewModel, City>(item);
            unitOfWork.Cities.Update(city);
            unitOfWork.Save();
        }
    }
}
