using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.ViewModels
{
    public class ImageUserViewModel
    {
        public int ApplicationUserId { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
