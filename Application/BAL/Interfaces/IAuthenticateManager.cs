using MODELS.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IAuthenticateManager
    {
        string GenerateToken(ClaimsIdentity identity);
        Task<ClaimsIdentity> GetIdentity(string userName, string password);
    }
}
