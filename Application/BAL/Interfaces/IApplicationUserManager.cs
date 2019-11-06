using MODELS.DTO;
using MODELS.DTO.AccountModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IApplicationUserManager
    {
        Task<UserDTO> Create(RegisterModelDTO model);
    }
}
