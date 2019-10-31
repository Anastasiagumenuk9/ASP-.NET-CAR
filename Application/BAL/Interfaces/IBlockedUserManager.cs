using MODELS.DB;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IBlockedUserManager
    {
        IEnumerable<BlockedUserViewModel> GetBlockedUsers(); //Get BlockedUsers

        ApplicationUser GetUserByEmail(string email); // Get BlockedUsers by Email

        BlockedUserViewModel GetById(int id); // Get BlockedUsers by Id



        void Insert(BlockedUserViewModel item);  // Put BlockedUsers 

        void Update(BlockedUserViewModel item); // Update  BlockedUsers 

        void Delete(int id);  // Delete BlockedUsers 
    }
}
