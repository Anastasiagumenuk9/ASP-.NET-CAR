using MODELS.DB;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IUserManager
    {
        IEnumerable<LoginViewModel> GetUsers(); 

        user GetUserByEmail(string email); 

        LoginViewModel GetById(int id); 



        void Insert(LoginViewModel item);  // Put 

        void Update(LoginViewModel item); // Update 

        void Delete(int id);  // Delete  
    }
}
