using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MODELS.DTOs
{
    public  class TokenRequestDTO
    {
        [Required]
        public string UserName { get; set; }


           [Required]
        public string Password { get; set; }
    }
}
