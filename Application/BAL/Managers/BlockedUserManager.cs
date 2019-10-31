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
    public class BlockedUserManager : GenericManager, IBlockedUserManager
    {
        public BlockedUserManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public void Delete(int id)
        {
            BlockedUser blockedUser = unitOfWork.BlockedUsers.GetById(id);
            unitOfWork.BlockedUsers.Delete(blockedUser);
            unitOfWork.Save();
        }

        public BlockedUserViewModel Get(int id)
        {
            BlockedUser bu = unitOfWork.BlockedUsers.GetById(id);

            return mapper.Map<BlockedUser, BlockedUserViewModel>(bu);
        }

        public IEnumerable<BlockedUserViewModel> GetBlockedUsers()
        {

            IEnumerable<BlockedUser> blockedUsers = unitOfWork.BlockedUsers.GetAll();

            return mapper.Map<IEnumerable<BlockedUser>, List<BlockedUserViewModel>>(blockedUsers);
        }
        public ApplicationUser GetUserByEmail(string email)
        {
            var moderator = unitOfWork.ApplicationUsers.Get(u => u.Email == email).FirstOrDefault();

            return moderator;
        }
        public BlockedUserViewModel GetById(int id)
        {
            BlockedUser blockedUser = unitOfWork.BlockedUsers.GetById(id);

            return mapper.Map<BlockedUser, BlockedUserViewModel>(blockedUser);
        }

        public void Insert(BlockedUserViewModel item)
        {
            BlockedUser bu = mapper.Map<BlockedUserViewModel, BlockedUser>(item);

            unitOfWork.BlockedUsers.Insert(bu);
            unitOfWork.Save();
        }

        public void Update(BlockedUserViewModel item)
        {
            BlockedUser blockedUser = mapper.Map<BlockedUserViewModel, BlockedUser>(item);

            unitOfWork.BlockedUsers.Update(blockedUser);
            unitOfWork.Save();
        }
    }
}
