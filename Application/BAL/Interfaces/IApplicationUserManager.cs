using MODELS.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IApplicationUserManager
    {
        Task<LoginViewModel> Create(RegisterViewModel model);
    }
}
