using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MODELS.Token;

namespace Application.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {


        private readonly IAuthenticateManager _authService;

        public AuthenticationController(IAuthenticateManager authService)
        {
            _authService = authService;
        }


        [AllowAnonymous]
        [System.Web.Http.HttpPost]
        public ActionResult RequestToken([System.Web.Http.FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token;
            if (_authService.IsAuthenticated(request, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }

    }
    }