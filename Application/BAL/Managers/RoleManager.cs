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
    public class RoleManager : GenericManager, IRoleManager
    {
        public RoleManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public RoleViewModel GetById(int id)
        {
           Role r = unitOfWork.Roles.GetById(id);
            return mapper.Map<Role,RoleViewModel>(r);
        }

        public IEnumerable<RoleViewModel> GetRoles()
        {
            IEnumerable<Role> roles = unitOfWork.Roles.GetAll();
            return mapper.Map<IEnumerable<Role>, List<RoleViewModel>>(roles);
        }

    

        public void Insert(RoleViewModel item)
        {
            Role bu = mapper.Map<RoleViewModel, Role>(item);

            unitOfWork.Roles.Insert(bu);
            unitOfWork.Save();
        }

        public void Update(RoleViewModel item)
        {
            Role r = mapper.Map<RoleViewModel, Role>(item);

            unitOfWork.Roles.Update(r);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            Role u = unitOfWork.Roles.GetById(id);
            unitOfWork.Roles.Delete(u);
            unitOfWork.Save();
        }
    }
}
