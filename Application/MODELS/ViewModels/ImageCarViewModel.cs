using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS.ViewModels
{
    public class ImageCarViewModel
    {
        public int CarId { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
