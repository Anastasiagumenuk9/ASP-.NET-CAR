using MODELS.DB;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IRoleManager
    {
        IEnumerable<RoleViewModel> GetRoles();

        RoleViewModel GetById(int id);



        void Insert(RoleViewModel item);  // Put 

        void Update(RoleViewModel item); // Update 

        void Delete(int id);  // Delete  
    }
}
