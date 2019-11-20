using Microsoft.AspNetCore.Identity;
using MODELS.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS
{
    public static class DataBaseInitializer
    {

        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }


        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("User@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "User@gmail.com";
                user.Email = "User@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "1234ABCD").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }


            if (userManager.FindByNameAsync("Admin@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Admin@gmail.com";
                user.Email = "Admin@gmail.com";

                IdentityResult result;
                result = userManager.CreateAsync(user, "1234ABCD").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

           
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

          
            if (!roleManager.RoleExistsAsync("BlockedUser").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "BlockedUser";
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }
        }
    }
}
