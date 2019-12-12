using AutoMapper;
using BAL.Interfaces;
using MODELS.Interfaces;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using MODELS.DB;
using System.Linq;

namespace BAL.Managers
{
    public class UserManager : GenericManager, IUserManager
    {
        public UserManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public LoginViewModel GetById(int id)
        {
            user user = unitOfWork.users.GetById(id);
            return mapper.Map<user, LoginViewModel>(user);
        }

        public IEnumerable<LoginViewModel> GetUsers()
        {
            IEnumerable<user> users = unitOfWork.users.GetAll();
            return mapper.Map<IEnumerable<user>, List<LoginViewModel>>(users);
        }

        public user GetUserByEmail(string email)
        {
            var moderator = unitOfWork.users.Get(u => u.Email == email).FirstOrDefault();

            return moderator;
        }

        public void Insert(LoginViewModel item)
        {
            user bu = mapper.Map<LoginViewModel, user>(item);

            unitOfWork.users.Insert(bu);
            unitOfWork.Save();
        }

        public void Update(LoginViewModel item)
        {
           user User = mapper.Map<LoginViewModel, user>(item);

            unitOfWork.users.Update(User);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            user u = unitOfWork.users.GetById(id);
            unitOfWork.users.Delete(u);
            unitOfWork.Save();
        }
    }
}
