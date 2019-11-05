using BAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MODELS.DB;
using MODELS.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Managers
{
    public class TokenAuthenticationManager : IAuthenticateManager
    {
        public bool IsAuthenticated(TokenRequest request, out string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
