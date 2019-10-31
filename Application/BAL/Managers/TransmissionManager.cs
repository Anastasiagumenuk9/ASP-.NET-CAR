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
    public class TransmissionManager : GenericManager, ITransmissionManager
    {
        public TransmissionManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
          
        }

        public void Delete(int id)
        {
            Transmission tran = unitOfWork.Transmission.GetById(id);
            unitOfWork.Transmission.Delete(tran);
            unitOfWork.Save();
        }

        public TransmissionViewModel GetById(int id)
        {
            Transmission tran = unitOfWork.Transmission.GetById(id);
            return mapper.Map<Transmission, TransmissionViewModel>(tran);
        }

        public IEnumerable<TransmissionViewModel> GetTransmissions()
        {
            IEnumerable<Transmission> trans = unitOfWork.Transmission.GetAll();
            return mapper.Map<IEnumerable<Transmission>, List<TransmissionViewModel>>(trans);
        }

        public void Insert(TransmissionViewModel item)
        {
            Transmission tran = mapper.Map<TransmissionViewModel, Transmission>(item);
            unitOfWork.Transmission.Insert(tran);
            unitOfWork.Save();

        }

        public void Update(TransmissionViewModel item)
        {
            Transmission tran = mapper.Map<TransmissionViewModel, Transmission>(item);
            unitOfWork.Transmission.Update(tran);
            unitOfWork.Save();
        }
    }
}
