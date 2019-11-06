using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IAuthenticateManager
    {
        string GenerateToken(ClaimsIdentity identity);
        Task<ClaimsIdentity> GetIdentity(string userName, string password);
    }
}

