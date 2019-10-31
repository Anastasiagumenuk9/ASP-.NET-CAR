using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.DB
{
    public class ApplicationUser : IdentityUser
    {
       
        public RequiredInformation RequiredInformation { get; set; }
        public ICollection<PhotoUser> PhotosUser { get; set; }

        public ICollection<Order> Orders { get; set; }

   
    }
}
