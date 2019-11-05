using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public static class DBInitializer
    {
        public static void SeedData(RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);

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

            if (!roleManager.RoleExistsAsync("Advertiser").Result) //Reclamodatel
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Advertiser";
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }
           

        }
    }

}


