using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BAL.Services.Interfaces
{
    public interface IAuthenticateService
    {
        string GenerateToken(ClaimsIdentity identity);
        Task<ClaimsIdentity> GetIdentity(string userName, string password);
    }
}
