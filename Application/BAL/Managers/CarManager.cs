using AutoMapper;
using BAL.Interfaces;
using MODELS.DB;
using MODELS.Interfaces;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.Managers
{
    public class CarManager : GenericManager , ICarManager
    {
        public CarManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public void Delete(int id)
        {
            Car car = unitOfWork.Cars.GetById(id);

            if(car != null)
            {
                unitOfWork.Cars.Delete(car);
            }
        
            unitOfWork.Save();

        }

        public CarViewModel GetById(int id)
        {
            Car car = unitOfWork.Cars.GetById(id);
            return mapper.Map<Car, CarViewModel>(car);
        }

        public IEnumerable<CarViewModel> GetCars() 
        {
            IEnumerable<Car> cars = unitOfWork.Cars.Get(null,null,"Transmission,Color,CarType,PhotoCar");
            return mapper.Map<IEnumerable<Car>, List<CarViewModel>>(cars);
        }

        //paging
        public IEnumerable<CarViewModel> GetCars(int page, int countOnPage, string searchValue)
        {
            IEnumerable<Car> cars = unitOfWork.Cars
                .Get(c => c.Name.Contains(searchValue) || c.Name.Contains(searchValue))
                .Skip((page - 1) * countOnPage).Take(countOnPage);

            return mapper.Map<IEnumerable<Car>, IEnumerable<CarViewModel>>(cars);
        }

        //filter
        public IEnumerable<CarViewModel> GetCarsWithColor(int color) 
        {
            IEnumerable<Car> cars = unitOfWork.Cars.Get(c => c.ColorId == color);
            return mapper.Map<IEnumerable<Car>, List<CarViewModel>>(cars);

        }

        //filter
        public IEnumerable<CarViewModel> GetCarsWithtransmission(int trans)
        {
            IEnumerable<Car> cars = unitOfWork.Cars.Get(c => c.TransmissionId == trans);
            return mapper.Map<IEnumerable<Car>, List<CarViewModel>>(cars);
        }

        public void Insert(CarViewModel item)
        {
            Car car = mapper.Map<CarViewModel, Car>(item);
            unitOfWork.Cars.Insert(car);
            unitOfWork.Save();
        }

        public void Update(CarViewModel item)
        {
            Car car = mapper.Map<CarViewModel, Car>(item);
            unitOfWork.Cars.Update(car);
            unitOfWork.Save();
        }
    }
}
