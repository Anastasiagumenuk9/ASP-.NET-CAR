using AutoMapper;
using BAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using MODELS.DB;
using MODELS.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Managers
{
    public class ApplicationUserManager : IApplicationUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticateManager _authenticateService;
        private readonly IMapper _mapper;

        public ApplicationUserManager(IMapper mapper, UserManager<ApplicationUser> userManager,
            IAuthenticateManager authenticateService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authenticateService = authenticateService;
        }

        public async Task<MODELS.ViewModels.AccountViewModels.LoginViewModel> Create(RegisterViewModel model)
        {
            var user = _mapper.Map<RegisterViewModel, ApplicationUser>(model);


            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                var resultRole = await _userManager.AddToRoleAsync(user, model.Role);
                if (!resultRole.Succeeded)
                {
                    throw new Exception("Exception added roles!");
                }
            }

            var userapp =  _mapper.Map<ApplicationUser, LoginViewModel>(user);
            userapp.Password = user.PasswordHash;
            userapp.Message = result.Succeeded.ToString();
            return userapp;
        }
    }
}
