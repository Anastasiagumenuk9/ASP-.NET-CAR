using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Application.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : Controller
    {

        public AccountController()
        {
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(Models.RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //    return View(model);
        //}
        
       
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    ApplicationUser user = await _context.Users
        //    //        .Include(u => u.AppRole)
        //    //        .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
        //    //    if (user != null)
        //    //    {
        //    //        await Authenticate(user); // аутентификация

        //    //        return RedirectToAction("Index", "Home");
        //    //    }
        //    //    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //    //}
        //    return View(model);
        //}
        //private async Task Authenticate(ApplicationUser user)
        //{
        //    // создаем один claim
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),

        //    };
        //    // создаем объект ClaimsIdentity
        //    ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
        //        ClaimsIdentity.DefaultRoleClaimType);
        //    // установка аутентификационных куки
        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        //}

     }
}