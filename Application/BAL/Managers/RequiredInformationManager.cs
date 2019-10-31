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
    public class RequiredInformationManager : GenericManager, IRequiredInformationManager
    {
        public RequiredInformationManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public void Delete(int id)
        {
            RequiredInformation inf = unitOfWork.RequiredInformation.GetById(id);
            unitOfWork.RequiredInformation.Delete(inf);
            unitOfWork.Save();
        }

        public RequiredInformationViewModel GetById(int id)
        {
            RequiredInformation inf = unitOfWork.RequiredInformation.GetById(id);
            return mapper.Map<RequiredInformation, RequiredInformationViewModel>(inf);
        }

        public IEnumerable<RequiredInformationViewModel> GetRequiredInformation()
        {
            IEnumerable<RequiredInformation> inf = unitOfWork.RequiredInformation.GetAll();
            return mapper.Map<IEnumerable<RequiredInformation>, List<RequiredInformationViewModel>>(inf);
        }

        public void Insert(RequiredInformationViewModel item)
        {
            RequiredInformation inf = mapper.Map<RequiredInformationViewModel, RequiredInformation>(item);
            unitOfWork.RequiredInformation.Insert(inf);
            unitOfWork.Save();

        }

        public void Update(RequiredInformationViewModel item)
        {
            RequiredInformation inf = mapper.Map<RequiredInformationViewModel, RequiredInformation>(item);
            unitOfWork.RequiredInformation.Update(inf);
            unitOfWork.Save();
        }
    }
}
