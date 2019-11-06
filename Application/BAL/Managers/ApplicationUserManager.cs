using AutoMapper;
using BAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using MODELS.DB;
using MODELS.DTO;
using MODELS.DTO.AccountModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Managers
{
    public class ApplicationUserManager: IApplicationUserManager
    {

            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IAuthenticateManager _authenticateService;
            private readonly IMapper _mapper;

            public ApplicationUserManager(IMapper mapper, UserManager<ApplicationUser> userManager,
                IAuthenticateManager authenticateService) //: base(mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
                _authenticateService = authenticateService;
            }

            public async Task<UserDTO> Create(RegisterModelDTO model)
            {
                var user = _mapper.Map<RegisterModelDTO, ApplicationUser>(model);


                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    var resultRole = await _userManager.AddToRoleAsync(user, model.Role);
                    if (!resultRole.Succeeded)
                    {
                        throw new Exception("Exception added roles!");
                    }
                }

                var userDto = _mapper.Map<ApplicationUser, UserDTO>(user);
                userDto.Password = user.PasswordHash;
                userDto.Message = result.Succeeded.ToString();
                return userDto;
            }
        }
}
