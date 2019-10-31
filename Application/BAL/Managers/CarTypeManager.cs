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
    public class CarTypeManager : GenericManager, ICarTypeManager
    {
        public CarTypeManager(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
        {

        }

        public void Delete(int id)
        {
            CarType carType = unitOfWork.CarTypes.GetById(id);
            unitOfWork.CarTypes.Delete(carType);
            unitOfWork.Save();
        }

        public IEnumerable<CarTypeViewModel> GetCarTypes()
        {
            IEnumerable<CarType> carTypes = unitOfWork.CarTypes.GetAll();
            return mapper.Map<IEnumerable<CarType>, List<CarTypeViewModel>>(carTypes);
        }

        public CarTypeViewModel GetById(int id)
        {
            CarType carType = unitOfWork.CarTypes.GetById(id);
            return mapper.Map<CarType, CarTypeViewModel>(carType);
        }

        public void Insert(CarTypeViewModel item)
        {
            CarType carType = mapper.Map<CarTypeViewModel, CarType>(item);
            unitOfWork.CarTypes.Insert(carType);
            unitOfWork.Save();
        }

        public void Update(CarTypeViewModel item)
        {
            CarType carType = mapper.Map<CarTypeViewModel, CarType>(item);
            unitOfWork.CarTypes.Update(carType);
            unitOfWork.Save();
        }
    }
}
